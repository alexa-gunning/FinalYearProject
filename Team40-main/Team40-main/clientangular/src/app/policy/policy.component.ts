import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Policy } from '../models/policy';
import { PolicyService } from '../services/policy.service';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.css']
})
export class PolicyComponent implements OnInit{

  items!: Policy[];

  constructor(private router: Router, private service: PolicyService, private toast: ToastrService) {

   }
  ngOnInit(): void {
    // this.items = [];
    this.service.GetAllPolicies().subscribe((res) =>{
    // var items = res as any[]
    // for(var i = 0; i < items.length; i++){
    //   var Item = new Policy();
    //   Item.policyId = res[i].policyId;
    //   Item.policyName= res[i].policyName;
    //   Item.description= res[i].description;
    //   Item.date= res[i].date;
    //   this.items.push(Item);
    this.items = res;
    // }
    })
  }

  // ngOnInIt(): void {
  //   this.items = [];
  //   this.service.GetAllPolicies().subscribe(res =>{
  //   var items = res as any[]
  //   for(var i = 0; i < items.length; i++){
  //     var Item = new Policy();
  //     Item.policyId = res[i].policyId;
  //     Item.policyName= res[i].policyName;
  //     Item.description= res[i].description;
  //     Item.date= res[i].date;
  //     this.items.push(Item);

  //   }
  //   });
  // }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    // const toast = await this.toast.create({
    //   message: 'View the Resin Art by Paige policy to know more about the rules of the business.',
    //   duration:5000,
    //   cssClass: 'custom-toast',
    //     buttons: [
    //       {
    //         text: 'Dismiss',
    //         role: 'cancel'
    //       }
    //     ],
    // });
    // toast.present();
  }
}