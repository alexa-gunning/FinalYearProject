import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Supplier } from 'src/models/supplier';
import { Supplierpurchases } from 'src/models/supplierpurchases';
import { suppurchasedelete } from 'src/models/suppurchasedelete';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
    })
  }
  httpDeleteOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json, text/plain, charset=utf-8 ',
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',

    })
  };

  public GetAllSupplier(){
    return this.http.get(environment.api + "Supplier/GetAllSuppliers");
  }

  public GetSupplierByID(supplierId){
    return this.http.get(environment.api+"Supplier/GetSupplierById?id=" + supplierId);
  }

  public AddSupplier(SupplierForm:any){ 
    var addedsupplier = {
      "supplierId" : SupplierForm.supplierId,
      "supplierName" : SupplierForm.supplierName,
      "supplierPhoneNumber" : SupplierForm.supplierPhoneNumber,
      "supplierEmail" : SupplierForm.supplierEmail,
      "supplierAddress" : SupplierForm.supplierAddress
  }
    return this.http.post(environment.api + "Supplier/AddSupplier", addedsupplier);
  }

  public UpdateSupplier(supplierId, SupplierForm)
  {
    let uSupplier = {
      "supplierName": SupplierForm.supplierName,
      "supplierPhoneNumber": SupplierForm.supplierPhoneNumber,
      "supplierEmail": SupplierForm.supplierEmail,
      "supplierAddress": SupplierForm.supplierAddress,
    }
    return this.http.put(environment.api +"Supplier/UpdateSupplier?id="+ supplierId,uSupplier, this.httpOptions);
  }
  public UpdateInventory(id, quantity){
 
  
  return this.http.put(environment.api + "Supplier/UpdateInventory?id=" + id + "&quantity=" + quantity, this.httpOptions);
  }
  public DeleteSupplierPost(supplierId: Supplier){

    return this.http.post<any>( environment.api + "Supplier/DeleteSupplierPost", supplierId, this.httpDeleteOptions);
  }
  public DeleteSupplierPurchase(supplierPurchaseId: Supplierpurchases){

    return this.http.post<any>( environment.api + "Supplier/DeleteSupplierPurchase", supplierPurchaseId, this.httpDeleteOptions);
  }
  public AddSupplierPurchase(PurchaseForm:any){
    var added = {
      "supplierId": PurchaseForm.supplierId,
      "inventoryId": PurchaseForm.inventoryId,
      "quantityPurchased": PurchaseForm.quantityPurchased, 
      "price": PurchaseForm.price, 
      "date": PurchaseForm.date, 
  }
    return this.http.post(environment.api + "Supplier/AddSupplierPurchase", added);
  }
  public UpdateSupplierPurchase(supplierPurchaseId, uPurchaseForm){
    let u = {
      "supplierId": uPurchaseForm.supplierId,
      "inventoryId": uPurchaseForm.inventoryId,
      "quantityPurchased": uPurchaseForm.quantityPurchased, 
      "price": uPurchaseForm.price, 
      "date": uPurchaseForm.date, 
  }
    return this.http.put(environment.api + "Supplier/UpdateSupplierPurchase?id=" + supplierPurchaseId, u, this.httpOptions);
  }
  public GetPurchaseByID(supplierPurchaseId){
    return this.http.get(environment.api+"Supplier/GetPurchaseById?id=" + supplierPurchaseId);
  }
}

