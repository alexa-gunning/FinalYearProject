import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Orders } from '../models/orders';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };
  constructor(private http: HttpClient) { }
  public GetOrderByClientID2(clientId: number){
    return this.http.get<Orders[]>(environment.api + "Order/GetOrderByClientID2?id=" + clientId);
  }
  public AddOrder(Order: any){
    // var add = {
    //   "streetName": Address.streetName,
    //   "streetNumber": Address.streetNumber,
    //   "city": Address.city,
    //   "province": Address.province,
    //   "areaCode": Address.areaCode,
    // }

    return this.http.post(environment.api + "Order/AddOrder", Order, this.httpOptions);
    }
    public AddOrderProduct(productId: any, quantity: any, orderProductId: any){
  
      return this.http.post(environment.api + "Order/AddOrderProduct?ProductId=" + productId
       + "&Quantity=" + quantity + "&OrderProductId=" + orderProductId, this.httpOptions);
      }
      public GetNaxOrderId(){
        return this.http.get<any>(environment.api + "Order/GetMaxOrderId");
      }
}
