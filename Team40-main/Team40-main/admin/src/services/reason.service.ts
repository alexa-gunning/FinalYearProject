import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Reasons } from '../models/reasons';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReasonService {

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

  public GetAllReasons(){
    return this.http.get(environment.api + "WriteOffReason/GetAllWriteOffReasons2");
  }

  public AddReason(ReasonForm:any){
    var addedreason = {
      "writeOffReasonId": ReasonForm.writeOffReasonId,
      "writeOffReasonDescription": ReasonForm.writeOffReasonDescription
  }
    return this.http.post(environment.api + "WriteOffReason/AddInventoryWriteOffReason", addedreason);
  }

  public UpdateReasons(writeoffreasonId, uReasonForm){
    let ureasons = {
      //"writeoffreasonId": uReasonForm.venueName,
      "writeoffreasonDescription": uReasonForm.writeOffReasonDescription
  }

    return this.http.put(environment.api + "WriteOffReason/UpdateWriteOffReason?id=" + writeoffreasonId, ureasons, this.httpOptions);
  }

  public DeleteReasonPost(reason: Reasons){

    return this.http.post<any>(environment.api + "WriteOffReason/DeleteWriteOffReasonPost", reason, this.httpDeleteOptions);
  }

  public DeleteHost2(writeOffReasonDescription){

    return this.http.delete( environment.api + "WriteOffReason/DeleteReasonPost?writeOffReasonDescription=" + writeOffReasonDescription);
  }
}
