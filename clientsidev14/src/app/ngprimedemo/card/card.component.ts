import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopParams } from 'src/app/shared/models/shopParams';
import { ShopService } from 'src/app/shop/shop.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  products:IProduct[]|any;
  shopParams = new ShopParams();

  constructor(private prodSer:ShopService) { }

  ngOnInit(): void {
    this.prodSer.getProducts(this.shopParams).subscribe(p=>this.products=p);
  }

}
