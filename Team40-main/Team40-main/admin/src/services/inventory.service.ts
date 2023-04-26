import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { InventoryItem } from 'src/models/inventoryitem';
import { WriteOffInventory } from 'src/models/writeoffinventory';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

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
  public GetAllInventory(){
    return this.http.get(environment.api + "Inventory/GetAllInventory");
  }
  public AddInventory(ItemForm:any){
    var addedinventory = {
      "itemName": ItemForm.itemName,
      "quantityOnHand": ItemForm.quantityOnHand,
      "lastUpdated": ItemForm.lastUpdated,
  }
    return this.http.post(environment.api + "Inventory/AddInventory", addedinventory);
  }
  public GetInventoryByID(inventoryId){
    return this.http.get(environment.api + "Inventory/GetInventoryByID?id=" + inventoryId);
  }
  public UpdateInventory(inventoryId, uItemForm){
    let uinventory = {
      "itemName": uItemForm.itemName,
      "quantityOnHand": uItemForm.quantityOnHand,
      "lastUpdated": uItemForm.lastUpdated,
  }
    return this.http.put(environment.api + "Inventory/UpdateInventory?id=" + inventoryId, uinventory, this.httpOptions);
  }
  public GetInventoryReport(){
    return this.http.get(environment.api + "Inventory/GetInventoryReport");
  }
  public GetPurchases(){
    return this.http.get(environment.api + "Supplier/GetPurchases");
  }
  public GetInventoryCalculations(){
    return this.http.get(environment.api + "Inventory/GetInventoryCalculations");
  }
  public GetTopSuppliers(){
    return this.http.get(environment.api + "Inventory/GetTopSuppliers");
  }
  public DeleteInventory2(itemName){
 
    return this.http.delete( environment.api + "Inventory/DeleteInventory2?ItemName=" + itemName);
  }
  public DeleteItemPost(host: InventoryItem){

    return this.http.post<any>( environment.api + "Inventory/DeleteItemPost", host, this.httpDeleteOptions);
  }

  public GetAllWrittenOffInventory()
  {
    return this.http.get(environment.api+ "WriteOffInventory/GetWrittenOffItems")
  }

  public WriteOffInventory(WriteOffForm: any)
  {
    var item =
    {
      "inventoryId" :WriteOffForm.inventoryId,
      "writeOffReasonId": WriteOffForm.writeOffReasonId,
      "writeOffDate": WriteOffForm.writeOffDate,
      "writeOffQty": WriteOffForm.writeOffQty,
      "name": WriteOffForm.name,

    }
    return this.http.post(environment.api + "WriteOffInventory/CreateWriteOff",item, this.httpOptions)
  }

  public GetAllReasons(){
    return this.http.get(environment.api + "WriteOffReason/GetAllWriteOffReasons2");
  }

  
  public UpdateInventoryQty(id, quantity){
 
  
    return this.http.put(environment.api + "WriteOffInventory/UpdateInventory?id=" + id + "&quantity=" + quantity, this.httpOptions);
    }
    public UpdateInventoryWithDelete(id, quantity){
 
  
      return this.http.put(environment.api + "WriteOffInventory/UpdateInventoryWithDelete?id=" + id + "&quantity=" + quantity, this.httpOptions);
      }
      public UpdateInventoryWithDeleteSP(id, quantity){
 
  
        return this.http.put(environment.api + "WriteOffInventory/UpdateInventoryWithDeleteSP?id=" + id + "&quantity=" + quantity, this.httpOptions);
        }
  public UpdateInventoryQtyWithUpdate(id, quantitynow, quantityupdated){
 
  
    return this.http.put(environment.api + "WriteOffInventory/UpdateInventoryWithUpdate?id=" + id + "&quantitynow=" + quantitynow + "&quantityupdated=" + quantityupdated, this.httpOptions);
  }
    public UpdateWriteOff(writeoffId, WriteOffForm)
    {
      var item =
    {
      "inventoryId" :WriteOffForm.inventoryId,
      "writeOffReasonId": WriteOffForm.writeOffReasonId,
      "writeOffDate": WriteOffForm.writeOffDate,
      "writeOffQty": WriteOffForm.writeOffQty,
      "name": WriteOffForm.name,

    }
    return this.http.put(environment.api + "WriteOffInventory/UpdateWriteOff?id="+writeoffId,WriteOffForm, this.httpOptions)
    }

    public DeleteWriteOffPost(WriteOffInventory: WriteOffInventory)
    {

      return this.http.post<any>( environment.api + "WriteOffInventory/DeleteWriteOffPut", WriteOffInventory, this.httpDeleteOptions);
    }

    public GetWritenOffItemById(writeoffId){
      return this.http.get(environment.api + "WriteOffInventory/GetWriteOffById?id=" + writeoffId);
    }
}
