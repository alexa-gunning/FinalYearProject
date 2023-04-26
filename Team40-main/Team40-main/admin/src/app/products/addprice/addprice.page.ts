import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { AddProduct } from 'src/models/addproduct';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-addprice',
  templateUrl: './addprice.page.html',
  styleUrls: ['./addprice.page.scss'],
})
export class AddpricePage {
  products: AddProduct[]
  ProductPriceForm: FormGroup;
  constructor(private service: ProductService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.ProductPriceForm = this.formBuilder.group({
      productPrice1: ['',Validators.required],
    productId:['',Validators.required],
     });
  }
 
  ionViewWillEnter(): void {
   
    this.products = [];
    this.service.GetJustProducts().subscribe(res =>{
    var types = res as any[]
    for(var i = 0; i <types.length; i++){
      var Item = new AddProduct();
      Item.productId = res[i].productId;
      Item.productName= res[i].productName;
      this.products.push(Item);
      console.log(Item)
    }
    });}


  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please select the product and then enter the price you would like to add. You can then view the product on the view page.',
      duration:5000
    });
    toast.present();
}


  addItem(){
    if (this.ProductPriceForm.valid == true) {
    this.service.AddProductPrice(this.ProductPriceForm.value).subscribe(() =>{
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
      message: 'New price added.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This price already exists.',
      duration: 2000
    });
    toast.present();
  }
  
  HomeBtn()
  {
    this.router.navigate(['./tabs/products']);
  }

}

