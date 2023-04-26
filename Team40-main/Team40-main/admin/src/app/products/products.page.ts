import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Products } from 'src/models/product';
import { ProductService } from 'src/services/product.service';
import { ItemPage } from '../writeoff/writeoffitem/item/item.page';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-products',
  templateUrl: './products.page.html',
  styleUrls: ['./products.page.scss'],
})
export class ProductsPage  {
  Product: Products[];
  searchTerm: string;
  product;
  // image64?: any;
  constructor(private router: Router, private service: ProductService, private toast: ToastController, private sanitizer: DomSanitizer) { }

 ionViewWillEnter(): void {
   this.Product = [];
   this.service.GetProducts().subscribe(res =>{
   var Product = res as any[]
   for(var i = 0; i < Product.length; i++){
     var Item = new Products();
    //  var image = Item.productImage;;

      // if(Item.productImage !== null)
      // {
      //   let objectURL = 'data:image/png;base64,' + Item.productImage;
      //   image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      // }
      // else {
      //   image = "assets/images/noImage2.jpg"
      // }

     Item.productName = res[i].productName;
     Item.price = res[i].price;
     Item.colorDescription = res[i].colorDescription;
     Item.colorName = res[i].colorName;
     Item.productTypeName= res[i].productTypeName;
     Item.typeDescription= res[i].typeDescription;
    //  Item.productPriceId =res[i].productPriceId;
     Item.productId =res[i].productId;
     Item.productTypeID =res[i].productTypeID;
     Item.productColourID =res[i].productColourID;
     Item.quantityOnHand =res[i].quantityOnHand;
    //  Item.productImage = image;
     this.Product.push(Item);
   }
   });
}

  // getProducts() {
  //   this.Product = [];
  //  this.service.GetProducts().subscribe(res =>{
  //  var Product = res as any[]
  //  for(var i = 0; i < Product.length; i++){
  //    var Item = new Products();
  //   //  var image = Item.productImage;;

  //     // if(Item.productImage !== null)
  //     // {
  //     //   let objectURL = 'data:image/png;base64,' + Item.productImage;
  //     //   image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
  //     // }
  //     // else {
  //     //   image = "assets/images/noImage2.jpg"
  //     // }

  //    Item.productName = res[i].productName;
  //    Item.productPrice = res[i].productPrice;
  //    Item.colorDescription = res[i].colorDescription;
  //    Item.colorName = res[i].colorName;
  //    Item.productTypeName= res[i].productTypeName;
  //    Item.typeDescription= res[i].typeDescription;
  //   //  Item.productImage = image;
  //    Item.productPriceId =res[i].productPriceId;
  //    Item.productId =res[i].productId;
  //    this.Product.push(Item);
  //  }
  //  });
  // }

  async presentToast() {
    const toast = await this.toast.create({
      message: "Click to view Products",
      duration: 2000
    });
    toast.present();
  }
  AddBtn(){
    this.router.navigate(['./addproduct']);
  }
  colors(){
    this.router.navigate(['./mgcolor']);
  }
  types(){
    this.router.navigate(['./mgtype']);
  }
  price(){
    this.router.navigate(['./addprice']);
  }
  mgprods(){
    this.router.navigate(['./manageproducts']);
  }
  // Delete(productId: any){
  
  //   this.service.DeleteProduct(productId).subscribe(res =>{
  //   });
  //   this.presentToast1();
  // }
  async presentToast1() {
    const toast = await this.toast.create({
      message: ' product deleted.',
      duration: 2000
    });
    toast.present();
    }
    async presentErrorToast1() {
      const toast = await this.toast.create({
        message: ' product cannot be deleted.',
        duration: 2000
      });
      toast.present();
      }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Click on the add product button to add a product. Click the type or colour button to update or delete those.',
      duration:5000
    });
    toast.present();
}
Update(productId){
  localStorage.setItem("productId", JSON.stringify(productId));
  console.log(JSON.parse(localStorage.getItem("productId")))
  this.router.navigate(['./updateproduct']);
}
// productId: any
Delete(productId: any){
  // console.log("Click works")
  this.service.DeleteProduct(productId).subscribe(res =>{
    this.presentToast2();
    window.location.reload();
  }, (response: HttpErrorResponse) => {
    this.presentErrorToast2();
     });
  // this.presentToast();
}
async presentToast2() {
  const toast = await this.toast.create({
    message: 'Product deleted.',
    duration: 2000
  });
  toast.present();
  }
  async presentErrorToast2() {
    const toast = await this.toast.create({
      message: 'Product cannot be deleted.',
      duration: 2000
    });
    toast.present();
    }
}


