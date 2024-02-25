import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
baseUrl = environment.apiUrl;
validationErrors:any;
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }
  get404Error(){
    return this.http.get(this.baseUrl+'products/500')
    .subscribe(p=>{console.log(p)},err=>{console.log(err);
    });
  }
    get400Error(){
      return this.http.get(this.baseUrl+'buggy/badrequest')
      .subscribe(p=>{console.log(p)},err=>{console.log(err);
      })};
      get400ValidationError(){
        return this.http.get(this.baseUrl+'products/fortytwo').subscribe
        (p=>{console.log(p)},err=>{console.log(err)
        this.validationErrors = err.errors
        }
        )};
        get500Error(){
          return this.http.get(this.baseUrl+'buggy/servererror')
          .subscribe(p=>{console.log(p)},err=>{console.log(err);
          })};
  }
 