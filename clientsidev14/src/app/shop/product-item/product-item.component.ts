import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  //first step to pass data from parent component to child
//to receive something from parent component to child component 
//you need to use input property 
@Input() product:IProduct | undefined;
  constructor() { }

  ngOnInit(): void {
  }

}
