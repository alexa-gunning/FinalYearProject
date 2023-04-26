import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { CalendarComponent } from 'ionic2-calendar';
import { NgCalendarModule } from 'ionic2-calendar';
import { Slots } from 'src/models/slots';
import { WorkshopService } from 'src/services/workshop.service';

@Component({
  selector: 'app-slots',
  templateUrl: './slots.page.html',
  styleUrls: ['./slots.page.scss'],
})
export class SlotsPage implements OnInit {

  slots: Slots[];
  eventSource= [];
  viewTitle :string;

  calendar = {
    mode: 'month',
    currentDate: new Date(),
  };

  

  selectedDate: Date;

  @ViewChild(CalendarComponent) myCal: CalendarComponent;
  constructor(private toast: ToastController, private service: WorkshopService, private router: Router) { }

  ngOnInit() {
  }
  ionViewWillEnter(): void {
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
    console.log(this.slots)
  }

  next(){
    this.myCal.slideNext();
  }

  back(){
    this.myCal.slidePrev();
  }
  onViewTitleChanged(title) {
    this.viewTitle = title;
  }

  async onEventSelected(event) {
    // Use Angular date pipe for conversion
    //let start = formatDate(event.startTime, 'medium', this.locale);
    //let end = formatDate(event.endTime, 'medium', this.locale);

    const alert = await this.toast.create({
      header: event.title,
     // message: 'From: ' + start + '<br><br>To: ' + end,
      buttons: ['OK'],
    });
    alert.present();
  }

  AddBtn(){
    this.router.navigate(['./addslots'])
  }

  ModSlot(){
    this.router.navigate(['./modifyslots'])
  }
  HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }

  

}
