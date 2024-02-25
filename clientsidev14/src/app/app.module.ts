import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { HomeModule } from './home/home.module';
import { Errorinterceptor } from './core/interceptors/errorinterceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastContainerModule } from 'ngx-toastr';
import { NgprimedemoModule } from './ngprimedemo/ngprimedemo.module';
import { CardModule } from 'primeng/card';
import { PopupComponent } from './popup/popup.component';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { MoreComponent } from './more/more.component';
@NgModule({
  declarations: [
    AppComponent,
    PopupComponent,
    MoreComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    CoreModule, //it have the navbar component
    //ShopModule, we remove it to confirm lazy loading
    SharedModule, //it have the shared modules
HomeModule,
BrowserAnimationsModule,
ToastContainerModule ,
NgprimedemoModule,
DialogModule,
 ButtonModule

  ],
  providers: 
  [
    {provide:HTTP_INTERCEPTORS,useClass:Errorinterceptor,multi:true},PopupComponent
  ],
  exports: [PopupComponent],

  bootstrap: [AppComponent]
})
export class AppModule { }
