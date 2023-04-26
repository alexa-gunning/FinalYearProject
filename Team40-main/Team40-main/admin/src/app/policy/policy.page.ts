import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';

import { Policy } from 'src/models/policy';
import { PolicyService } from 'src/services/policy.service';


@Component({
  selector: 'app-policy',
  templateUrl: './policy.page.html',
  styleUrls: ['./policy.page.scss'],
})
export class PolicyPage {

  searchTerm: string;
  items: Policy[];

  constructor(private router: Router, private service: PolicyService, private toast: ToastController) {

   }

  ionViewWillEnter(): void {
    this.items = [];
    this.service.GetAllPolicies().subscribe(res =>{
    var items = res as any[]
    for(var i = 0; i < items.length; i++){
      var Item = new Policy();
      Item.policyId = res[i].policyId;
      Item.policyName= res[i].policyName;
      Item.description= res[i].description;
      Item.date= res[i].date;
      this.items.push(Item);
      
    }
    });

      }
      Update(policyId){
        localStorage.setItem("policyId" , JSON.stringify(policyId));
        console.log(JSON.parse(localStorage.getItem("policyId")))
        this.router.navigate(['./updatepolicy']);
      }
  AddBtn(){
    this.router.navigate(['./addpolicy']);
  }
  Delete(policyId: any){
  
    this.service.DeletePolicyPost(policyId).subscribe(res =>{
 
    
    });
    this.presentToast();
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Policy deleted.',
      duration: 2000
    });
    toast.present();
    }
  HomeBtn()
  {
    this.router.navigate(['./tabs/policy']);
  }

}
