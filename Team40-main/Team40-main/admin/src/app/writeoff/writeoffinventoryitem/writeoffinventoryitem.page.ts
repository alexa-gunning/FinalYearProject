import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators } from "@angular/forms";
import { ToastController } from '@ionic/angular';
import { InventoryService } from 'src/services/inventory.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { InventoryItem } from 'src/models/inventoryitem';
import { Reasons } from 'src/models/reasons';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-writeoffinventoryitem',
  templateUrl: './writeoffinventoryitem.page.html',
  styleUrls: ['./writeoffinventoryitem.page.scss'],
})
export class WriteoffinventoryitemPage implements OnInit {

  reasons: Reasons[];
  inventoryitems: InventoryItem[];
  WriteOffForm: FormGroup; 
  selected: any;
  constructor(private service: InventoryService, private toast: ToastController, private router: Router, private formBuilder: FormBuilder)
   {
    this.WriteOffForm = this.formBuilder.group({
      inventoryId:['',Validators.required],
      writeOffReasonId:['',Validators.required],
     // writeOffDate:['',Validators.required],
      writeOffQty:['',Validators.required],
      name:['',Validators.required]
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

    this.reasons=[];
    this.service.GetAllReasons().subscribe(res=>{
      var writeoffreasons = res as any[]
      for (var i = 0;i<writeoffreasons.length;i++)
      {
        var Wreason = new Reasons();
        Wreason.writeOffReasonId = res[i].writeOffReasonId;
        Wreason.writeOffReasonDescription= res[i].writeOffReasonDescription;
        this.reasons.push(Wreason);
      }
    });
  }

  AddWriteOff(){
    if (this.WriteOffForm.valid == true) {
      this.service.WriteOffInventory(this.WriteOffForm.value).subscribe(() =>{
        this.router.navigate(['./item']);
        
        this.presentToast()
      })
      var id = this.WriteOffForm.value['inventoryId'];
      var quantity = this.WriteOffForm.value['writeOffQty'];
     this.service.UpdateInventoryQty(id, quantity).subscribe(()=>{
     })
    }
  //   var id = this.WriteOffForm.value['inventoryId'];
  //   var quantity = this.WriteOffForm.value['writeOffQty'];
  //  this.service.UpdateInventoryQty(id, quantity).subscribe(()=>{

  //  })
  }
  

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Inventory Item has been written off',
      duration: 2000
    });
    toast.present();
  }

  AddBtn(){
    this.router.navigate(['./writeoffcreate']);
  }

  

  

}
