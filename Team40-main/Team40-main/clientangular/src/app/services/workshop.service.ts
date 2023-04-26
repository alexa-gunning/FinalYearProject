import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Workshops } from '../models/workshop';

@Injectable({
  providedIn: 'root'
})
export class WorkshopService {

  constructor(private http: HttpClient) { }

  public GetSlotsClient() {
    return this.http.get<Workshops[]>(environment.api + "WorkshopSlot/GetSlotsCLient");
  }
  public GetWSlotByID(workshopId: number){
    return this.http.get<Workshops[]>(environment.api + "WorkshopSlot/GetWSlotByID?id=" + workshopId);
  }
}
