import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Equipments } from 'src/models/equipments';
import { EquipmentService } from 'src/services/equipment.service';
import { ToastController } from '@ionic/angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-updateequipment',
  templateUrl: './updateequipment.page.html',
  styleUrls: ['./updateequipment.page.scss'],
})
export class UpdateequipmentPage {
  Equipment: Equipments[]
  Equipment_: any;
  res: string;
  uEquipmentForm: FormGroup;
  constructor(private service: EquipmentService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uEquipmentForm = this.formBuilder.group({
      // workshopEquipmentId: ['',Validators.required],
      description:['',Validators.required]
  });
 }

  ionViewWillEnter(): void {
    var workshopEquipmentId = JSON.parse(localStorage.getItem("workshopEquipmentId"))
    this.res = '';
    this.service.GetEquipmentByID(workshopEquipmentId).subscribe((res: any) => {
      this.Equipment_ = res;
      console.log(this.Equipment_);

    });
  }

  ngOnInit() {
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }

  updateEquipment: Equipments;

  Update() {
    var workshopEquipmentId = JSON.parse(localStorage.getItem("workshopEquipmentId"))
    if(this.uEquipmentForm.valid == true){
    this.service.UpdateEquipment(workshopEquipmentId, this.uEquipmentForm.value).subscribe(() =>{
      this.router.navigate(['./tabs/equipment']);
      this.presentToast()
    }  , (response: HttpErrorResponse) => {
      this.presentErrorToast();
      })
    }
    else {
      return;
    }
  }

  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the Workshop Equipment you would like to update. Change the Workshop Equipment Description.',
      duration:5000,
      cssClass: 'custom-toast',
      buttons: [
        {
          text: 'Dismiss',
          role: 'cancel'
        }
      ],
    });
    toast.present();

  }

async presentToast() {
  const toast = await this.toast.create({
    message: 'Workshop Equipment Updated.',
    duration: 2000
  });
    toast.present();
    window.location.reload();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This Workshop Equipment Item already exists.',
      duration: 2000
    });
      toast.present();
  }

}
