import { Component, OnInit } from '@angular/core';
import { helpData } from '../helpdata/helpdata';

@Component({
  selector: 'app-helppage',
  templateUrl: './helppage.page.html',
  styleUrls: ['./helppage.page.scss'],
})
export class HelppagePage implements OnInit {
searchTerm: string;
helpData: any[] = []
  constructor() { 
    Object.assign(this, {helpData})
  }

  ngOnInit() {
  }

}
