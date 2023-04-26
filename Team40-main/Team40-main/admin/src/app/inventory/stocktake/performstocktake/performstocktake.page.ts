import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators } from "@angular/forms";
import { ToastController } from '@ionic/angular';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { InventoryItem } from 'src/models/inventoryitem';
import { Stocktake } from 'src/models/stocktake';
import { StocktakeService } from 'src/app/services/stocktake.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-performstocktake',
  templateUrl: './performstocktake.page.html',
  styleUrls: ['./performstocktake.page.scss'],
})
export class PerformstocktakePage implements OnInit {

  inventoryitems: InventoryItem[];
  stocktakeform: FormGroup;
  stocktake: [];
  constructor(private service: StocktakeService, private toast: ToastController, private router: Router, private formBuilder: FormBuilder) 
  {
    this.stocktakeform = this.formBuilder.group({
      inventoryId:['',Validators.required],
      stockTakeTotalQty:['',Validators.required],
      remarks:['',Validators.required],
      //stockTakeId:['',Validators.required],
      name: ['',Validators.required],
    });

   }

  ngOnInit() {
  }

  ionViewWillEnter(): void{
    this.inventoryitems =[];
    this.service.GetAllInventory().subscribe(res=>{
      var items = res as any[]
      for(var i = 0; i < items.length; i++){
        var Item = new InventoryItem();
        Item.inventoryId = res[i].inventoryId;
        Item.itemName= res[i].itemName;
        Item.lastUpdated= res[i].lastUpdated;
        Item.quantityOnHand= res[i].quantityOnHand;
        this.inventoryitems.push(Item);
      }
    });
  }


  PerformStocktake(){
    if(this.stocktakeform.valid==true)
    {
      this.service.AddStockTake(this.stocktakeform.value).subscribe(()=>{
        this.presentToast();
      
      })
      this.service.PerformStockTake(this.stocktakeform.value).subscribe(()=>{
        this.router.navigate(["./stocktake"]);
        this.presentToast()
     
      })
      var id = this.stocktakeform.value['inventoryId'];
       var quantity = this.stocktakeform.value['stockTakeTotalQty'];
      this.service.UpdateInventoryQty(id, quantity).subscribe(()=>{

      })
    }
    console.log("Done")
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Stocktake saved',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn(){
    this.router.navigate(["./stocktake"]);
  }

}
