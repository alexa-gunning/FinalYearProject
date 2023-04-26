import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DeliveryCompany } from 'src/models/deliverycompany';

@Injectable({
  providedIn: 'root'
})
export class DeliverycompanyService {

  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
    })
  }
  httpDeleteOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json, text/plain, charset=utf-8 ',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };
 
  public GetAll(){
    return this.http.get(environment.api + "DeliveryCompany/GetAll");
  }

  public AddDelivery(DeliveryCompanyForm:any){
    var addedclient = { 
      "deliveryCompanyId" : DeliveryCompanyForm.deliveryCompanyId,
      "deliveryCompanyName" : DeliveryCompanyForm.deliveryCompanyName,
      "deliveryCompanyEmail" : DeliveryCompanyForm.deliveryCompanyEmail,
      "contactPersonName" : DeliveryCompanyForm.contactPersonName,
      "deliveryCompanyBaseRate" : DeliveryCompanyForm.deliveryCompanyBaseRate,

      // "method" : DeliveryCompanyForm.method
  }
    return this.http.post(environment.api + "DeliveryCompany/AddDeliveryCompany", addedclient);
  }

  public UpdateDeliveryCompany(deliveryCompanyId, DeliveryForm)
  {
    let udeliverycomp = {
      "deliveryCompanyName": DeliveryForm.deliveryCompanyName,
      "deliveryCompanyEmail": DeliveryForm.deliveryCompanyEmail,
      "contactPersonName": DeliveryForm.contactPersonName,
      "deliveryCompanyBaseRate": DeliveryForm.deliveryCompanyBaseRate,
      // "method": DeliveryForm.method,
    }
    return this.http.put(environment.api +"DeliveryCompany/UpdateDeliveryCompany?id="+ deliveryCompanyId,udeliverycomp, this.httpOptions);
  }

  public GetDeliveryCompanyByID(deliveryCompanyId){
    return this.http.get(environment.api+"DeliveryCompany/GetDeliveryCompanyById?id=" + deliveryCompanyId);
  }
  public DeleteDeliveryCompanyPost(delcompany: DeliveryCompany){

    return this.http.post<any>( environment.api + "DeliveryCompany/DeleteDeliveryCompanyPost", delcompany, this.httpDeleteOptions);
  }
}
