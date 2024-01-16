import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
product:IProduct|any;
  constructor(private shopService:ShopService,private activatedRoute:ActivatedRoute) { }
  ngOnInit(): void {
    this.loadProduct();
  }
loadProduct(){
return this.shopService.getProduct(
//+this.activatedRoute.snapshot?.paramMap?.get('id')
2
).subscribe(p=>{
this.product=p;
},err=>{console.log(err);
});
}
}