import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TouchSequence } from 'selenium-webdriver';
import { Hosts } from 'src/models/hosts';
import { HostService } from 'src/services/host.service';
import { ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-addhost',
  templateUrl: './addhost.page.html',
  styleUrls: ['./addhost.page.scss'],
})

export class AddhostPage{
  HostForm: FormGroup;
  constructor(private service: HostService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.HostForm = this.formBuilder.group({
      hostName: ['',Validators.required],
      hostSurname:['',Validators.required],
      hostEmail:['',[Validators.required, Validators.email]]
     });
  }


  ngOnInit():void { }

  addHost(){
    if (this.HostForm.valid == true){
    this.service.AddHost(this.HostForm.value).subscribe(() =>{
      this.router.navigate(['./host']);
        this.presentToast();
      }
     , (response: HttpErrorResponse) => {
    this.presentErrorToast();
     }
     )}
  }

  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the host to store in the database. You can view the hosts in the view page.',
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
async presentToast() {
  const toast = await this.toast.create({
    message: 'New host added.',
    duration: 2000
  });
  toast.present();
}
async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'This host already exists.',
    duration: 2000
  });
  toast.present();
}

HomeBtn()
{
  this.router.navigate(['./tabs/host']);
}

}

