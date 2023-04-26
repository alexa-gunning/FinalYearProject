import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient ) { }
  
  public GetBookingsWithClients(){
    return this.http.get(environment.api + "Booking/GetBookingsWithClients");
  }
}
