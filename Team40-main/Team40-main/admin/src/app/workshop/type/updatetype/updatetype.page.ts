import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
// import { Venue } from 'src/models/venue';
import { Type } from 'src/models/workhoptype';
import { WorkshopService } from 'src/services/workshop.service';


@Component({
  selector: 'app-updatetype',
  templateUrl: './updatetype.page.html',
  styleUrls: ['./updatetype.page.scss'],
})
export class UpdatetypePage {

  Venues: Type[]
  Ven: any;
  uTypeForm: FormGroup;
  res: string;

  constructor(private service: WorkshopService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uTypeForm = this.formBuilder.group({
   description: ['',Validators.required],

     });

  }

  ionViewWillEnter(): void {
    var workshopTypeId = JSON.parse(localStorage.getItem("workshopTypeId"))
    this.res = '';
    this.service.GetWorkshopTypeByID(workshopTypeId).subscribe((res: any)  =>{
     this.Ven = res;
    console.log(this.Ven);

    }); }


  HomeBtn()
  {
    this.router.navigate(['./tabs/type']);
  }
  updateVenue: Type;
  Update(){


    var workshopTypeId = JSON.parse(localStorage.getItem("workshopTypeId"))
    if(this.uTypeForm.valid == true){
    this.service.UpdateWorkshopType(workshopTypeId, this.uTypeForm.value).subscribe((res: any) =>{
      this.router.navigate(['./type']);
      this.presentToast()
    })
    , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }
  }
else{
  return;
}}


async presentToast() {
  const toast = await this.toast.create({
    message: 'Type updated.',
    duration: 2000
  });
  toast.present();
}
Info(){
  this.infoToast();
}
async infoToast(){
  const toast = await this.toast.create({
    message: 'Please enter the details of the type you would like to update. Change the type description.',
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
async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'This type already exists.',
    duration: 2000
  });
  toast.present();
}
}
