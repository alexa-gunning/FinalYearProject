import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { InventoryItem } from 'src/models/inventoryitem';
import { InventoryService } from 'src/services/inventory.service';

@Component({
  selector: 'app-updateitems',
  templateUrl: './updateitems.page.html',
  styleUrls: ['./updateitems.page.scss'],
})
export class UpdateitemsPage  {
 Item: InventoryItem[]
  item: any;
  res: string;
  uItemForm: FormGroup;
  constructor(private service: InventoryService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uItemForm = this.formBuilder.group({
      itemName: ['',Validators.required],
      quantityOnHand:['',Validators.required],
      lastUpdated:['',Validators.required]
     });
  }
  ionViewWillEnter(): void {
    var inventoryId = JSON.parse(localStorage.getItem("inventoryId"))
    this.res = '';
    this.service.GetInventoryByID(inventoryId).subscribe((res: any)  =>{
     this.item = res;
    console.log(this.item);

    }); }

  HomeBtn()
  {
    this.router.navigate(['./tabs/items']);
  }

  updateInventory: InventoryItem;
  Update(){


    var inventoryId = JSON.parse(localStorage.getItem("inventoryId"))
    if(this.uItemForm.valid == true){
    this.service.UpdateInventory(inventoryId, this.uItemForm.value).subscribe((res: any) =>{
      this.router.navigate(['./tabs/items']);
      this.presentToast();
    }), (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }

  }
  else{
  return;
  }}
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This item already exists.',
      duration: 2000
    });
    toast.present();
  }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the item you would like to update. Change the item name.',
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
  async presentToast() {
  const toast = await this.toast.create({
    message: 'Inventory item updated.',
    duration: 2000
  });
  toast.present();
  }
  }
