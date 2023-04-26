import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InventoryService } from 'src/services/inventory.service';
import { InventoryItem } from 'src/models/inventoryitem';
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
//look at imports in items.module.ts

@Component({
  selector: 'app-items',
  templateUrl: './items.page.html',
  styleUrls: ['./items.page.scss'],
})
export class ItemsPage  {
 searchTerm: string;
  items: InventoryItem[];

  constructor(private router: Router, private service: InventoryService, private toast: ToastController) {

   }

  ionViewWillEnter(): void {
    this.items = [];
    this.service.GetAllInventory().subscribe(res =>{
    var items = res as any[]
    for(var i = 0; i < items.length; i++){
      var Item = new InventoryItem();
      Item.inventoryId = res[i].inventoryId;
      Item.itemName= res[i].itemName;
      Item.lastUpdated= res[i].lastUpdated;
      Item.quantityOnHand= res[i].quantityOnHand;
      this.items.push(Item);
      
    }
    });

      }
      Update(inventoryId){
        localStorage.setItem("inventoryId", JSON.stringify(inventoryId));
        console.log(JSON.parse(localStorage.getItem("inventoryId")))
        this.router.navigate(['./updateitems']);
      }
  AddBtn(){
    this.router.navigate(['./additems']);
  }
  Delete(inventoryId: any){
  
    this.service.DeleteItemPost(inventoryId).subscribe(res =>{
      this.presentToast();
    
    }), (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }

  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Inventory item deleted.',
      duration: 2000
    });
    toast.present();
    }
    async presentErrorToast() {
      const toast = await this.toast.create({
        message: 'Inventory item cannot be deleted.',
        duration: 2000
      });
      toast.present();
      }
  HomeBtn()
  {
    this.router.navigate(['./tabs/inventoryhome']);
  }
}
