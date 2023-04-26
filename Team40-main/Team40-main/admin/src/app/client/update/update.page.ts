import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Client } from '@ionic/cli/lib/http';
import { Gender } from 'src/models/gender';
import { ClientService } from 'src/services/client.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.page.html',
  styleUrls: ['./update.page.scss'],
})
export class UpdatePage {
  Client: Client[]
  client: any;
  res: string;
  
  gender: Gender[]
  uClientForm: FormGroup
    constructor(private service: ClientService, private formBuilder: FormBuilder, private toast: ToastController, private router: Router) {
      this.uClientForm= this.formBuilder.group({
  
        name: ['', Validators.required],
        surname: ['', Validators.required],
        birthDate: ['', Validators.required],
        phoneNumber: ['', Validators.required],
        genderId: ['', Validators.required],
        emailAddress: ['', Validators.required]
      });
    }
    ionViewWillEnter(): void {
     
        var clientId = JSON.parse(localStorage.getItem("clientId"))
        this.res = '';
        this.service.GetClientByID(clientId).subscribe((res: any)  =>{
         this.client = res;
        console.log(this.client);
    
        }); 
    
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
          message: 'Please enter the details of the client to update. You can view the clients in the view page.',
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
    updateClient: Client;
    update(){
      var clientId = JSON.parse(localStorage.getItem("clientId"))
      if(this.uClientForm.valid == true){
      this.service.UpdateClient(clientId, this.uClientForm.value).subscribe((res: any) =>{
        this.router.navigate(['./tabs/client']);
        this.presentToast();
      }), (response: HttpErrorResponse) => {
        this.presentErrorToast();
         }
  
    }
    else{
    return;
    }}
    async presentErrorToast() {
      const toast = await this.toast.create({
        message: 'This client already exists.',
        duration: 2000
      });
      toast.present();
    }
   
    async presentToast() {
    const toast = await this.toast.create({
      message: 'Client updated.',
      duration: 2000
    });
    toast.present();
    }
    }
