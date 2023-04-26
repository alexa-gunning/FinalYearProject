import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Gender } from 'src/models/gender';
import { ClientService } from 'src/services/client.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.page.html',
  styleUrls: ['./create.page.scss'],
})
export class CreatePage  {
gender: Gender[]
ClientForm: FormGroup
  constructor(private service: ClientService, private formBuilder: FormBuilder, private toast: ToastController, private router: Router) {
    this.ClientForm= this.formBuilder.group({

      name: ['', Validators.required],
      surname: ['', Validators.required],
      birthDate: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      genderId: ['', Validators.required],
      emailAddress: ['', Validators.required]
    });
  }
  ionViewWillEnter(): void {

    this.gender = [];
    this.service.GetGenders().subscribe(res =>{
    var gender = res as any[]
    for(var i = 0; i < gender.length; i++){
      var Item = new Gender();
      Item.genderId = res[i].genderId;
      Item.genderName = res[i].genderName;

      this.gender.push(Item);
      console.log(Item)
    }
    });}
    Info(){
      this.infoToast();
    }
    async infoToast(){
      const toast = await this.toast.create({
        message: 'Please enter the details of the client to store in the database. You can view the clients in the view page.',
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
  HomeBtn()
  {
    this.router.navigate(['./tabs/client']);
  }
  addClient(){
    if (this.ClientForm.valid == true) {
      this.service.AddClient(this.ClientForm.value).subscribe(() =>{
        this.router.navigate(['./tabs/client']);
        this.presentToast()
      } , (response: HttpErrorResponse) => {
        this.presentErrorToast();
         })


    }
      else {
        return;
      }
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'New client added.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This client already exists.',
      duration: 2000
    });
    toast.present();
  }
}
