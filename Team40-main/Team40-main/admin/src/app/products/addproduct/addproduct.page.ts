import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { WindowScrollController } from '@fullcalendar/angular';
import { ToastController } from '@ionic/angular';
import { DiscountStatuses } from 'src/models/discountstatuses';
import { DiscountTypes } from 'src/models/discounttypes';
import { ProductColors } from 'src/models/productcolors';
import { ProductTypes } from 'src/models/producttypes';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.page.html',
  styleUrls: ['./addproduct.page.scss'],
}) 
export class AddproductPage  {

  colors: ProductColors[];
  types: ProductTypes[];
ProductForm: FormGroup;
selected: any;
  constructor(private service: ProductService, private router: Router, private toast: ToastController, private formBuilder:FormBuilder) { 

  this.ProductForm = this.formBuilder.group({
   productName: ['',Validators.required],
    productTypeId:['',Validators.required],
    productColourId:['',Validators.required],
    price:['',Validators.required],
    quantityOnHand:['',Validators.required],
   });
  }
  ionViewWillEnter(): void {
   
    this.types = [];
    this.service.GetTypes().subscribe(res =>{
    var types = res as any[]
    for(var i = 0; i <types.length; i++){
      var Item = new ProductTypes();
      Item.description = res[i].description;
      Item.productTypeId = res[i].productTypeId;
      Item.productTypeName= res[i].productTypeName;
      this.types.push(Item);
      console.log(Item)
    }
    });

    this.colors = [];
    this.service.GetColors().subscribe(res =>{
    var colors = res as any[]
    for(var i = 0; i <colors.length; i++){
      var Item = new ProductColors();
      Item.description = res[i].description;
      Item.productColorId = res[i].productColorId;
      Item.colorName = res[i].colorName;
      this.colors.push(Item);
      console.log(Item)
    }
    });

  }

  Info(){
    this.infoToast(); 
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the product to store in the database. Add the price under "Manage prices" and then you can view the product in the view page.',
      duration:5000
    });
    toast.present();
}
HomeBtn()
{
  this.router.navigate(['./tabs/products']);
}
type()
{
  this.router.navigate(['./addprodtype']);
}
color()
{
  this.router.navigate(['./addcolor']);
}
addProduct(){
  if (this.ProductForm.valid == true) {
    this.service.AddProduct(this.ProductForm.value).subscribe(() =>{
      this.router.navigate(['./tabs/products']);
      
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
    message: 'New product added.',
    duration: 2000
  });
  toast.present();
}
async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'This product already exists.',
    duration: 2000
  });
  toast.present();
}

}
