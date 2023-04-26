import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ProductTypes } from 'src/models/producttypes';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-utype',
  templateUrl: './utype.page.html',
  styleUrls: ['./utype.page.scss'],
})
export class UtypePage implements OnInit {
  res: string;
  uTypeForm: FormGroup;
  item: ProductTypes[];
  constructor(private service: ProductService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uTypeForm = this.formBuilder.group({
      productTypeName: ['',Validators.required],
     description:['',Validators.required],
      
     });
  }
  ngOnInit(): void {
    var productTypeId = JSON.parse(localStorage.getItem("productTypeId"))
    this.res = '';
    this.service.GetTypeByID(productTypeId).subscribe((res: any)  =>{
     this.item = res;
    console.log(this.item);
       }   )
  }
  // IonViewWillEnter(): void {
  //   var productColorId = JSON.parse(localStorage.getItem("productColorId"))
  //   this.res = '';
  //   this.service.GetColorByID(productColorId).subscribe((res: any)  =>{
  //    this.item = res;
  //   console.log(this.item);
  //      }   ) }



  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the type you want to update to store in the database. You can then go and select it when adding a product.',
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


update(){


  var productTypeId = JSON.parse(localStorage.getItem("productTypeId"))
  if(this.uTypeForm.valid == true){
  this.service.UpdateType(productTypeId, this.uTypeForm.value).subscribe((res: any) =>{
    this.router.navigate(['./mgtype']);
    this.presentToast();
  }), (response: HttpErrorResponse) => {
    this.presentErrorToast();
     }

}
else{
return;
}}

  

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Type Updated.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This type already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./mgtype']);
  }

}
