import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Products } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };
  constructor(private http: HttpClient) { }


public GetProducts(){
  return this.http.get<Products[]>(environment.api + "Product/GetProducts");
}
public UpdateProductQty(productId: any, quantity: any){
  
  return this.http.put(environment.api + "Product/UpdateProductQty?id=" + productId + "&quantity=" + quantity, this.httpOptions);
  }
}
