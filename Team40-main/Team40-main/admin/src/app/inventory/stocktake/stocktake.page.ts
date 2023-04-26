import { Component, OnInit } from '@angular/core'; 
import { ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators } from "@angular/forms";
import { ToastController } from '@ionic/angular';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Stocktake } from 'src/models/stocktake';
import { StocktakeService } from 'src/app/services/stocktake.service';
import { InventoryItem } from 'src/models/inventoryitem';
@Component({
  selector: 'app-stocktake',
  templateUrl: './stocktake.page.html',
  styleUrls: ['./stocktake.page.scss'],
})
export class StocktakePage implements OnInit {

  stocktakeform: FormGroup;
  items: Stocktake[];
  searchTerm: string;
  constructor(private service: StocktakeService, private router: Router, private formBuilder: FormBuilder) 
  {
    
   }

   ionViewWillEnter(): void{
    this.items= [];
    this.service.GetAllStockTake().subscribe(res=>{
      var items = res as any[];
      for(var i=0;i < items.length;i++)
      {
        var stocktakeitem = new Stocktake();
        stocktakeitem.remarks = res[i].remarks;
        stocktakeitem.itemName= res[i].itemName;
        stocktakeitem.stockTakeDate= res[i].stockTakeDate;
        stocktakeitem.stockTakeTotalQty= res[i].stockTakeTotalQty;
        stocktakeitem.inventoryId = res[i].inventoryId;
        stocktakeitem.stockTakeId = res[i].stockTakeId;
        stocktakeitem.stockTakeTotalId= res[i].stockTakeTotalId;
        stocktakeitem.name = res[i].name;
        console.log(stocktakeitem)

        this.items.push(stocktakeitem);
        
      }
    })
   }

  ngOnInit() {
  }

  HomeBtn(){
    this.router.navigate(["./tabs/inventoryhome"])
  }

  Stocktake(){
this.router.navigate(["./performstocktake"])
  }

  Update( stockTakeId,stockTakeTotalId){
    localStorage.setItem("stockTakeTotalId", JSON.stringify(stockTakeTotalId));
    localStorage.setItem("stockTakeId", JSON.stringify(stockTakeId));
    this.router.navigate(["./UpdateStocktake"])
    console.log(stockTakeId, stockTakeTotalId)
  }

  Delete(stocktake){

  }

}
