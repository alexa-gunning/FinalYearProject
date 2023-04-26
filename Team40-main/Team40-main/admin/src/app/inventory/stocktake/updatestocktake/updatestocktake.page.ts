import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Stocktake } from 'src/models/stocktake';
import { InventoryItem } from 'src/models/inventoryitem';
import { StocktakeService } from 'src/app/services/stocktake.service';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-updatestocktake',
  templateUrl: './updatestocktake.page.html',
  styleUrls: ['./updatestocktake.page.scss'],
})
export class UpdatestocktakePage implements OnInit {

  res: string;
  sres:string;
  inventoryitems: InventoryItem[];
  ustocktakeform: FormGroup;
  selected: any;
  stocktake: Stocktake[];
  stocktake_: any;
  Stocktaketotal_ : any;
  constructor(private service: StocktakeService, private router: Router, private toast: ToastController, private formBuilder:FormBuilder)
   {
    this.ustocktakeform = this.formBuilder.group({
      inventoryId:['',Validators.required],
      stockTakeTotalQty:['',Validators.required],
      remarks:['',Validators.required],
      //stockTakeId:['',Validators.required],
      name:['',Validators.required],
    });
    }

  ngOnInit() { 
  }

  ionViewWillEnter(): void {
    var stockTakeTotalId = JSON.parse(localStorage.getItem("stockTakeTotalId"))
    this.res = '';
    this.service.GetStocktaketotalById(stockTakeTotalId).subscribe((res: any)  =>{
     this.Stocktaketotal_ = res;
    console.log(this.Stocktaketotal_);

    });
    var stockTakeId = JSON.parse(localStorage.getItem("stockTakeId"))
    this.sres = '';
    this.service.GetStocktakeById(stockTakeId).subscribe((res: any)  =>{
     this.stocktake_ = res;
    console.log(this.stocktake_);

    });
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

  update(){


    var stockTakeTotalId = JSON.parse(localStorage.getItem("stockTakeTotalId"))
    var stocktakeId = JSON.parse(localStorage.getItem("stockTakeId"))
    console.log(stocktakeId)
    if(this.ustocktakeform.valid == true){
    this.service.UpdateStocktake(stocktakeId,this.ustocktakeform.value).subscribe(()=>{
      this.presentToast();
      
    })
    this.service.UpdateStocktakeTotal(stockTakeTotalId, this.ustocktakeform.value).subscribe((res: any) =>{
      this.router.navigate(['./stocktake']);
      this.presentToast();
    })
    var id = this.ustocktakeform.value['inventoryId'];
    var quantity = this.ustocktakeform.value['stockTakeTotalQty'];
   this.service.UpdateInventoryQty(id, quantity).subscribe(()=>{

   }),
  
    
    (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }
  }
  else{
  return;
  }}

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Stocktake total has been updated!',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This stocktake already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn(){
    this.router.navigate(['./stocktake'])
  }

}
