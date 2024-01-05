import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IProduct } from './models/product';
import { IPagination } from './models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Ski-Net';
  products: IProduct[] = [];
  constructor(private http: HttpClient)
  {

  }
  ngOnInit(): void { //called one after ngDoChanges
    this.http.get("https://localhost:5001/api/products/products")
    .subscribe((response:any)=>{
      console.log(response);
      this.products=response.data;
    },err=>{
      console.log(err);
    })
  }
}
