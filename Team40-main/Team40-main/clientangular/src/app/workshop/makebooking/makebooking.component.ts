import { JsonPipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Booking } from 'src/app/models/booking';
import { BookingInstance } from 'src/app/models/bookinginstance';
import { Workshops } from 'src/app/models/workshop';
import { BookingService } from 'src/app/services/booking.service';
import { WorkshopService } from 'src/app/services/workshop.service';
 
@Component({
  selector: 'app-makebooking',
  templateUrl: './makebooking.component.html',
  styleUrls: ['./makebooking.component.css']
})
export class MakebookingComponent implements OnInit {
BookingForm!: FormGroup;
booking!: Booking[];
bookinginstance!: BookingInstance[];
workshop!: Workshops[];
clientId!: number;
workshopId!: number;
  constructor(private wsservice: WorkshopService, private formBuilder: FormBuilder, private router: Router, private toast: ToastrService, private bservice: BookingService) { 
this.BookingForm = this.formBuilder.group({
  workshopId:['', Validators.required],
})
  }

  ngOnInit(): void {
   this.clientId = JSON.parse(localStorage.getItem("clientId")!);
    this.wsservice.GetSlotsClient().subscribe(res =>{
     this.workshop = res;
    
    });
  }
  Bookingbtn(){
   
  }
  // workshop: Workshops
MakeBooking( workshop: Workshops){
  // var workshop: Workshops
  const workshopId = {
    ...workshop,
    // ...workshop: Workshops,
    workshopId: parseInt((<HTMLInputElement>document.getElementById("id("+ workshop.workshopId + ")")).value)
  };

console.log(workshopId.workshopId)
console.log(this.clientId)

  this.bservice.AddBookingInstance(workshopId.workshopId).subscribe(() =>{

    console.log("added" + workshopId)
  } , (response: HttpErrorResponse) => {

    console.log("error instance")
     })
     this.bservice.AddBooking2(this.clientId).subscribe(() =>{

      console.log("added" + this.clientId)
    } , (response: HttpErrorResponse) => {
    
      console.log("error booking")
       })
       this.successtoast()
      }
    
      successtoast(){
        this.toast.success('Workshop booked.')
      }
}
