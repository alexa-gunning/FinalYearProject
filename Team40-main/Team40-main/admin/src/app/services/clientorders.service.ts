import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ClientordersService {

  constructor(private http: HttpClient) { }

  public GetClientOrders(){
    return this.http.get(environment.api + "ClientOrders/GetClientOrders");
  }
}
