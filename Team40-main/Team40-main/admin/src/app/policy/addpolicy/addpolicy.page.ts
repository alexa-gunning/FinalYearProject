import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { PolicyService } from 'src/services/policy.service';

@Component({
  selector: 'app-addpolicy',
  templateUrl: './addpolicy.page.html',
  styleUrls: ['./addpolicy.page.scss'],
})
export class AddpolicyPage  {

  PolicyForm: FormGroup;
  constructor(private service: PolicyService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.PolicyForm = this.formBuilder.group({
      policyName: ['',Validators.required],
      description:['',Validators.required],
      date:['',Validators.required]
     });
  }


getDate(){
  const date = new Date();
  date.toLocaleString("en-GB");
  console.log(date);
  return date;
}

  addItem(){
    if (this.PolicyForm.valid == true) {
    this.service.AddPolicy(this.PolicyForm.value).subscribe(() =>{
      this.router.navigate(['./policy']);
      this.presentToast()
    } , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       })


  }
    else {
      return;
    }
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'New policy added.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Only one policy can be added.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./policy']);
  }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the policy to store in the database. You can view the policy in the view page. Only one policy may be added.',
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

