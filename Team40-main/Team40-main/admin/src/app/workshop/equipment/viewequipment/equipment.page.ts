/* eslint-disable @typescript-eslint/naming-convention */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EquipmentService } from 'src/services/equipment.service';
import { Equipments } from 'src/models/equipments';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.page.html',
  styleUrls: ['./equipment.page.scss'],
})
export class EquipmentPage implements OnInit {

  Equipment: Equipments[]
  searchTerm: string;
  equipment;

  constructor(private router: Router, private service: EquipmentService, private toast: ToastController) { }

  ionViewWillEnter(): void {
    this.Equipment = [];
    this.service.GetAllEquipment().subscribe(res =>{
    var Equipment = res as any[]
    for(var i = 0; i < Equipment.length; i++){
      var Item = new Equipments();
      Item.workshopEquipmentId = res[i].workshopEquipmentId;
      Item.description = res[i].description;
      this.Equipment.push(Item);
    }});
  }

  ngOnInit() { }

  // eslint-disable-next-line @typescript-eslint/naming-convention
  AddBtn()
  {
    this.router.navigate(['./createequipment']);
  }

  Update(workshopEquipmentId)
  {
    localStorage.setItem("workshopEquipmentId", JSON.stringify(workshopEquipmentId));
    console.log(JSON.parse(localStorage.getItem("workshopEquipmentId")))
    this.router.navigate(['./updateequipment']);
  }

  Delete(workshopEquipmentId: any){
    this.service.DeleteEquipmentPost(workshopEquipmentId).subscribe(res =>{
    });
    this.presentToast();
    //window.location.reload();
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Workshop Equipment deleted.',
      duration: 2000
    });
    toast.present();
  }

}
