/* eslint-disable @typescript-eslint/type-annotation-spacing */
/* eslint-disable @typescript-eslint/semi */
/* eslint-disable quote-props */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/quotes */
/* eslint-disable @typescript-eslint/naming-convention */
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Equipments } from 'src/models/equipments';
@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

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

  public GetAllEquipment(){
    return this.http.get(environment.api + "WorkshopEquipment/GetAllWorkshopEquipments");
  }

  public AddEquipment(EquipmentForm:any){
    var addedequipment = {
      "description": EquipmentForm.description
  }
    return this.http.post(environment.api + "WorkshopEquipment/AddEquipment", addedequipment);
  }

  public UpdateEquipment(workshopEquipmentId, uEquipmentForm){
    let uequipment = {
      "description": uEquipmentForm.description
  }
    return this.http.put(environment.api + "WorkshopEquipment/UpdateEquipment?id=" + workshopEquipmentId, uequipment, this.httpOptions);
  }

  public GetEquipmentByID(workshopEquipmentId){
    return this.http.get(environment.api + "WorkshopEquipment/GetEquipmentByID?id=" + workshopEquipmentId);
  }

  public DeleteEquipment2(description){
    return this.http.delete( environment.api + "WorkshopEquipment/DeleteEquipment2?Description=" + description);
  }

  public DeleteEquipmentPost(equipment: Equipments){

    return this.http.post<any>(environment.api + "WorkshopEquipment/DeleteEquipmentPost", equipment, this.httpDeleteOptions);
  }
}
