import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { NgxPaginationModule } from 'ngx-pagination';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [
    //added automatically to module as they are in the same directory
    ShopComponent,
    ProductItemComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    NgxPaginationModule,
    //RouterModule
    ShopRoutingModule //we replace routermodule by this 
  ],
  exports:[
    //ShopComponent we remove it to confirm lazy loading because
    // app module is no longer responsible for loading this particular component
    //our shop module have its declaration and responsible for loading it
  ]
})
export class ShopModule { }
