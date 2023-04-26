import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { LoginuserService } from 'src/app/services/loginuser.service';
import { otp } from 'src/models/otp';

@Component({
  selector: 'app-otp',
  templateUrl: './otp.page.html',
  styleUrls: ['./otp.page.scss'],
})
export class OtpPage  {

  user: otp = {
    userName: '',
    otp: ''
   }
    constructor(private router: Router, private service: LoginuserService, private fb: FormBuilder, private toast: ToastController) {}
    otpFormGroup:FormGroup = this.fb.group({
      Otp: ['', Validators.required],
     })
  SubmitOtp (){
    if (localStorage.getItem('Token'))
        {
          this.user = JSON.parse(localStorage.getItem('Token')!)
          this.user.otp = this.otpFormGroup.value['Otp']
          
            this.service.ValidateOtp(this.user).subscribe(() => {
              this.otpFormGroup.reset();
                this.router.navigate(['./tabs/wshome'])
            }, (response: HttpErrorResponse) => {
              if (response.status === 400) {
                this.presentErrorToast()
              }
            })  
        }
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Wrong OTP',
      duration: 2000,
      position: 'bottom'

    });
    toast.present();
  }
  }
