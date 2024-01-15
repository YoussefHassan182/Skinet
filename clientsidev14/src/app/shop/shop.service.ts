import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/Pagination';
import { map } from 'rxjs';
import { IBrand } from '../shared/models/brands';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
//injectable decorator means this service can be injjected
@Injectable({ 
    //configuration about where this service provided in
    //our app module is our root module of our application 
    //and this is the module that responsible for bootstraping and initializing our app
//angular services is considered as singelton and initialize when app starts
  providedIn: 'root' 
})
export class ShopService {
baseUrl = "https://localhost:5001/api/";
  constructor(private http:HttpClient) { }
  getProducts(shopParams:ShopParams){
    let params = new HttpParams();
    if (shopParams.brandId !==0) 
    {
      params = params.append('brandId',shopParams.brandId);
    }
    if (shopParams.typeId !==0)
    {
      params = params.append('typeId',shopParams.typeId);
    }
    if (shopParams.search) {
      params = params.append('search',shopParams.search);
    }
      params = params.append('sort',shopParams.sort);
    params = params.append('pageIndex',shopParams.pageNumber);
    params = params.append('pageSize',shopParams.pageSize);

    return this.http.get<IPagination>
    (this.baseUrl + "products/products",{observe:'response',params})
    //because we are observing on a response this will give us http response 
    //instead of the body of the response
    //we need to project this data to actual response and extract the body out of this
    //we can manipulate this observable and project it to an IPagination Object
    //so we can get the body of the response and project it to IPagination Object
    //and to do this we need rxjs methods and to use them we need to use pipe the response to something
    .pipe //as a wrapper of rxjs methods and inside it we can chain any rxjs operators as we want
(
map(response=>
{
    return response.body;
})
)
}
  getBrands()
  {
   return this.http.get<IBrand[]>(this.baseUrl+"products/brands");
  }
  getTypes()
  {
  return  this.http.get<IType[]>(this.baseUrl+"products/types");
  }
}