import { NgModule } from '@angular/core';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';


//for singelton components like navbar
@NgModule({
  declarations: [
    NavBarComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
  ],
  imports: [
    RouterModule, ToastrModule.forRoot
    (
      {
        positionClass:'toast-bottom-right',
        preventDuplicates:true
      }
    ), 
      CommonModule

  ],
  exports:[
    NavBarComponent 
  ]
})
export class CoreModule { }
