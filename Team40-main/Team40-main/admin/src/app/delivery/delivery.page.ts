import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DeliverycompanyService } from 'src/services/deliverycompany.service';
import { DeliveryCompany } from 'src/models/deliverycompany';
import { ItemsPageRoutingModule } from '../inventory/items/viewitems/items-routing.module';
import { ToastController } from '@ionic/angular';
@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.page.html',
  styleUrls: ['./delivery.page.scss'],
})
export class DeliveryPage { 
  Delivery: DeliveryCompany[]
  searchTerm: string;

  constructor(private router:Router, private service:DeliverycompanyService, private toast: ToastController) { }

  ionViewWillEnter(): void{
    this.Delivery = [];
    this.service.GetAll().subscribe(res =>{
      var Delivery = res as any[]
      for(var i=0; i<Delivery.length;i++)
      {
        var Item = new DeliveryCompany(); 
        Item.deliveryCompanyName= res[i].deliveryCompanyName;
        Item.deliveryCompanyEmail =res[i].deliveryCompanyEmail;
        Item.deliveryCompanyId=res[i].deliveryCompanyId;
        Item.contactPersonName=res[i].contactPersonName;
        Item.deliveryCompanyBaseRate=res[i].deliveryCompanyBaseRate;
        // Item.method=res[i].method;
        this.Delivery.push(Item)
      }
    });
  }
  AddBtn(){
    this.router.navigate(['./deliveryadd']);
  } 
  Update(deliveryCompanyId){
    localStorage.setItem("deliveryCompanyId", JSON.stringify(deliveryCompanyId));
    console.log(JSON.parse(localStorage.getItem("deliveryCompanyId")))
    this.router.navigate(['./deliveryupdate']);
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/delivery']);
  }

  Delete(DeliveryCompanyId: any){
  
    this.service.DeleteDeliveryCompanyPost(DeliveryCompanyId).subscribe(res =>{
      window.location.reload();
    
    });
    this.presentToast();
    this.router.navigate(['./tabs/delivery']);
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Delivery Company deleted.',
      duration: 2000,
      position:'middle'
    });
    toast.present();
    }

  
}
