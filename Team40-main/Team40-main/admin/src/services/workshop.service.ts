import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Venue } from 'src/models/venue';
import { Type } from 'src/models/workhoptype';
import { Slots } from 'src/models/slots';
@Injectable({
  providedIn: 'root'
})
export class WorkshopService {

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

public GetAll(){
  return this.http.get(environment.api + "WorkshopVenue/GetAll");
}
public GetBookingsWithClients(){
  return this.http.get(environment.api + "Booking/GetBookingsWithClients");
}
public AddWorkshopVenue(VenueForm:any){
  var addedvenue = {
    "venueName": VenueForm.venueName,
    "address": VenueForm.address
}
  return this.http.post(environment.api + "WorkshopVenue/AddWorkshopVenue", addedvenue);
}
public UpdateWorkshopVenue(workshopVenueId, uVenueForm){
  let uvenue = {
    "venueName": uVenueForm.venueName,
    "address": uVenueForm.address,
}

  return this.http.put(environment.api + "WorkshopVenue/UpdateWorkshopVenue?id=" + workshopVenueId, uvenue, this.httpOptions);
}
public GetWorkshopVenueByID(workshopVenueId){
  return this.http.get(environment.api + "WorkshopVenue/GetWorkshopVenueByID?id=" + workshopVenueId);
}
public DeleteVenue2(venueName){

  return this.http.delete( environment.api + "WorkshopVenue/DeleteVenue2?VenueName=" + venueName);
}


public GetAllTypes(){
  return this.http.get(environment.api + "WorkshopType/GetAll");
}
public GetSlots(){
  return this.http.get(environment.api + "WorkshopSlot/GetSlots");
}
public AddWorkshopType(TypeForm:any){
  var added = {
    "description": TypeForm.description
}
  return this.http.post(environment.api + "WorkshopType/AddWorkshopType", added);
}
public UpdateWorkshopType(workshopTypeId, uTypeForm){
  let u = {
   "description": uTypeForm.description
}

  return this.http.put(environment.api + "WorkshopType/UpdateWorkshoptype?id=" + workshopTypeId, u, this.httpOptions);
}
public GetWorkshopTypeByID(workshopTypeId){
  return this.http.get(environment.api + "WorkshopType/GetWorkshopTypeByID?id=" + workshopTypeId);
}
public DeleteType2(description){

  return this.http.delete( environment.api + "WorkshopType/DeleteType2?Description=" +description);
}
public DeleteVenuePost(host: Venue){

  return this.http.post<any>( environment.api + "WorkshopVenue/DeleteVenuePost", host, this.httpDeleteOptions);
}
public DeleteTypePost(host: Type){

  return this.http.post<any>( environment.api + "WorkshopType/DeleteTypePost", host, this.httpDeleteOptions);
}

public AddSlot(WSlotForm: any)
{
var addedSlot= {
  "workshopTypeId" : WSlotForm.workshopTypeId,
  "workshopVenueId": WSlotForm.workshopVenueId,
  "hostId" : WSlotForm.hostId,
  "price": WSlotForm.price,
  "workshopDate": WSlotForm.workshopDate
}
// 
return this.http.post(environment.api + "WorkshopSlot/AddSlot", addedSlot, this.httpOptions)

}

public GetAllHosts(){
  return this.http.get(environment.api + "WorkshopSlot/GetAllHosts");
}

public GetAllVenues(){
  return this.http.get(environment.api + "WorkshopSlot/GetAllVenues");
}

public GetAllWTypes(){
  return this.http.get(environment.api + "WorkshopSlot/GetAllWTypes");
}

public UpdateWSlot(wSlotId, uSlotForm){
  let u = {
    // "workshopId": uWSlotId.workshopId,
    "workshopTypeId": uSlotForm.workshopTypeId,
    "workshopVenueId": uSlotForm.workshopVenueId,
    "hostId" : uSlotForm.hostId,
    "price": uSlotForm.price,
    "workshopDate": uSlotForm.workshopDate
}

return this.http.put(environment.api + "WorkshopSlot/UpdateWSlot?id=" + wSlotId, uSlotForm, this.httpOptions);
}


public GetWSlotByID(workshopId){
  return this.http.get(environment.api + "WorkshopSlot/GetWSlotByID?id=" + workshopId);
}

public DeleteWSlot(item: Slots){

  return this.http.post<any>( environment.api + "WorkshopSlot/DeleteWSlot", item, this.httpDeleteOptions);
}

public GetWorkshopPerformanceReport(){
  return this.http.get(environment.api + "WorkshopSlot/GetWorkshopPerformanceReport");
}



}
