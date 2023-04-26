import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Venue } from 'src/models/venue';
import { WorkshopService } from 'src/services/workshop.service';

@Component({
  selector: 'app-updatevenue',
  templateUrl: './updatevenue.page.html',
  styleUrls: ['./updatevenue.page.scss'],
})
export class UpdatevenuePage {
  Venues: Venue[]
  Ven: any;
  uVenueForm: FormGroup;
  res: string;

  constructor(private service: WorkshopService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uVenueForm = this.formBuilder.group({
      venueName: ['',Validators.required],
        address:['' ,Validators.required]
     });

  }

  ionViewWillEnter(): void {
    var workshopVenueId = JSON.parse(localStorage.getItem("workshopVenueId"))
    this.res = '';
    this.service.GetWorkshopVenueByID(workshopVenueId).subscribe((res: any)  =>{
     this.Ven = res;
    console.log(this.Ven);

    }); }

    Info(){
      this.infoToast();
    }
    async infoToast(){
      const toast = await this.toast.create({
        message: 'Please enter the details of the venue you would like to update. Change the venue name.',
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
    this.router.navigate(['./tabs/venue']);
  }
  updateVenue: Venue;
  Update(){


    var workshopVenueId = JSON.parse(localStorage.getItem("workshopVenueId"))
    if(this.uVenueForm.valid == true){
    this.service.UpdateWorkshopVenue(workshopVenueId, this.uVenueForm.value).subscribe((res: any) =>{
      this.router.navigate(['./venue']);
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
    message: 'Venue updated.',
    duration: 2000
  });
  toast.present();
}
async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'This venue already exists.',
    duration: 2000
  });
  toast.present();
}
}
