import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Products } from 'src/models/product';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-manageproducts',
  templateUrl: './manageproducts.page.html',
  styleUrls: ['./manageproducts.page.scss'],
})
export class ManageproductsPage  {

  searchTerm: string;
  items: Products[];

  constructor(private router: Router, private service: ProductService, private toast: ToastController) {

   }

  ionViewWillEnter(): void {
    this.items = [];
    this.service.GetProducts().subscribe(res =>{
    var items = res as any[]
    for(var i = 0; i < items.length; i++){
      var Item = new Products();
      Item.productName = res[i].productName;
      Item.price = res[i].price;
      Item.colorDescription = res[i].colorDescription;
      Item.colorName = res[i].colorName;
      Item.productTypeName= res[i].productTypeName;
      Item.typeDescription= res[i].typeDescription;
      // Item.productPriceId =res[i].productPriceId;
      Item.productId =res[i].productId;
      Item.productTypeID =res[i].productTypeID;
      Item.productColourID =res[i].productColourID;
      Item.quantityOnHand =res[i].quantityOnHand;
      this.items.push(Item);
      
    }
    });

      }
      Update(productId){
        localStorage.setItem("productId", JSON.stringify(productId));
        console.log(JSON.parse(localStorage.getItem("productId")))
        this.router.navigate(['./updateproduct']);
      }
 
  Delete(productId: any){
  
    this.service.DeleteProduct(productId).subscribe(res =>{
      this.presentToast();
    
    }, (response: HttpErrorResponse) => {
      this.presentErrorToast1();
       });
    // this.presentToast();
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Product deleted.',
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
  HomeBtn()
  {
    this.router.navigate(['./tabs/products']);
  }
}
