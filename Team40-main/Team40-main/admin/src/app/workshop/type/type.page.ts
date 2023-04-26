import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkshopService } from 'src/services/workshop.service';
import { Type } from 'src/models/workhoptype';
import { Observable } from 'rxjs';
import { ToastController } from '@ionic/angular';
import { ItemsPage } from 'src/app/inventory/items/viewitems/items.page';
@Component({
  selector: 'app-type',
  templateUrl: './type.page.html',
  styleUrls: ['./type.page.scss'],
})
export class TypePage {

 Types: Type[]
  searchTerm: string;
types:  Type[];
  constructor(private router: Router, private service: WorkshopService, private toast: ToastController) { }

  ionViewWillEnter(): void {
this.Types = [];
this.service.GetAllTypes().subscribe(res =>{
var Types = res as any[]
for(var i = 0; i < Types.length; i++){
  var Item = new Type();
  Item.description = res[i].description;
  Item.workshopTypeId = res[i].workshopTypeId;
  this.Types.push(Item);
}
});

  }
  getAll(){
  
};
  AddBtn(){
    this.router.navigate(['./addtype']);
  }
  Update(workshopTypeId){
    localStorage.setItem("workshopTypeId", JSON.stringify(workshopTypeId));
    console.log(JSON.parse(localStorage.getItem("workshopTypeId")))
    this.router.navigate(['./updatetype']);
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }

  Delete(workshopTypeId: any){
  
    this.service.DeleteTypePost(workshopTypeId).subscribe(res =>{

    
    });
    this.presentToast();
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Type deleted.',
      duration: 2000
    });
    toast.present();
    }
}