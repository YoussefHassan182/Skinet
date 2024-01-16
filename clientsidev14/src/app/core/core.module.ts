import { NgModule } from '@angular/core';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';


//for singelton components like navbar
@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    RouterModule
  ],
  exports:[
    NavBarComponent
  ]
})
export class CoreModule { }
