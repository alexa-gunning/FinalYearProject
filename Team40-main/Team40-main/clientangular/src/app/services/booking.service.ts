import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Booking } from '../models/booking';
import { BookingInstance } from '../models/bookinginstance';

@Injectable({
  providedIn: 'root'
})

export class BookingService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };
  constructor(private http: HttpClient) { }

  public AddBookingInstance(workshopId: any){
 
  
    return this.http.post(environment.api + "Booking/AddBookingInstance?WorkshopId=" + workshopId, this.httpOptions);
    }
    public AddBooking2(clientId: any){
 
  
      return this.http.post(environment.api + "Booking/AddBooking2?ClientId=" + clientId, this.httpOptions);
      }
      public GetBookingByClientID(clientId: number){
        return this.http.get<Booking[]>(environment.api + "Booking/GetBookingByClientID?id=" + clientId);
      }
      public GetPastBookingByClientID(clientId: number){
        return this.http.get<Booking[]>(environment.api + "Booking/GetPastBookingByClientID?id=" + clientId);
      }
      public DeleteBooking(i: any){ 
  
        return this.http.post( environment.api + "Booking/DeleteBookingPost", i, this.httpOptions);
      }
}
