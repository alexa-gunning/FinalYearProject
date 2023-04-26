import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { async } from 'rxjs';
import { Client } from 'src/app/models/client';
import { otp } from 'src/app/models/otp';
import { ClientloginService } from 'src/app/services/clientlogin.service';

@Component({
  selector: 'app-otp',
  templateUrl: './otp.component.html',
  styleUrls: ['./otp.component.css']
})
export class OtpComponent  {

  user: otp = {
    userName: '',
    otp: ''
   }
  
    constructor(private router: Router, private service: ClientloginService, private fb: FormBuilder, private toast: ToastrService) {}
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
                this.router.navigate(['./products'])
            }, (response: HttpErrorResponse) => {
              if (response.status === 400) {
             this.presentErrorToast()
                // this.toast(response.error, 'X', {duration: 5000});
              }
            })  
        }
    
  }
  async presentErrorToast() {
    this.toast.error("Wrong OTP")
  }
  }
  
