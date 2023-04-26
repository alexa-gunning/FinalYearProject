import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Products } from 'src/models/product';
import { ProductColors } from 'src/models/productcolors';
import { ProductPrice } from 'src/models/productprice';
import { ProductTypes } from 'src/models/producttypes';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
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
  constructor(private http: HttpClient) { }


public GetProducts(){
  return this.http.get(environment.api + "Product/GetProducts");
}
public GetJustProducts(){
  return this.http.get(environment.api + "Product/GetJustProducts");
}
public GetColors(){
  return this.http.get(environment.api + "Product/GetColors");
}
public GetTypes(){
  return this.http.get(environment.api + "Product/GetTypes");
}

public AddProduct(ProductForm:any){
  var added = {
    "productName": ProductForm.productName,
    "productColourId": ProductForm.productColourId,
    "productTypeId": ProductForm.productTypeId, 
    "price": ProductForm.price, 
    "quantityOnHand": ProductForm.quantityOnHand,
}
  return this.http.post(environment.api + "Product/AddProduct", added, this.httpOptions);
}
public AddProductPrice(ProductPriceForm:any){
  var added = {
    "productId": ProductPriceForm.productId,
    "productPrice1": ProductPriceForm.productPrice1
}
  return this.http.post(environment.api + "Product/AddProductPrice", added);
}
public AddColor(ProductColorForm:any){
  var added = {
    "colorName": ProductColorForm.colorName,
    "description": ProductColorForm.description
}
  return this.http.post(environment.api + "Product/AddColor", added);
}
public AddType(ProductTypeForm:any){
  var added = {
    "productTypeName": ProductTypeForm.productTypeName,
    "description": ProductTypeForm.description
}
  return this.http.post(environment.api + "Product/AddType", added);
}
public DeleteProduct(productId: Products){

  return this.http.post<any>(environment.api + "Product/DeleteProduct", productId, this.httpDeleteOptions);
}
public DeleteColor(productColorId: ProductColors){

  return this.http.post<any>(environment.api + "Product/DeleteColor", productColorId, this.httpDeleteOptions);
}
public DeleteType(productTypeId: ProductTypes){

  return this.http.post<any>(environment.api + "Product/DeleteType", productTypeId, this.httpDeleteOptions);
}
public UpdateColor(productColorId, uColorForm){
  let u = {
    "colorName": uColorForm.colorName,
    "description": uColorForm.description
}
  return this.http.put(environment.api + "Product/UpdateColor?id=" + productColorId, u, this.httpOptions);
}
public UpdateType(productTypeId, uTypeForm){
  let u = {
    "productTypeName": uTypeForm.productTypeName,
    "description": uTypeForm.description
}
  return this.http.put(environment.api + "Product/UpdateType?id=" + productTypeId, u, this.httpOptions);
}
public GetColorByID(productColorId){
  return this.http.get(environment.api + "Product/GetColorByID?id=" + productColorId);
}
public GetTypeByID(productTypeId){
  return this.http.get(environment.api + "Product/GetTypeByID?id=" + productTypeId);
}

public GetProductPerformanceReport(){
  return this.http.get(environment.api + "Product/GetProductPerformanceReport");
}
public UpdateProduct(productId, uProductForm){
  let uhost = {
    "productName": uProductForm.productName,
    "productColourId": uProductForm.productColourId,
    "productTypeId": uProductForm.productTypeId, 
    "price": uProductForm.price, 
    "quantityOnHand": uProductForm.quantityOnHand,
}
  return this.http.put(environment.api + "Product/UpdateProduct?id=" + productId, uhost, this.httpOptions);
}
public GetProductByID(productId){
  return this.http.get(environment.api + "Product/GetProductByID?id=" + productId);
}
}
