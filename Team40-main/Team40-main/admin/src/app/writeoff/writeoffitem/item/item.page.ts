import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { TouchSequence } from 'selenium-webdriver';
// import { Equipments } from 'src/models/equipment';
// import { EquipmentService } from 'src/services/equipment.service';
import { ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators } from "@angular/forms";
import { ToastController } from '@ionic/angular';
import { InventoryService } from 'src/services/inventory.service';
import { WriteOffInventory } from 'src/models/writeoffinventory';

@Component({
  selector: 'app-item',
  templateUrl: './item.page.html',
  styleUrls: ['./item.page.scss'],
})
export class ItemPage implements OnInit {

  WriteOffForm: FormGroup;
  writeoffhistory: WriteOffInventory[];
  searchTerm: string;
  // ionViewWillEnter(): void {
  //   this.Equipment = [];
  //   this.service.GetAllEquipment().subscribe(res =>{
  //   var Host = res as any[]
  //   for(var i = 0; i < Host.length; i++){
  //     var Item = new Equipments();
  //     Item.workshopEquipmentId = res[i].workshopEquipmentId;
  //     Item.description = res[i].description;
  //     this.Equipment.push(Item);
  //   }
  //   });
  // }

  constructor(private service: InventoryService, private router: Router, private toast: ToastController){}
  

  ngOnInit() {
  }

  addWriteOff()
  {
    // this.router.navigate(['./createequipment']);
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/inventoryhome']);
  }

  ionViewWillEnter():void{
    this.writeoffhistory= [];
    this.service.GetAllWrittenOffInventory().subscribe(res=>{
      var history = res as any[]
      for(var i=0; i<history.length;i++)
      {
        var item = new WriteOffInventory();
        item.inventoryId = res[i].inventoryId;
        item.itemName= res[i].itemName;
        item.writeOffId= res[i].writeOffId;
        item.writeOffReasonId= res[i].writeOffReasonId;
        item.writeOffReasonDescription= res[i].writeOffReasonDescription;
        item.writeOffDate = res[i].writeOffDate;
        //item.adminId = res[i].adminId;
        item.quantityOnHand= res[i].quantityOnHand;
        item.lastUpdated= res[i].lastUpdated;
        item.writeOffQty= res[i].writeOffQty;
        item.name=res[i].name;

        this.writeoffhistory.push(item);
        console.log(item)
      }
    })
  }

  Update(writeOffId, writeOffQty){
    localStorage.setItem("writeOffId", JSON.stringify(writeOffId));
    localStorage.setItem("writeOffQty", JSON.stringify(writeOffQty));
    this.router.navigate(['./updatewriteoff']);
    console.log(writeOffId)
    console.log(writeOffQty)
  }

  Delete(writeOffId: any){
    var inventoryId = writeOffId.inventoryId;
    var qty = writeOffId.writeOffQty;
    this.service.DeleteWriteOffPost(writeOffId).subscribe(res =>{
    });
    this.presentToast();
    this.service.UpdateInventoryWithDelete(inventoryId, qty).subscribe(res=> {})
  //  window.location.reload(); 
  } 

  WriteOff(){
    this.router.navigate(['./writeoffinventoryitem'])
  }
  ManageReason(){
    this.router.navigate(['./writeoff'])
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Writeoff inventory item deleted.',
      duration: 2000
    });
    toast.present();
  }

}
