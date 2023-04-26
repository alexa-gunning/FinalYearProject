import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { WorkshopService } from 'src/services/workshop.service';
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
//look at the addvenuemodule.ts for imports and run npm i @ionic/lab --save-dev in terminal
@Component({
  selector: 'app-addvenue',
  templateUrl: './addvenue.page.html',
  styleUrls: ['./addvenue.page.scss'],
})
export class AddvenuePage {
  VenueForm: FormGroup;
  constructor(private service: WorkshopService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.VenueForm = this.formBuilder.group({
      venueName: ['',Validators.required],
      address:['',Validators.required]
     });
  }


  ngOnInit():void {
  }
  addVenue(){
    if(this.VenueForm.valid == true){
    this.service.AddWorkshopVenue(this.VenueForm.value).subscribe(() =>{
      this.router.navigate(['./venue']);
      this.presentToast();
    }  , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }
    )

  }
else{
  return;
}}


  async presentToast() {
    const toast = await this.toast.create({
      message: 'New venue added.',
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
Info(){
  this.infoToast();
}
async infoToast(){
  const toast = await this.toast.create({
    message: 'Please enter the details of the venue to store in the database. You can view the venues in the view page.',
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
  this.router.navigate(['./tabs/wshome']);
}

}
