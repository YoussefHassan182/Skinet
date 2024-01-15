import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IProduct } from '../../models/product';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit {
  //input() property is a something we receive from our parent component 
  //output() property is to emit something from child component to parent component
@Input() pageSize:number=0;
@Input() pageNumber:number=0;
@Input() totalCount:number=0;
@Output() pageChanged = new EventEmitter<number>();
products: IProduct[] |any;
constructor() { }

  ngOnInit(): void {
  }
onPagerChanged(event:any)
{
this.pageChanged.emit(event);
}
}
