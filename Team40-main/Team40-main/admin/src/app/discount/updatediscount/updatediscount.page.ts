import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { DiscountRequest } from 'src/models/discountrequest';

import { DiscountStatuses } from 'src/models/discountstatuses';
import { DiscountTypes } from 'src/models/discounttypes';
import { DiscountsService } from 'src/services/discounts.service'; 

@Component({
  selector: 'app-updatediscount',
  templateUrl: './updatediscount.page.html',
  styleUrls: ['./updatediscount.page.scss'],
})
export class UpdatediscountPage {
  Discount: DiscountRequest[]
  Discount_: any;
  res: string;
  types: DiscountTypes[];
  statuses: DiscountStatuses[];
uDiscountForm: FormGroup;
selected: any;
  constructor(private service: DiscountsService, private router: Router, private toast: ToastController, private formBuilder:FormBuilder) {

  this.uDiscountForm = this.formBuilder.group({
    discountDescription: ['',Validators.required],
    discountTypeId:['',Validators.required],
    discountStatusId:['',Validators.required]
   });

}
ionViewWillEnter(): void {
  var discountId = JSON.parse(localStorage.getItem("discountId"))
  this.res = '';
  this.service.GetDiscountByID(discountId).subscribe((res: any)  =>{
   this.Discount_ = res;
  console.log(this.Discount_);

  this.types = [];
  this.service.GetTypes().subscribe(res =>{
  var types = res as any[]
  for(var i = 0; i <types.length; i++){
    var Item = new DiscountTypes();
    Item.description = res[i].description;
    Item.discountTypeId = res[i].discountTypeId;
    Item.percentage= res[i].percentage;
    this.types.push(Item);
    console.log(Item)
  }
  });

  this.statuses = [];
  this.service.GetStatuses().subscribe(res =>{
  var statuses = res as any[]
  for(var i = 0; i <statuses.length; i++){
    var Item = new DiscountStatuses();
    Item.description = res[i].description;
    Item.discountStatusId = res[i].discountStatusId;
    this.statuses.push(Item);
    console.log(Item)
  }
  });

  }); }

Info(){
  this.infoToast();
}

async infoToast(){
  const toast = await this.toast.create({
    message: 'Please enter the details of the item to store in the database. You can view the items in the view page.',
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
  this.router.navigate(['./tabs/discount']);
  }
  updateHost: DiscountRequest;
  Update(){
    var discountId = JSON.parse(localStorage.getItem("discountId"))
    if(this.uDiscountForm.valid == true){
    this.service.UpdateDiscount(discountId, this.uDiscountForm.value).subscribe(() =>{
      this.router.navigate(['./tabs/discount']);
      this.presentToast()
    }  , (response: HttpErrorResponse) => {
      this.presentErrorToast();
      })
    }
      else {
      return;
    }
  }

async presentToast() {
  const toast = await this.toast.create({
    message: 'Discount updated.',
    duration: 2000
  });
  toast.present();
  window.location.reload();
  }

async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'This discount already exists.',
    duration: 2000
  });
  toast.present();
}
type(){
  this.router.navigate(['./adddiscounttype']);
}
}
