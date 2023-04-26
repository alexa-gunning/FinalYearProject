import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { TouchSequence } from 'selenium-webdriver';
import { Equipments } from 'src/models/equipments';
import { EquipmentService } from 'src/services/equipment.service';
import { ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators } from "@angular/forms";
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-createequipment',
  templateUrl: './createequipment.page.html',
  styleUrls: ['./createequipment.page.scss'],
})
export class CreateequipmentPage implements OnInit {
  EquipmentForm: FormGroup;
  constructor(private service: EquipmentService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.EquipmentForm = this.formBuilder.group({
      description: ['',Validators.required]
     });
  }

  ngOnInit(): void {
  }

  addEquipment(){
    if (this.EquipmentForm.valid == true){
    this.service.AddEquipment(this.EquipmentForm.value).subscribe(() =>{
      this.router.navigate(['./equipment']);
      this.presentToast()
    }
    , (response: HttpErrorResponse) => {
      this.presentErrorToast();
    })}
    }

    Info(){
      this.infoToast();
    }
    async infoToast(){
      const toast = await this.toast.create({
        message: 'Please enter the details of the Workshop Equipment Item to store in the database. You can view the Workshop Equipment Items in the View Workshop Equipment Page.',
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
      message: 'New equipment added.',
      duration: 2000
    });
    toast.present();
  }

  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'Workshop Equipment already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }

}
