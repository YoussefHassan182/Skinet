import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardComponent } from './card/card.component';
import { CardModule } from 'primeng/card';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [
    CardComponent
    
  ],
  imports: [
    CommonModule,
    CardModule,
    TableModule
  ]
})
export class NgprimedemoModule { }
