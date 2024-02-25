import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { CardComponent } from './ngprimedemo/card/card.component';
import { MoreComponent } from './more/more.component';
import { PopupComponent } from './popup/popup.component';

const routes: Routes = 
[
  {path:'',component:HomeComponent},
  {path:'test-error',component:TestErrorComponent},
  {path:'server-error',component:ServerErrorComponent},
  {path:'card',component:CardComponent},
  {path:'more',component:MoreComponent},
  {path:'popup',component:PopupComponent},
  {path:'not-found',component:NotFoundComponent},
  //we replace those with childrens to confirm lazy loading
  //the shop module will be only activated and loaded when we access path 
  // {path:'shop',component:ShopComponent},
  // {path:'shop/:id',component:ProductDetailsComponent},
   {path:'shop',loadChildren: ()=> import ('./shop/shop.module').then(mod=>mod.ShopModule)},

  {path:'**',redirectTo:'',pathMatch:'full'},
];

@NgModule({
  //when we use forRoot() that means that will be added to root module (AppModule) 
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }