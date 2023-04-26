import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Discounts } from 'src/models/discounts';
import { DiscountsService } from 'src/services/discounts.service';

@Component({
  selector: 'app-discount',
  templateUrl: './discount.page.html',
  styleUrls: ['./discount.page.scss'],
})
export class DiscountPage {

  constructor(private router: Router, private service: DiscountsService, private toast: ToastController) { }
  searchTerm: string;
  items: Discounts[]; 
    ionViewWillEnter(): void {
      this.items = [];
      this.service.GetDiscounts().subscribe(res =>{
      var items = res as any[]
      for(var i = 0; i < items.length; i++){
        var Item = new Discounts();
        Item.discountDescription = res[i].discountDescription;
        Item.typeDescription= res[i].typeDescription;
        Item.statusDescription= res[i].statusDescription;
        Item.percentage= res[i].percentage;
        Item.discountId= res[i].discountId;
        Item.discountStatusId= res[i].discountStatusId;
        Item.discountTypeId= res[i].discountTypeId;
        this.items.push(Item);
      }
      });
    }
  AddBtn(){
    this.router.navigate(['./creatediscount']);
  }
  Update(discountId){
    localStorage.setItem("discountId", JSON.stringify(discountId));
    console.log(JSON.parse(localStorage.getItem("discountId")))
    this.router.navigate(['./updatediscount']);
  }
  Delete(discountId: any){
    this.service.DeleteDiscount(discountId).subscribe(res =>{
    });
    this.presentToast();
    window.location.reload(); 
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Discount deleted.',
      duration: 2000
    });
    toast.present();
  }

}
