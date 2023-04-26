import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Login } from 'src/models/login';
import { User } from '@ionic/cli';
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
  constructor(private http: HttpClient) { }

  public RegisterUser(UserForm: any)
  {
    var registereduser={
    "userName": UserForm.userName,
    "password": UserForm.password
    }
    return this.http.post(environment.api+ "Authentication/Register",registereduser, this.httpOptions)

  }
}
