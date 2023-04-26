import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup } from '@angular/forms';
import { Validators,FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastController } from '@ionic/angular';
import { Supplier } from 'src/models/supplier';
import { SupplierService } from 'src/app/services/supplierservice.service';

@Component({
  selector: 'app-addsupplier',
  templateUrl: './addsupplier.page.html',
  styleUrls: ['./addsupplier.page.scss'],
})
export class AddsupplierPage implements OnInit {

  SupplierForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private router:Router, private toast: ToastController, private service: SupplierService)
   {
    this.SupplierForm = this.formBuilder.group({
      supplierName:['',Validators.required],
      supplierPhoneNumber:['',Validators.required],
      supplierEmail:['',Validators.required],
      supplierAddress: ['',Validators.required]

    });

    }

  ngOnInit() {
  }

  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Sorry!This Supplier already exists.',
      duration: 2000
    });
    toast.present();
  }

  async presentToast(){
    const toast = await this.toast.create({
      message: 'Supplier Details Successfully Updated!',
      duration:2000
    });
    toast.present();
  }

  addSupplier(){
    if(this.SupplierForm.valid==true)
    {
    this.service.AddSupplier(this.SupplierForm.value).subscribe(() =>{
      this.router.navigate(['./tabs/supplier']);
      this.presentToast();
    },
    (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }
       )};


  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/supplier']);
  }

  Info(){
    this.infoToast();
  }

  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the supplier to store in the database. You can view the supplier details in the view page.',
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

}
