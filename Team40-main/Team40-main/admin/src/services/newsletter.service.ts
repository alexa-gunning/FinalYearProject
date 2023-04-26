import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Hosts } from 'src/models/hosts';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NewsletterService {
  

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
     
    })
  };

public AddNewsletter(NewsletterForm:any){

console.log("Subject rx" + NewsletterForm.subjectline) 

  var addedhost = {
    "SubjectLine": NewsletterForm.subjectline,
    "MessageBody": NewsletterForm.messagebody 
}
  return this.http.post(environment.api + "Newsletter/SendNewsletter", addedhost);
}


}
