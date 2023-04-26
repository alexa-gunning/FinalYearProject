import { Component, OnInit } from '@angular/core';
import { ToastController } from '@ionic/angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { Hosts } from 'src/models/hosts';
import { Venue } from 'src/models/venue';
import { Type } from 'src/models/workhoptype';
import { WorkshopService } from 'src/services/workshop.service';
import { Slots } from 'src/models/slots';
import { Console } from 'console';
@Component({
  selector: 'app-updateslot',
  templateUrl: './updateslot.page.html', 
  styleUrls: ['./updateslot.page.scss'],
})
export class UpdateslotPage implements OnInit {

  uSlot : Slots[];
  Slots_ : any;
  Wtypes: Type[];
  venues: Venue[];
  host: Hosts[];
  uSlotForm: FormGroup;
  selected: any;
  res : string;
  constructor(private service: WorkshopService, private router: Router, private formBuilder:FormBuilder, private toast: ToastController)
   { 
    this.uSlotForm = this.formBuilder.group({
      workshopTypeId:['', Validators.required],
      workshopVenueId:['', Validators.required],
      hostId: ['', Validators.required],
      price: ['',Validators.required],
      workshopDate: ['',Validators.required]
    })

   }

  ngOnInit() {
  }

  ionViewWillEnter(): void{
    var workshopId = JSON.parse(localStorage.getItem("workshopId"));
    console.log(workshopId)
    this.res='';
    this.service.GetWSlotByID(workshopId).subscribe((res: any)=>{

      this.Slots_=res;
      console.log(this.Slots_);

      this.host = [];
      this.service.GetAllHosts().subscribe(res =>{
      var Host = res as any[]
      for(var i = 0; i < Host.length; i++){
            var Item = new Hosts();
            Item.hostId = res[i].hostId;
            Item.hostName = res[i].hostName;
            Item.hostSurname = res[i].hostSurname;
            Item.hostEmail = res[i].hostEmail;
            this.host.push(Item);
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
    })
    });

  }

  update(){
    var slotId = JSON.parse(localStorage.getItem("workshopId"));
    if(this.uSlotForm.valid== true){
      this.service.UpdateWSlot(slotId, this.uSlotForm.value).subscribe(()=>{

      }, (response: HttpErrorResponse) => {
      this.presentErrorToast();
      })
    }
  
  else {
  return;
}
  }

  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This workshop slot already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
{
  this.router.navigate(['./tabs/slots']);
}

  

}
