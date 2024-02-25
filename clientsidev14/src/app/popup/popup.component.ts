import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  display: boolean = false;

  showDialog(event:any) {
    this.display = true;
    console.log(event);
    
    
  }

  closePopup() {
    this.display = false;
  }
}
