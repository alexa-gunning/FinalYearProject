import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Policy } from 'src/models/policy';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

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

public GetAllPolicies(){
  return this.http.get(environment.api + "Policy/GetAllPolicies");
}
public GetPolicyByID(policyId){
  return this.http.get(environment.api + "Policy/GetPolicyByID?id=" + policyId);
}
public UpdatePolicy(hostId, uPolicyForm){
  let uhost = {
    "policyName": uPolicyForm.policyName,
    "description": uPolicyForm.description,
    "date": uPolicyForm.date,
}
  return this.http.put(environment.api + "Policy/UpdatePolicy?id=" + hostId, uhost, this.httpOptions);
}
public AddPolicy(PolicyForm:any){
  var addedhost = {
    "policyName": PolicyForm.policyName,
    "description": PolicyForm.description,
    "date": PolicyForm.date,
}
  return this.http.post(environment.api + "Policy/AddPolicy", addedhost);
}

public DeletePolicyPost(policy: Policy){

  return this.http.post<any>( environment.api + "Policy/DeletePolicyPost", policy, this.httpDeleteOptions);
}


}
