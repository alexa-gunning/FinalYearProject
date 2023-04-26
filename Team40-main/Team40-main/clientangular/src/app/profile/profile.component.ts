import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
// import { ToastController } from '@ionic/angular';
import { LoginClient } from 'src/app/models/loginclient';
import { ClientService } from 'src/app/services/client.service';
import { ClientloginService } from 'src/app/services/clientlogin.service';
import { ToastrService } from 'ngx-toastr';
import { Client } from '../models/client';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  res: string | undefined;
  item!: Client[];
 email: any;

    constructor(private router: Router, public toastController: ToastrService, private service: ClientloginService, private cservice: ClientService) { }
  
    ngOnInit() {
     this.email= JSON.parse(localStorage.getItem("Token")!);
      console.log(this.email.userName);
      this.res = '';
      this.service.GetClientID(this.email.userName).subscribe((res: any)  =>{
       this.item = res;
      //  this.item.clientId = res.clientId
      console.log(res);
     
      }); 
   
    }
    
  
    AddBtn(){
      this.router.navigate(['./createprofile']);
    }
    
    update(clientId: any)
    {
      localStorage.setItem("clientId" , JSON.stringify(clientId));
      console.log(JSON.parse(localStorage.getItem("clientId")!));
      // this.router.navigate(['./updateprofile']);
    }
    Delete(clientId: any){
      this.cservice.DeleteClient(clientId).subscribe(res =>{
      });
      this.presentToast();
      window.location.reload(); 
    }
    async presentToast() {
      // const toast = await this.toastController.create({
      //   message: 'Profile deleted.',
      //   duration: 2000
      // });
      // toast.present();
      this.toastController.success('Profile deleted')
    
    }
    /*async presentToast() {
      const toast = await this.toastController.create({
        message: 'Subscribed to Newsletter',
        duration: 2000
      });
      toast.present();
    }*/
  
  }
