import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Hosts } from 'src/models/hosts';
import { HostService } from 'src/services/host.service';

@Component({
  selector: 'app-updatehost',
  templateUrl: './updatehost.page.html',
  styleUrls: ['./updatehost.page.scss'],
})
export class UpdatehostPage  {
  Host: Hosts[]
  Host_: any;
  res: string;
  uHostForm: FormGroup;
  constructor(private service: HostService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uHostForm = this.formBuilder.group({
      hostName: ['',Validators.required],
      hostSurname:['',Validators.required],
      hostEmail:['',[Validators.required, Validators.email]]
     });
  }

  ionViewWillEnter(): void {
    var hostId = JSON.parse(localStorage.getItem("hostId"))
    this.res = '';
    this.service.GetHostByID(hostId).subscribe((res: any)  =>{
     this.Host_ = res;
    console.log(this.Host_);

    }); }
    Info(){
      this.infoToast();
    }
    async infoToast(){
      const toast = await this.toast.create({
        message: 'Please enter the details of the host you would like to update. Change the host name.',
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
updateHost: Hosts;
Update(){


  var hostId = JSON.parse(localStorage.getItem("hostId"))
  if(this.uHostForm.valid == true){
  this.service.UpdateHost(hostId, this.uHostForm.value).subscribe(() =>{
    this.router.navigate(['./tabs/host']);
    this.presentToast()
  }  , (response: HttpErrorResponse) => {
    this.presentErrorToast();
     })

  }
    else{
    return;
  }

}

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Host updated.',
      duration: 2000
    });
    toast.present();
    window.location.reload();
    }

  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This host already exists.',
      duration: 2000
    });
    toast.present();
  }
}
