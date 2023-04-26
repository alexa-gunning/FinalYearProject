import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Observable } from '@mobiscroll/angular-lite/src/js/util/observable';
import { type } from 'os';
import { Hosts } from 'src/models/hosts';
import { Venue } from 'src/models/venue';
import { Type } from 'src/models/workhoptype';
import { WorkshopService } from 'src/services/workshop.service';
@Component({
  selector: 'app-addslots',
  templateUrl: './addslots.page.html',
  styleUrls: ['./addslots.page.scss'],
})
export class AddslotsPage implements OnInit {

  hosts :Hosts[];
  venues: Venue[];
  Wtypes:Type[];
  WSlotForm: FormGroup;
  Selected: any;
  constructor(private service: WorkshopService, private toast:ToastController, private router: Router, private formBuilder:FormBuilder)
   {
    this.WSlotForm = this.formBuilder.group({
      workshopTypeId:['', Validators.required],
      workshopVenueId:['', Validators.required],
      hostId: ['', Validators.required],
      price: ['',Validators.required],
      workshopDate: ['',Validators.required]
    })
    }

  ngOnInit() {
  } 

  ionViewWillEnter():void {
    this.Wtypes = [];
    this.service.GetAllTypes().subscribe(res =>{
      var types= res as any[]
      for(var i=0;i< types.length;i++ )
      {
        var Item = new Type();
        Item.description = res[i].description;
        Item.workshopTypeId = res[i].workshopTypeId;
        this.Wtypes.push(Item);
        console.log(Item)
      }
    });
    
     this.hosts = [];
     this.service.GetAllHosts().subscribe(res =>{
      var Host = res as any[]
      for(var i = 0; i < Host.length; i++){
            var Item = new Hosts();
            Item.hostId = res[i].hostId;
            Item.hostName = res[i].hostName;
            Item.hostSurname = res[i].hostSurname;
            Item.hostEmail = res[i].hostEmail;
            this.hosts.push(Item);
            console.log(Item)
       }
       })

      
        this.venues= []
        this.service.GetAllVenues().subscribe(res =>{
        var Venues = res as any[]
        for(var i = 0; i < Venues.length; i++){
          var Item = new Venue();
          Item.address = res[i].address;
          Item.venueName = res[i].venueName;
          Item.workshopVenueId = res[i].workshopVenueId;
          this.venues.push(Item);
          console.log(Item)
        }
        })
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'New workshop slot added.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This workshop slot already exists.',
      duration: 2000
    });
    toast.present();
  } 

  addSlot(){
    if (this.WSlotForm.valid == true)
    {
      this.service.AddSlot(this.WSlotForm.value).subscribe(()=>{
        this.router.navigate(['./tabs/slots']);
      this.presentToast()
    } , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       })
      
    } 
  }

  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the workshop slot to store in the database. You can view the workshop slots in the view page.',
      duration:5000
    });
    toast.present();
}

HomeBtn()
{
  this.router.navigate(['./tabs/slots']);
}
}
