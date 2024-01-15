import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IProduct } from './shared/models/product';
import { IPagination } from './shared/models/Pagination';
import { ShopService } from './shop/shop.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Ski-Net';
  constructor()
  {
  }
  ngOnInit(): void { 
    //called one after ngDoChanges
  }
}
