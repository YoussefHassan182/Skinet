import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap/pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    //forRoot() to inject the provider module array into our root module in startup
    PaginationModule.forRoot(),
    NgxPaginationModule
  ],
exports:[PaginationModule,NgxPaginationModule,PagingHeaderComponent,PagerComponent]
})
export class SharedModule { }
