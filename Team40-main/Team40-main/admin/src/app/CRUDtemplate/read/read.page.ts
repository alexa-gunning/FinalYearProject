import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-read',
  templateUrl: './read.page.html',
  styleUrls: ['./read.page.scss'],
})
export class ReadPage implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }
  AddBtn(){
    this.router.navigate(['./add']);
  }
  Update(){
    this.router.navigate(['./update']);
  }

}
