import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Booking } from '../models/booking';
import { ClientBookings } from '../models/clientbookings';
import { BookingService } from '../services/booking.service';

@Component({
  selector: 'app-viewbookings',
  templateUrl: './viewbookings.component.html',
  styleUrls: ['./viewbookings.component.css']
})
export class ViewbookingsComponent implements OnInit {
  clientId!: number;
  pbookings!: any;
  bookings!: any;
  constructor(private service: BookingService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.clientId = JSON.parse(localStorage.getItem("clientId")!);
    this.service.GetBookingByClientID(this.clientId).subscribe(res =>{
     this.bookings = res;
    console.log(this.bookings)
    });
    this.service.GetPastBookingByClientID(this.clientId).subscribe(res =>{
      this.pbookings = res;
     console.log(this.pbookings)
     });
  }
  Delete(i: Booking){
 this.service.DeleteBooking(i).subscribe(res => {
this.presentToast()
  this.ngOnInit()
 },(response: HttpErrorResponse) =>{
  if(response.status===404)
  {
    this.presentErrorToast();
  }
} 
)};

  async presentErrorToast(){
    this.toast.error("Could not delete booking")
  }

async presentToast(){
  this.toast.error("Booking cancelled")
}
}