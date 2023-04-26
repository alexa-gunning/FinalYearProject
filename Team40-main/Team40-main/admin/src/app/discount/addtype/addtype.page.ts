import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { DiscountsService } from 'src/services/discounts.service';

@Component({
  selector: 'app-addtype',
  templateUrl: './addtype.page.html',
  styleUrls: ['./addtype.page.scss'],
})
export class AddtypePage {

TypeForm: FormGroup;
  constructor(private service: DiscountsService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.TypeForm = this.formBuilder.group({
      percentage: ['',Validators.required],

     });
  }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the percentage you would like to add.',
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


  addItem(){
    if (this.TypeForm.valid == true) {
    this.service.AddType(this.TypeForm.value).subscribe(() =>{
      this.router.navigate(['./creatediscount']);
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
      message: 'New percentage added.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This percentage already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./creatediscount']);
  }

}
