import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { WorkshopService } from 'src/services/workshop.service';
import { Venue } from 'src/models/venue';
import { Host } from '@angular/core';
import { Type } from '@angular/core';
import { Slots } from 'src/models/slots';
import { ItemsPage } from 'src/app/inventory/items/viewitems/items.page';
@Component({
  selector: 'app-modifyslots',
  templateUrl: './modifyslots.page.html',
  styleUrls: ['./modifyslots.page.scss'],
})
export class ModifyslotsPage implements OnInit {

  constructor(private router: Router, private service: WorkshopService, private toast: ToastController) { }
  searchstring: string;
  slots: Slots[];
  ngOnInit() { 
  }

  ionViewWillEnter():void{
    this.slots = [];
    this.service.GetSlots().subscribe(res =>{
      var slot = res as any []
      for(var i=0; i<slot.length;i++)
      {
        var Item = new Slots();
        Item.hostId = res[i].hostId;
        Item.hostName = res[i].hostName;
        Item.price= res[i].price;
        Item.description= res[i].description;
        Item.typeDescription= res[i].typeDescription;
        Item.workshopDate = res[i].workshopDate;
        Item.workshopTypeId= res[i].workshopTypeId;
        Item.venueName = res[i].venueName;
        Item.workshopVenueId = res[i].workshopVenueId;
        Item.workshopId= res[i].workshopId;
        this.slots.push(Item);
      }
    })
  }

  Update(workshopId){
    localStorage.setItem("workshopId", JSON.stringify(workshopId));
    this.router.navigate(['./updateworkshopslot'])
  }

  

  HomeBtn(){
    this.router.navigate(['./slots'])
  }

  Delete(workshopId: any){
    this.service.DeleteWSlot(workshopId).subscribe(res =>{
    });
    this.presentToast();
    window.location.reload(); 
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Workshop Slot deleted.',
      duration: 2000
    });
    toast.present();
  }

}
