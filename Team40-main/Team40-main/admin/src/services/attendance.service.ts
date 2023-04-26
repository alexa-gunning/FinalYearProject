import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Attendance } from 'src/models/attendance';
import { Discounts } from 'src/models/discounts';
@Injectable({
  providedIn: 'root'
})
export class AttendanceService {

  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };
  httpDeleteOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json, text/plain, charset=utf-8 ',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };


  public GetAllClients(){
    return this.http.get(environment.api + "Booking/GetAllClients");
  }

  public GetSlots(){
    return this.http.get(environment.api + "Booking/GetSlots");
  }

  public GetAllAttendance(){
    return this.http.get(environment.api + "Booking/GetAllAttendance");
  }

  public GetAllBookings(){
    return this.http.get(environment.api +"Booking/GetAllBookings" )
  }

  public UpdateAttendance(bookingId, bookingForm){
    let update ={
      "bookingId": bookingForm.bookingId,
      "bookingInstanceId": bookingForm.bookingInstanceId,
      "bookingDate": bookingForm.bookingDate,
      "clientId": bookingForm.clientId,
      "attendanceStatusId": bookingForm.attendanceStatusId

    }

    return this.http.put(environment.api + "Booking/UpdateBooking?id=" + bookingId, update, this.httpOptions);
  }

  public GetBookingById(bookingId){
    return this.http.get(environment.api + "Booking/GetBookingById?id=" + bookingId);
  }
  }



