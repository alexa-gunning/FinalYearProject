import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ClientloginService } from 'src/app/services/clientlogin.service';
import { RegisterService } from 'src/app/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  res: string | undefined;
  item: any;
 email: any;
  form: FormGroup ;
clientId: any;
  constructor(private router: Router, private formBuilder: FormBuilder , private toast: ToastrService, 
    private service: ClientloginService, private rservice: RegisterService) 
  {
    this.form = this.formBuilder.group({
      userName: ['',[Validators.required, Validators.email]],
      password: ['',Validators.required],
      name: ['',Validators.required],
      surname: ['',Validators.required],
      phoneNumber: ['',Validators.required],
      birthDate: ['',Validators.required],
    })
   }
  ngOnInit(): void {

  }
Signup(){
  this.rservice.RegisterUser(this.form.value).subscribe(res=>{
    this.router.navigate(['./login'])
    this.success()
  }),(response: HttpErrorResponse) =>{
    this.error()
  }
}
success(){
  this.toast.success("Registered sucessfully.")
}
error(){
  this.toast.success("User already exists.")
}
}
