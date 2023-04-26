import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Client } from '../models/client';
import { ClientloginService } from '../services/clientlogin.service';

@Component({
  selector: 'app-workshop',
  templateUrl: './workshop.component.html',
  styleUrls: ['./workshop.component.css']
})
export class WorkshopComponent implements OnInit {
  res: string | undefined;
  item!: Client[];
 email: any;
 
  constructor(private router: Router, private cservice: ClientloginService) { }
 
  ngOnInit(): void {
    this.email= JSON.parse(localStorage.getItem("Token")!);
    console.log(this.email.userName);
    this.res = '';
    this.cservice.GetClientID(this.email.userName).subscribe((res: any)  =>{
     this.item = res;
    //  this.item.clientId = res.clientId
    console.log(res); 
  })}
Makebooking(clientId: any){
  localStorage.setItem("clientId" , JSON.stringify(clientId));
  console.log(JSON.parse(localStorage.getItem("clientId")!));
  this.router.navigate(['./makebooking']);
}
}
