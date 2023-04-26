import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Address } from '../models/address';
import { Client } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      // 'Access-Control-Allow-Origin' : '*',
      // 'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };
  constructor(private http: HttpClient) { }
  // public UpdateClient(clientId, uClientForm){
  //   let uclient = {
  //     "name" : uClientForm.name,
  //     "surname" : uClientForm.surname,
  //     "emailAddress" : uClientForm.emailAddress,
  //     "birthDate" : uClientForm.birthDate,
  //     "phoneNumber" : uClientForm.phoneNumber,
  //     "genderId" : uClientForm.genderId,
  // }
  //   return this.http.put(environment.api + "Client/UpdateClient?id=" + clientId, uclient, this.httpOptions);
  // }
    public GetGenders(){
      return this.http.get(environment.api + "Client/GetGenders");
    }
    public GetAddressByClientID(clientId: number){
      return this.http.get<Address[]>(environment.api + "Client/GetAddressByClientID?id=" + clientId);
    }
    public GetAddressByID(addressId: number){
      return this.http.get<Address[]>(environment.api + "Client/GetAddressyByID?id=" + addressId);
    }
    public DeleteClient(item: Client){
  
      return this.http.post<any>( environment.api + "Client/DeleteClient", item, this.httpOptions);
    }
    // public GetClientByID(clientId){
    //   return this.http.get(environment.api + "Client/GetClientByID?id=" + clientId);
    // }
    public AddAddress(clientId: any, Address: Address){
      var add = {
        "streetName": Address.streetName,
        "streetNumber": Address.streetNumber,
        "city": Address.city,
        "province": Address.province,
        "areaCode": Address.areaCode,

      }
  
      return this.http.post(environment.api + "Client/AddAddress?ClientId=" + clientId, add, this.httpOptions);
      }
      public DeleteAddress(i: any){ 
  
        return this.http.post( environment.api + "Client/DeleteAddress", i, this.httpOptions);
      }
      public UpdateAddress(id: any, u: Address){
  
        return this.http.put(environment.api + "Client/UpdateAddress?id=" + id, u, this.httpOptions);
        }
}
