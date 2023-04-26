import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { LoginuserService } from 'src/app/services/loginuser.service';
import { ForgotpasswordPageForm } from './forgotpassword.page.form';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.page.html',
  styleUrls: ['./forgotpassword.page.scss'],
})
export class ForgotpasswordPage implements OnInit {

  form: FormGroup ;
  constructor(private router: Router, private formBuilder: FormBuilder , private service: LoginuserService, private toast: ToastController) 
  {
    this.form = this.formBuilder.group({
      userName: ['',[Validators.required, Validators.email]],
      // password: ['',Validators.required]
    })

   }

  ngOnInit() {
    this.form=new ForgotpasswordPageForm(this.formBuilder).createForm();
  }

  //Should I pass the two parameters or the model
  /*LoginUser(){

    if(this.form.valid)
    {
      this.service.LoginUser(this.form.value).subscribe(()=>{
        console.log('Logged IN')
       

      },
      (response: HttpErrorResponse) => {
        this.presentErrorToast();
         }
         )};
    
  
  }*/

  Login(){
    this.service.ForgotPassword(this.form.value).subscribe(result =>{
      localStorage.setItem('Token', JSON.stringify(result))
      console.log('logged in')
      this.router.navigate(['./otp']);
  },(response: HttpErrorResponse) =>{
    if(response.status===404)
    {
      this.presentErrorToast();
    }
  }
)};
  

  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Sorry! User Details Do Not Exist',
      duration: 2000
    });
    toast.present();
  }

 

}
