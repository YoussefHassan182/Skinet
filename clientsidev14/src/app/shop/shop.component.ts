import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/models/product';
import { IBrand } from '../shared/models/brands';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
@ViewChild('search',{static:true}) searchTerm:ElementRef|any;
  totalCount :number =0;
   //pageNumber=0;
  // p: number = 1;
  p: number = 1;
  collection: any[] |any;
  products: IProduct[] |any;
  brands:IBrand[] =[];
  types:IType[]=[];
shopParams = new ShopParams();
  sortOptions=
  [
{name:'Alphabatical',value:'name'},
{name:'Price: Low to High',value:'priceAsc'},
{name:'Price: Hight to Low',value:'priceDesc'}
  ]
  constructor(private shopServices: ShopService) { }
  ngOnInit(): void {
   this.getProducts();
   this.getBrands();
   this.getTypes();

  }
  getProducts(){
   return  this.shopServices.getProducts(this.shopParams)
    .subscribe((response)=>{
      debugger;
      this.products=response?.data;
      this.totalCount = response?.count??0;
      this.shopParams.pageNumber = response?.pageIndex??0;
      this.collection = response?.data;
this.shopParams.pageSize= response?.pageSize??0;
    },err=>{
      console.log(err);
    })
  }
  getBrands(){
    return  this.shopServices.getBrands()
     .subscribe((response)=>{
       this.brands=[{id:0,name:'All'},...response];
     },err=>{
       console.log(err);
     })
   }
   getTypes(){
    return  this.shopServices.getTypes()
     .subscribe((response)=>{
       this.types=[{id:0,name:'All'},...response];
     },err=>{
       console.log(err);
     })
   }
   onBrandSelected(brandId:number){
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber =1;
this.getProducts();
  }
  onTypeSelected(typeId:number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber =1;
this.getProducts();
  }
  onSortSelected(sort:string) {
   // const selectElement = event.target as HTMLSelectElement;
   // const sort = selectElement.value??'';
    this.shopParams.sort = sort;
    this.getProducts();
  }
  // onSortSelected2(event?: Event) {
  //   const selectElement = event?.target as HTMLSelectElement;
  //   const sort = selectElement.value;
  //   this.sortSelected = sort;
  //   this.getProducts();
  // }
onPageChanged(event:any)
{
  if (this.shopParams.pageNumber!==event) {
    

  this.shopParams.pageNumber = event;
this.getProducts();
  }
}
onSearch()
{
  this.shopParams.search  = this.searchTerm?.nativeElement.value;
  this.shopParams.pageNumber =1;
  this.getProducts();
}
onReset()
{
  this.searchTerm.nativeElement.value = '';
this.shopParams = new ShopParams();
this.getProducts();
}
}