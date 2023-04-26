import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DiscountRequest } from 'src/models/discountrequest';

@Injectable({
  providedIn: 'root'
})
export class DiscountsService {
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
  
  constructor(private http: HttpClient) { }

public GetDiscounts(){
  return this.http.get(environment.api + "Discount/GetDiscounts");
}
public GetTypes(){
  return this.http.get(environment.api + "Discount/GetTypes");
}
public GetStatuses(){
  return this.http.get(environment.api + "Discount/GetStatuses");
}
public AddDiscount(DiscountForm:any){
  var added = {
    "discountDescription": DiscountForm.discountDescription,
    "discountTypeId": DiscountForm.discountTypeId,
    "discountStatusId": DiscountForm.discountStatusId, 
}
  return this.http.post(environment.api + "Discount/AddDiscount", added);
}
public AddType(TypeForm:any){
  var added = {
    "percentage": TypeForm.percentage,
}
  return this.http.post(environment.api + "Discount/AddType", added);
}
public UpdateDiscount(discountId, uDiscountForm){  
  let u = { 
    "discountDescription": uDiscountForm.discountDescription,
    "discountTypeId": uDiscountForm.discountTypeId,
    "discountStatusId": uDiscountForm.discountStatusId,
}
  return this.http.put(environment.api + "Discount/UpdateDiscount?id=" + discountId, u, this.httpOptions);
}
public GetDiscountByID(discountId){
  return this.http.get(environment.api + "Discount/GetDiscountByID?id=" + discountId);
}
public DeleteDiscount(item: DiscountRequest){

  return this.http.post<any>( environment.api + "Discount/DeleteDiscount", item, this.httpDeleteOptions);
}


}
