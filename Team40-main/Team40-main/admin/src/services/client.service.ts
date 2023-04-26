import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Clients } from 'src/models/clients';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
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

  public GetAllClients(){
    return this.http.get(environment.api + "Client/GetAllClients");
  }
  
  public GetAllClientsWithAddress(){
    return this.http.get(environment.api + "Client/GetAllClientsWithAdress");
  }


  public AddClient(ClientForm:any){
    var addedclient = {
      "name" : ClientForm.name,
      "surname" : ClientForm.surname,
      "emailAddress" : ClientForm.emailAddress,
      "birthDate" : ClientForm.birthDate,
      "phoneNumber" : ClientForm.phoneNumber,
      "genderId" : ClientForm.genderId,
  }
    return this.http.post(environment.api + "Client/AddClient", addedclient);
 }
 
 public UpdateClient(clientId, uClientForm){
  let uclient = {
    "name" : uClientForm.name,
    "surname" : uClientForm.surname,
    "emailAddress" : uClientForm.emailAddress,
    "birthDate" : uClientForm.birthDate,
    "phoneNumber" : uClientForm.phoneNumber,
    "genderId" : uClientForm.genderId,
}
  return this.http.put(environment.api + "Client/UpdateClient?id=" + clientId, uclient, this.httpOptions);
}
  public GetGenders(){
    return this.http.get(environment.api + "Client/GetGenders");
  }
  public DeleteClient(item: Clients){

    return this.http.post<any>( environment.api + "Client/DeleteClient", item, this.httpDeleteOptions);
  }
  public GetClientByID(clientId){
    return this.http.get(environment.api + "Client/GetClientByID?id=" + clientId);
  }
}
