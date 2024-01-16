import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './core/nav-bar/nav-bar.component';
import {HttpClientModule} from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';
import { SharedModule } from './shared/shared.module';
import { HomeModule } from './home/home.module';
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    CoreModule, //it have the navbar component
    //ShopModule, we remove it to confirm lazy loading
    SharedModule, //it have the shared modules
HomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
