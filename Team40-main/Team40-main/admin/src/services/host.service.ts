import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Hosts } from 'src/models/hosts';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HostService {

  constructor(private http: HttpClient) { }

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

public GetAllHosts(){
  return this.http.get(environment.api + "Host/GetAllHosts");
}
public GetHostByID(hostId){
  return this.http.get(environment.api + "Host/GetHostByID?id=" + hostId);
}
public UpdateHost(hostId, uHostForm){
  let uhost = {
    "hostName": uHostForm.hostName,
    "hostSurname": uHostForm.hostSurname,
    "hostEmail": uHostForm.hostEmail,
}
  return this.http.put(environment.api + "Host/UpdateHost?id=" + hostId, uhost, this.httpOptions);
}
public AddHost(HostForm:any){
  var addedhost = {
    "hostName": HostForm.hostName,
    "hostSurname": HostForm.hostSurname,
    "hostEmail": HostForm.hostEmail
}
  return this.http.post(environment.api + "Host/AddHost", addedhost);
}

public DeleteHostPost(host: Hosts){

  return this.http.post<any>( environment.api + "Host/DeleteHostPost", host, this.httpDeleteOptions);
}
public DeleteHost2(hostName){

  return this.http.delete( environment.api + "Host/DeleteHost2?HostName=" + hostName);
}

}
