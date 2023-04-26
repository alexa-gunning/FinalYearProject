import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { DiscountRequest } from 'src/models/discountrequest';
import { Attendance } from 'src/models/attendance';
import { AttendanceService } from 'src/services/attendance.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Slots } from 'src/models/slots';
import { Clients } from 'src/models/clients';


@Component({
  selector: 'app-takeattendance',
  templateUrl: './takeattendance.page.html',
  styleUrls: ['./takeattendance.page.scss'],
})
export class TakeattendancePage implements OnInit {

  res: string;
  clients:Clients[];
  slots: Slots[];
  selected: any;
  attendance:Attendance[];
  attendanceForm: FormGroup;
  Booking_: any

  constructor(private service: AttendanceService, private router: Router, private toast: ToastController, private formBuilder:FormBuilder) 
  
  {
      this.attendanceForm= this.formBuilder.group({
        bookingId:['',Validators.required],
        workshopId:['',Validators.required],
        attendanceStatusId:['',Validators.required],
        clientId: ['',Validators.required],
        workshopInstanceId: ['',Validators.required]
        
      })

   }
 
  ngOnInit() {
  }


  ionViewWillEnter(): void{
    var bookingId= JSON.parse(localStorage.getItem("bookingId"))
    this.res = '';
    this.service.GetBookingById(bookingId).subscribe((res:any) =>{
      this.Booking_ = res;

      this.clients =[];
      this.service.GetAllClients().subscribe(res =>{
        var items = res as any[]
        for(var i = 0; i < items.length; i++){
          var Item = new Clients();
          Item.clientId = res[i].clientId;
          Item.name = res[i].name;
          Item.surname= res[i].surname;
          Item.emailAddress = res[i].emailAddress;
          Item.birthDate= res[i].birthDate;
          Item.phoneNumber= res[i].phoneNumber;
          this.clients.push(Item);
        }
        });

        this.slots=[];
    this.service.GetSlots().subscribe(res =>{
      var Eslots = res as any[]
      for(var i=0; i < this.slots.length; i++)
      {
        var EventSlot = new Slots();
        EventSlot.hostName= res[i].hostName;
        EventSlot.workshopDate = res[i].workshopDate;
        EventSlot.venueName = res[i].venueName;
        EventSlot.description = res[i].description;
        this.slots.push(EventSlot)
        console.log(EventSlot + 'Event 1')
      }
    }

    )

    this.attendance=[];
    this.service.GetAllAttendance().subscribe(res=>{
      var Items = res as any[]
      for(var i = 0;i<Items.length;i++)
      {
        var AttendanceName= new Attendance();
        AttendanceName.attendanceStatusId= res[i].attendanceStatusId;
        AttendanceName.attendanceStatusName= res[i].attendanceStatusName;
      }
    })



    })
  }



  
  Save(){
    var discountId = JSON.parse(localStorage.getItem("bookingId"))
    if(this.attendanceForm.valid == true){
    this.service.UpdateAttendance(discountId, this.attendanceForm.value).subscribe(() =>{
      this.router.navigate(['./tabs/whome']);
      this.presentToast()
    }  , (response: HttpErrorResponse) => {
      this.presentErrorToast();
      })

    }
      else{
      return;
    }
  }

async presentToast() {
  const toast = await this.toast.create({
    message: 'Discount updated.',
    duration: 2000
  });
  toast.present();
  window.location.reload();
  }

async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'This discount already exists.',
    duration: 2000
  });
  toast.present();
}

HomeBtn(){
  this.router.navigate(["./attendance"])
}

Info(){
  this.infoToast();
}

async infoToast(){
  const toast = await this.toast.create({
    message: 'Please enter select the attendance status of the client',
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


}
