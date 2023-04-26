import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
// import { ConsoleReporter } from 'jasmine';
import { type } from 'os';
import { async } from 'rxjs';
import { SupplierService } from 'src/app/services/supplierservice.service';
import { DiscountStatuses } from 'src/models/discountstatuses';
import { DiscountTypes } from 'src/models/discounttypes';
import { InventoryItem } from 'src/models/inventoryitem';
import { Supplier } from 'src/models/supplier';
import { InventoryService } from 'src/services/inventory.service';

@Component({
  selector: 'app-addpurchase',
  templateUrl: './addpurchase.page.html',
  styleUrls: ['./addpurchase.page.scss'],
})
export class AddpurchasePage{
  items: InventoryItem[];
  suppliers: Supplier[];
PurchaseForm: FormGroup;
selected: any;
  constructor(public invservice: InventoryService, private supservice: SupplierService, private formBuilder:FormBuilder, private toast: ToastController, private router: Router) { 

  this.PurchaseForm = this.formBuilder.group({
    supplierId: ['',Validators.required],
   inventoryId:['',Validators.required],
   price:['',Validators.required],
   date:['',Validators.required],
   quantityPurchased:['',Validators.required]
   });
  }
  ionViewWillEnter(): void {

    this.items = [];
    this.invservice.GetAllInventory().subscribe(res =>{
    var items = res as any[]
    for(var i = 0; i <items.length; i++){
      var Item = new InventoryItem();
      Item.inventoryId = res[i].inventoryId;
      Item.itemName = res[i].itemName;
     
      this.items.push(Item);
      console.log(Item)
    }
    });
   
    this.suppliers = [];
    this.supservice.GetAllSupplier().subscribe(res =>{
    var suppliers = res as any[]
    for(var i = 0; i <suppliers.length; i++){
      var Item = new Supplier();
      Item.supplierId = res[i].supplierId;
      Item.supplierName= res[i].supplierName;
      this.suppliers.push(Item);
      console.log(Item)
    }
    });

  }

  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the supplier purchase to store in the database. You can view the purchases in the view page.',
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
HomeBtn()
{
  this.router.navigate(['./supplierpurchase']);
}
add(){
  if (this.PurchaseForm.valid == true) {
    this.supservice.AddSupplierPurchase(this.PurchaseForm.value).subscribe(() =>{
      this.router.navigate(['./supplierpurchase']);
      this.presentToast()
    } , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       })
       var id = this.PurchaseForm.value['inventoryId'];
       var quantity = this.PurchaseForm.value['quantityPurchased'];
       console.log(quantity)
       this.supservice.UpdateInventory(id, quantity).subscribe(() =>{
        this.router.navigate(['./supplierpurchase']);
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
    message: 'New purchase added.',
    duration: 2000
  });
  toast.present();
}
async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'This purchase already exists.',
    duration: 2000
  });
  toast.present();
}



}
