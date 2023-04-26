import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-addsupplierpurchase',
  templateUrl: './addsupplierpurchase.page.html',
  styleUrls: ['./addsupplierpurchase.page.scss'],
})
export class AddsupplierpurchasePage implements OnInit {

  PurchaseForm: FormGroup;
  // private service: SupplierPurchaseService,
  constructor( private formBuilder: FormBuilder, private router: Router, private toast: ToastController) { 
    this.PurchaseForm = this.formBuilder.group({
      itemName: ['',Validators.required],
      date:['',Validators.required],
      price:['',Validators.required],
      quantityPurchased:['',Validators.required],
      totalCost:['',Validators.required],
      supplierName:['',Validators.required],
      supplierEmail:['',Validators.required],
      inventoryItemPrice:['',Validators.required],
     
     });
    }


     ngOnInit():void {}
    
    addItem(){
      if (this.PurchaseForm.valid == true) {
      // this.service.AddInventory(this.ItemForm.value).subscribe((res: any) =>{
        console.log('Purchase added')
      // })
      
      this.router.navigate(['./purchase']); 
      this.presentToast()
    }
      else {
        return;
      }
    }
    
    async presentToast() {
      const toast = await this.toast.create({
        message: 'Supplier purchase is added',
        duration: 2000
      });
      toast.present();
    

}

}
