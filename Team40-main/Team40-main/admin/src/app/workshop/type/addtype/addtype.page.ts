import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { WorkshopService } from 'src/services/workshop.service';
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-addtype',
  templateUrl: './addtype.page.html',
  styleUrls: ['./addtype.page.scss'],
})
export class AddtypePage implements OnInit {
  TypeForm: FormGroup;
  constructor(private service: WorkshopService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.TypeForm = this.formBuilder.group({
    description: ['',Validators.required]
     });
  }


  ngOnInit():void {
  }
  addType(){
    if(this.TypeForm.valid == true){
    this.service.AddWorkshopType(this.TypeForm.value).subscribe(() =>{
      this.router.navigate(['./tabs/type']);
   
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
      message: 'New type added.',
      duration: 2000
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

HomeBtn()
{
  this.router.navigate(['./tabs/wshome']);
}
Info(){
  this.infoToast();
}
async infoToast(){
  const toast = await this.toast.create({
    message: 'Please enter the details of the type to store in the database. You can view the types in the view page.',
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

