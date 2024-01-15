import { NgModule } from '@angular/core';
import { NavBarComponent } from './nav-bar/nav-bar.component';


//for singelton components like navbar
@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    
  ],
  exports:[
    NavBarComponent
  ]
})
export class CoreModule { }
