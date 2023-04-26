import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup } from '@angular/forms';
import { Validators,FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastController } from '@ionic/angular';
import { toastController } from '@ionic/core';
import { User } from 'src/models/user';
import { RegisterService } from 'src/app/services/register.service';
 
@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {

  UserForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private router:Router, private toast: ToastController, private service: RegisterService) 
  {
    this.UserForm= this.formBuilder.group({
      userName: ['',Validators.required],
      password: ['', Validators.required]
    });
   }

  ngOnInit() { 
  }

  registerUser(){
    if(this.UserForm.valid == true)
    {
      this.service.RegisterUser(this.UserForm.value).subscribe(()=>{
        this.router.navigate(['./login']);
      this.presentToast();
      },(response: HttpErrorResponse) =>{
        if(response.status===403)
        {
          this.presentErrorToast();
        }
      }
      
    )};
  }

  async presentToast(){
    const toast = await this.toast.create({
      message: 'User Successfully Registered',
      duration:2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Sorry! User Details Already Exist',
      duration: 2000,
      position: 'middle'

    });
    toast.present();
  }

  Cancel(){
    this.router.navigate(['./login']);
  }

}
