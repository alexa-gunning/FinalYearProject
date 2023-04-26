import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ClientloginService } from '../services/clientlogin.service';
import { ReactiveFormsModule } from '@angular/forms';
import { Client } from '../models/client';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  res: string | undefined;
  item: any;
 email: any;
  form: FormGroup ;
clientId: any;
  constructor(private router: Router, private formBuilder: FormBuilder , private toast: ToastrService, private service: ClientloginService) 
  {
    this.form = this.formBuilder.group({
      userName: ['',[Validators.required, Validators.email]],
      password: ['',Validators.required]
    })
   }

  ngOnInit() {
   
  }

  Login(){
    this.service.Login(this.form.value).subscribe(result =>{
      localStorage.setItem('Token', JSON.stringify(result))
     
      console.log('logged in')
      this.router.navigate(['./otp']);
  },(response: HttpErrorResponse) =>{
    if(response.status===404)
    {
      this.presentErrorToast();
    }
  })
  // this.email= JSON.parse(localStorage.getItem("Token")!);
  //     console.log(this.email.userName);
  //     this.res = '';
 
}

  async presentErrorToast() {
   this.toast.error("User details do not exist")

  }
  SignUp(){
    this.router.navigate(['./register']);
  }
  Forgot(){
    this.router.navigate(['./forgotpassword']);
  }
}