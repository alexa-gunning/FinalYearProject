import { Component, OnInit } from '@angular/core';
import { Attendance } from 'src/models/attendance';
import { AttendanceService } from 'src/services/attendance.service';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Slots } from 'src/models/slots';
import { WorkshopService } from 'src/services/workshop.service';
@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.page.html',
  styleUrls: ['./attendance.page.scss'],
})
export class AttendancePage implements OnInit {

  constructor(private router: Router, private service: WorkshopService, private toast: ToastController) { }

  searchstring: string;
  items: Attendance[];
  ngOnInit() {
  }

  ionViewWillEnter():void{
    this.items = [];
    this.service.GetBookingsWithClients().subscribe(res =>{
      var items = res as any[]
      for(var i = 0; i< items.length; i++)
      {
        var Item = new Attendance();
        Item.attendanceStatusId= res[i].attendanceStatusId;
        Item.workshopId = res[i].workshopId;
        Item.clientId= res[i].clientId;
        Item.bookingId = res[i].bookingId;
        Item.attendanceStatusName = res[i].attendanceStatusName;
        Item.name = res[i].name;
        Item.surname = res[i].surname
        Item.bookingDate = res[i].bookingDate;
        Item.workshopDate = res[i].workshopDate;
        this.items.push(Item);
      }
    });
  }

  Update(bookingId){
    this.router.navigate(["./takeattendance"])
  }

}
