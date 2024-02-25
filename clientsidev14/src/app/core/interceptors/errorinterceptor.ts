import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { NavigationExtras, Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class Errorinterceptor implements HttpInterceptor {
  constructor(private router:Router,private toastr:ToastrService) {}
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request)
    //pipe to catch the error from the observable itself
    .pipe
    (
      catchError(error=>
        {
          if (error) {
          if (error.status===404) {
              
        this.router.navigateByUrl('/not-found')
            
      }
      else if (error.status===500) {
        const navigarionExtras:NavigationExtras =
        {state:{error:error.error}}
        this.router.navigateByUrl('/server-error',navigarionExtras)
      }
      else if (error.status===400) {
        if (error.error.errors) {
          throw error.error
        }else{
        this.toastr.error(error.error.message,error.error.statusCode)
        }
      }
      else if (error.status===401) {
        this.toastr.error(error.error.message,error.error.statusCode)
      }
    }
      return throwError(error);
    }
    )
    );
  }
}
