import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
// import { userInfo } from 'os';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { LoginClient } from '../models/loginclient';
import { ClientUser } from '../models/clientuser';
import { otp } from '../models/otp';
import { ForgotPassword } from '../models/forgotpassword';
import { Client } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientloginService {

  httpOptions ={
    headers: new HttpHeaders({
      ContentType: 'application/json'
    })
  }
  constructor(private http: HttpClient) { }

  Login(userform:LoginClient){
    // var userDetails={
    //   "emailAddress": userform.userName,
    //   "password": userform.password
    // }
    return this.http.post<otp>(environment.api + 'Authentication/Login', userform, this.httpOptions)
  }
  ValidateOtp(user: otp){
    return this.http.post(environment.api + `Authentication/Otp`, user, this.httpOptions)
  }
  
  public GetClientID(emailAddress: string){
    return this.http.get<Client[]>(environment.api + "Client/GetClientID?EmailAddress=" + emailAddress, this.httpOptions);
  }
  ForgotPassword(userform:ForgotPassword){
    // var userDetails={
    //   "emailAddress": userform.userName,
    //   "password": userform.password
    // }
    return this.http.post<otp>(environment.api + 'Authentication/ForgotPassword', userform, this.httpOptions)
  }
  Register(userform:ClientUser){
    // var userDetails={
    //   "emailAddress": userform.userName,
    //   "password": userform.password
    // }
    return this.http.post(environment.api + 'Authentication/RegisterClient', userform, this.httpOptions)
  }
}
