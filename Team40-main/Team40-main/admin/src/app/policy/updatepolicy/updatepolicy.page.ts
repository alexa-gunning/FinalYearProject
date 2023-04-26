import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Policy } from 'src/models/policy';
import { PolicyService } from 'src/services/policy.service';

@Component({
  selector: 'app-updatepolicy',
  templateUrl: './updatepolicy.page.html',
  styleUrls: ['./updatepolicy.page.scss'],
})
export class UpdatepolicyPage {

  Item: Policy[]
  item: any;
  res: string;
  uPolicyForm: FormGroup;
  constructor(private service: PolicyService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uPolicyForm = this.formBuilder.group({
      policyName: ['',Validators.required],
      description:['',Validators.required],
      date:['',Validators.required]
     });
  }
  ionViewWillEnter(): void {
    var policyId = JSON.parse(localStorage.getItem("policyId"))
    this.res = '';
    this.service.GetPolicyByID(policyId).subscribe((res: any)  =>{
     this.item = res;
    console.log(this.item);

    }); }

  HomeBtn()
  {
    this.router.navigate(['./tabs/policy']);
  }

  updateInventory: Policy;
  Update(){


    var policyId = JSON.parse(localStorage.getItem("policyId"))
    if(this.uPolicyForm.valid == true){
    this.service.UpdatePolicy(policyId, this.uPolicyForm.value).subscribe((res: any) =>{
      this.router.navigate(['./tabs/policy']);
      this.presentToast();
    }), (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }

  }
  else{
  return;
  }}
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This policy already exists.',
      duration: 2000
    });
    toast.present();
  }

  async presentToast() {
  const toast = await this.toast.create({
    message: 'Policy updated.',
    duration: 2000
  });
  toast.present();
  }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the policy you would like to update.',
      duration:5000,
      cssClass: 'custom-toast',
        buttons: [
          {
            text: 'Dismiss',
            role: 'cancel'
          }
        ],
    });
    toast.present();

  }
  }
