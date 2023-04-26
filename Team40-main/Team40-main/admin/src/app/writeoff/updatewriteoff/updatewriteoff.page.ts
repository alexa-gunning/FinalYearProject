import { Component, OnInit } from '@angular/core';
import { ToastController } from '@ionic/angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { InventoryService } from 'src/services/inventory.service';
import { Reasons } from 'src/models/reasons';
import { InventoryItem } from 'src/models/inventoryitem';
@Component({
  selector: 'app-updatewriteoff',
  templateUrl: './updatewriteoff.page.html',
  styleUrls: ['./updatewriteoff.page.scss'],
})
export class UpdatewriteoffPage implements OnInit {

  reasons: Reasons[];
  inventoryitems: InventoryItem[];
  uWriteOffForm: FormGroup;
  selected: any;
  writeoff: any;
  res: string;
  quantitynow: any;
  constructor(private service: InventoryService, private toast: ToastController, private router: Router, private formBuilder: FormBuilder) 
  {
    this.uWriteOffForm = this.formBuilder.group({
      inventoryId:['',Validators.required],
      writeOffReasonId:['',Validators.required],
     // writeOffDate:['',Validators.required],
      writeOffQty:['',Validators.required],
      name: ['',Validators.required]
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
    var writeoffId = JSON.parse(localStorage.getItem("writeOffId"));
    this.res = ''
    this.service.GetWritenOffItemById(writeoffId).subscribe((res:any) =>{
    this.writeoff = res;
    this.quantitynow = this.writeoff.writeOffQty;
    console.log(this.quantitynow)
      console.log(this.writeoff)
   })


  }

  Update(){
    var writeoffId = JSON.parse(localStorage.getItem("writeOffId"));
    if(this.uWriteOffForm.valid== true){
      this.service.UpdateWriteOff(writeoffId, this.uWriteOffForm.value).subscribe(()=>{
        this.router.navigate(['./item'])
      }, (response: HttpErrorResponse) => {
      this.presentErrorToast();
      })
      var quantitynow = JSON.parse(localStorage.getItem("writeOffQty"));
      var id = this.uWriteOffForm.value['inventoryId'];
      var quantityupdated = this.uWriteOffForm.value['writeOffQty'];
     this.service.UpdateInventoryQtyWithUpdate(id, quantitynow, quantityupdated).subscribe(()=>{
     })
    }
  
  else { 
  return;
}
  }

  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This writeoff already exists.',
      duration: 2000
    });
    toast.present();
  }

  AddBtn(){
    this.router.navigate(['./writeoffcreate']);
  }





}
