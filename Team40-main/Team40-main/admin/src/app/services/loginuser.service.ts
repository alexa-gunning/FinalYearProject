import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Login } from 'src/models/login';
import { User } from '@ionic/cli';
import { environment } from 'src/environments/environment';
import { userInfo } from 'os';
import { otp } from 'src/models/otp';
import { ForgotPassword } from 'src/models/forgotpassword';

@Injectable({
  providedIn: 'root'
})
export class LoginuserService {

  httpOptions ={
    headers: new HttpHeaders({
      ContentType: 'application/json'
    })
  }

  constructor(private http: HttpClient) { }

  /*LoginUser(loginUser: Login){
    return this.http.post<User>(environment.api + "Authentication/Login", loginUser, this.httpOptions)
  }*/

  Login(userform:Login){
    // var userDetails={
    //   "emailAddress": userform.userName,
    //   "password": userform.password
    // }
    return this.http.post<otp>(environment.api + 'Authentication/Login', userform, this.httpOptions)
  }
  ValidateOtp(user: otp){
    return this.http.post(environment.api + `Authentication/Otp`, user, this.httpOptions)
  }
  
  ForgotPassword(userform:ForgotPassword){
    // var userDetails={
    //   "emailAddress": userform.userName,
    //   "password": userform.password
    // }
    return this.http.post<otp>(environment.api + 'Authentication/ForgotPassword', userform, this.httpOptions)
  }
}
/*class UserDetails{
    emailAddress: string = 'tokolloBapela@example.com' ;
    password:string = '1234567'
}*/
