import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Observable } from '@mobiscroll/angular-lite/src/js/util/observable';
import { type } from 'os';
import { DiscountStatuses } from 'src/models/discountstatuses';
import { DiscountTypes } from 'src/models/discounttypes';
import { DiscountsService } from 'src/services/discounts.service';

@Component({
  selector: 'app-creatediscount',
  templateUrl: './creatediscount.page.html',
  styleUrls: ['./creatediscount.page.scss'],
})
export class CreatediscountPage  {
  types: DiscountTypes[];
  statuses: DiscountStatuses[];
DiscountForm: FormGroup;
selected: any;
  constructor(private service: DiscountsService, private router: Router, private toast: ToastController, private formBuilder:FormBuilder) {

  this.DiscountForm = this.formBuilder.group({
    discountDescription: ['',Validators.required],
    discountTypeId:['',Validators.required],
    discountStatusId:['',Validators.required]
   });
  }
  ionViewWillEnter(): void {

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

  }

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
addDiscount(){
  if (this.DiscountForm.valid == true) {
    this.service.AddDiscount(this.DiscountForm.value).subscribe(() =>{
      this.router.navigate(['./tabs/discount']);
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
    message: 'New discount added.',
    duration: 2000
  });
  toast.present();
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
