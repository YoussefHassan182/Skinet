import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes:Routes=
[
  //we have empty string for shopcomponent which is the root component for shop module
  {path:'',component:ShopComponent},
  {path:':id',component:ProductDetailsComponent},
]

@NgModule({
  declarations: [],
  imports: [
    //forchild means that these routes are not available in app module and only available in shop module
    RouterModule.forChild(routes)
  ],
  //to use it inside our shop module
  exports:[RouterModule]
})
export class ShopRoutingModule { }
