import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ClientUser } from '../models/clientuser';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  httpOptions ={
    headers: new HttpHeaders({
      ContentType: 'application/json'
    })
  }
  constructor(private http:HttpClient) { }

  public RegisterUser(UserForm: any)
  {
    var registereduser={
    "userName": UserForm.userName,
    "password": UserForm.password,
    "genderId": 1,
    "name": UserForm.name,
    "surname": UserForm.surname,
    "phoneNumber": UserForm.phoneNumber,
    "birthDate": UserForm.birthDate,
    }
    return this.http.post(environment.api+ "Authentication/RegisterClient",registereduser, this.httpOptions)

  }
  public GetGenders(){
    return this.http.get(environment.api + "Client/GetGenders");
  }
}
