import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ProductService } from 'src/services/product.service';
import { Location } from '@angular/common';
@Component({
  selector: 'app-addcolor',
  templateUrl: './addcolor.page.html',
  styleUrls: ['./addcolor.page.scss'],
})
export class AddcolorPage  {
  ProductColorForm: FormGroup;
  constructor(private service: ProductService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController, private location: Location) {
    this.ProductColorForm = this.formBuilder.group({
      colorName: ['',Validators.required],
     description:['',Validators.required],
      
     });
  }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the color to store in the database. You can then go and select it when adding a product.',
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



  addColor(){
    if (this.ProductColorForm.valid == true) {
    this.service.AddColor(this.ProductColorForm.value).subscribe(() =>{
      // this.router.navigate(['./addproduct']);
      this.location.back()
      this.presentToast()
    } , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       })


  }
    else {
      return;
    }
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'New color added.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This color already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/products']);
  }

}
