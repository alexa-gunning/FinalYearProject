import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkshopService } from 'src/services/workshop.service';
import { Venue } from 'src/models/venue';
import { Observable } from 'rxjs';
import { ToastController } from '@ionic/angular';
@Component({
  selector: 'app-venue',
  templateUrl: './venue.page.html',
  styleUrls: ['./venue.page.scss'],
})
export class VenuePage {
  Venues: Venue[]
  searchTerm: string;
venues:  Venue[];
  constructor(private router: Router, private service: WorkshopService, private toast: ToastController) { }

  ionViewWillEnter(): void {
this.Venues = [];
this.service.GetAll().subscribe(res =>{
var Venues = res as any[]
for(var i = 0; i < Venues.length; i++){
  var Item = new Venue();
  Item.address = res[i].address;
  Item.venueName = res[i].venueName;
  Item.workshopVenueId = res[i].workshopVenueId;
  this.Venues.push(Item);
}
});

  }
  getAll(){
  
};
  AddBtn(){
    this.router.navigate(['./addvenue']);
  }
  Update(workshopVenueId){
    localStorage.setItem("workshopVenueId", JSON.stringify(workshopVenueId));
    console.log(JSON.parse(localStorage.getItem("workshopVenueId")))
    this.router.navigate(['./updatevenue']);
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }
  // Delete(venue){
  //   console.log(venue.workshopVenueId);
  //   this.service.DeleteWorkshopVenue(venue.workshopVenueId).subscribe(res => {
  //     this.venues = this.venues.filter(item => item.workshopVenueId !== venue.workshopVenueId);
  //   });
  // }
  Delete(workshopVenueId: any){
  
    this.service.DeleteVenuePost(workshopVenueId).subscribe(res =>{
   
    
    });
    this.presentToast();
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Venue deleted.',
      duration: 2000
    });
    toast.present();
    }
}
