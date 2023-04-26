import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Policy } from '../models/policy';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  constructor(private http: HttpClient) { }


public GetAllPolicies(){
  return this.http.get<Policy[]>(environment.api + "Policy/GetAllPolicies");
}
}