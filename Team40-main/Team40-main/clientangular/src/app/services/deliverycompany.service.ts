import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DeliveryCompany } from '../models/deliverycompany';
@Injectable({
  providedIn: 'root'
})
export class DeliverycompanyService {

  constructor(private http: HttpClient) { }
  public GetAll(){
    return this.http.get(environment.api + "DeliveryCompany/GetAll");
  }
  public GetDeliveryCompanyByID(deliveryCompanyId: DeliveryCompany){
    return this.http.get<DeliveryCompany[]>(environment.api+"DeliveryCompany/GetDeliveryCompanyById?id=" + deliveryCompanyId);
  }
}
