import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup } from '@angular/forms';
import { Validators,FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { DeliveryCompany } from 'src/models/deliverycompany';
import { DeliverycompanyService } from 'src/services/deliverycompany.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastController } from '@ionic/angular';
import { toastController } from '@ionic/core';


@Component({
  selector: 'app-deliveryadd',
  templateUrl: './deliveryadd.page.html',
  styleUrls: ['./deliveryadd.page.scss'],
})
export class DeliveryaddPage{
  DeliveryForm: FormGroup;

  constructor(private service: DeliverycompanyService, private formBuilder: FormBuilder,private router:Router, private toast: ToastController)
  {
    this.DeliveryForm = this.formBuilder.group({
      deliveryCompanyName:['',Validators.required],
      deliveryCompanyEmail:['',Validators.required],
      contactPersonName:['',Validators.required],
      deliveryCompanyBaseRate: ['',Validators.required],
      // method: ['',Validators.required]

    });
  }

  ngOnInit() {
  }

  addDelivery(){
    if(this.DeliveryForm.valid==true)
    {
    this.service.AddDelivery(this.DeliveryForm.value).subscribe(() =>{
      this.router.navigate(['./delivery']);
      this.presentToast();
    },
    (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }
       )};


  }


  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Sorry!This Delivery Company already exists.',
      duration: 2000
    });
    toast.present();
  }

  async presentToast(){
    const toast = await this.toast.create({
      message: 'Delivery Company Details Successfully Added!',
      duration:2000
    });
    toast.present();
  }

  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the delivery company to store in the database. You can view the delivery company details in the view page.',
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

  HomeBtn()
  {
    this.router.navigate(['./tabs/delivery']);
  }

  Info(){
    this.infoToast();
  }

}
