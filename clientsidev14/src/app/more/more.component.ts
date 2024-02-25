import { Component, OnInit } from '@angular/core';
import { PopupComponent } from '../popup/popup.component';

@Component({
  selector: 'app-more',
  templateUrl: './more.component.html',
  styleUrls: ['./more.component.css']
})

export class MoreComponent implements OnInit {

  constructor(private popupComponent: PopupComponent) { }

     openPopup() {
       this.popupComponent.showDialog('');
     }
  ngOnInit(): void {
  }

}
