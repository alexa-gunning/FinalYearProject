/* eslint-disable @typescript-eslint/naming-convention */
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReasonService } from 'src/services/reason.service';
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
import { TouchSequence } from 'selenium-webdriver';
import { Hosts } from 'src/models/hosts';
import { HostService } from 'src/services/host.service';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-createwriteoff',
  templateUrl: './createwriteoff.page.html',
  styleUrls: ['./createwriteoff.page.scss'],
})
export class CreatewriteoffPage {
  ReasonForm: FormGroup;
  constructor(private service: ReasonService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.ReasonForm = this.formBuilder.group({
      writeOffReasonId: ['',Validators.required],
      writeOffReasonDescription:['',Validators.required]
     });
  }

  ngOnInit():void {
  }

  addReason(){
    if (this.ReasonForm.valid == true) {
    this.service.AddReason(this.ReasonForm.value).subscribe((res: any) =>{
    })
    this.router.navigate(['./writeoffinventoryitem'])
    this.presentToast()
  }
    else {
      return;
    }
  }

  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the Write-Off Reason to store in the database. You can view the Write-Off Reason in the View Write-Off Reason Page.',
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
      message: 'New write-off reason added.',
      duration: 2000
    });
    toast.present();
  }

  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This write-off reason already exists.',
      duration: 2000
    });
    toast.present();
  }

 
}
