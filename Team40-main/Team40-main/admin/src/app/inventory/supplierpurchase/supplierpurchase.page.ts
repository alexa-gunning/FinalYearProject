import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { SupplierService } from 'src/app/services/supplierservice.service';
import { InventoryItem } from 'src/models/inventoryitem';
import { Supplierpurchases } from 'src/models/supplierpurchases';
import { InventoryService } from 'src/services/inventory.service';

@Component({
  selector: 'app-supplierpurchase',
  templateUrl: './supplierpurchase.page.html',
  styleUrls: ['./supplierpurchase.page.scss'],
})
export class SupplierpurchasePage {
searchTerm: string;
items: Supplierpurchases[];

constructor(private router: Router, private service: InventoryService, private toast: ToastController, private supservice: SupplierService) {

 }

ionViewWillEnter(): void {
  this.items = [];
  this.service.GetPurchases().subscribe(res =>{
  var items = res as any[]
  for(var i = 0; i < items.length; i++){
    var Item = new Supplierpurchases(); 
    Item.date = res[i].date;
    Item.itemName= res[i].itemName;
    Item.supplierName= res[i].supplierName;
    Item.quantityPurchased= res[i].quantityPurchased;
    Item.price= res[i].price;
    Item.supplierPurchaseId= res[i].supplierPurchaseId;
    Item.inventoryId= res[i].inventoryID;
    this.items.push(Item);
    console.log(items)
  }
  });

    }
   
HomeBtn()
{
  this.router.navigate(['./tabs/inventoryhome']);
}
add()
{
  this.router.navigate(['./addpurchase']);
}
Delete(supplierPurchaseId: any){
  
  this.supservice.DeleteSupplierPurchase(supplierPurchaseId).subscribe(res =>{
    this.presentToast();
   
     
  })
  var inventoryId = supplierPurchaseId.inventoryId;
  console.log(inventoryId);
  var qty = supplierPurchaseId.quantityPurchased;
  this.service.UpdateInventoryWithDeleteSP(inventoryId, qty).subscribe(res=> {}),
  (response: HttpErrorResponse) => {
    this.presentErrorToast();
     }
     window.location.reload(); 
}
async presentToast() {
  const toast = await this.toast.create({
    message: 'Purchase deleted.',
    duration: 2000
  });
  toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Purchase cannot be deleted.',
      duration: 2000
    });
    toast.present();
    }
  update(supplierPurchaseId){
    localStorage.setItem("supplierPurchaseId", JSON.stringify(supplierPurchaseId));
    console.log(JSON.parse(localStorage.getItem("supplierPurchaseId")))
    this.router.navigate(['./updatepurchase']);
  }
}
