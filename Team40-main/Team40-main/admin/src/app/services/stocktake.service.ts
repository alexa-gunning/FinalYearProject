import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Stocktake } from 'src/models/stocktake';

@Injectable({
  providedIn: 'root'
})
export class StocktakeService {

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

  public GetAllStockTake(){
    return this.http.get(environment.api + "StockTake/GetAllStockTakeTotals2");
  }
  public GetAllStockTakes(){
    return this.http.get(environment.api + "StockTake/GetAllStockTakes");
  }

  public PerformStockTake(stocktakeform: any)
  {
    var stocktakeitem =
  {
    "stockTakeId": stocktakeform.stockTakeId,
    "StockTakeTotalQty": stocktakeform.stockTakeTotalQty,
    "StockTakeTotalId": stocktakeform.stockTakeTotalId,
    "InventoryId": stocktakeform.inventoryId,
    "Remarks": stocktakeform.remarks,

  }

  return this.http.post(environment.api + "StockTake/AddStockTakeTotal", stocktakeitem, this.httpOptions)

  }

  public GetAllInventory(){
    return this.http.get(environment.api + "Inventory/GetAllInventory");
  }

  public AddStockTake(stockform){
    var stocktake={
    "stockTakeId": stockform.stockTakeId,
    "adminId": stockform.adminId,
    "stockTakeDate": stockform.stockTakeDate,
    "name": stockform.name,
    }
    return this.http.post(environment.api +"StockTake/AddStockTake", stocktake, this.httpOptions)
  }

  public DeleteStocktakeTotal(stocktake: Stocktake){
    return this.http.post<any>( environment.api + "StockTake/DeleteStockTakeTotal", stocktake, this.httpOptions);
  }

  public UpdateStocktakeTotal(stockTakeTotalId, stocktakeform)
  {
    var stocktakeId = JSON.parse(localStorage.getItem("stockTakeId"))
    var stocktake={
      "stockTakeId": stocktakeId,
    "StockTakeTotalQty": stocktakeform.stockTakeTotalQty,
    "StockTakeTotalId": stocktakeform.stockTakeTotalId,
    "InventoryId": stocktakeform.inventoryId,
    "Remarks": stocktakeform.remarks,
      }

      return this.http.put(environment.api + "StockTake/UpdateStocktaketotal?id=" + stockTakeTotalId, stocktake, this.httpOptions);
  }

  public GetStocktaketotalById(stockTakeTotalId)
  {
    return this.http.get(environment.api + "StockTake/GetStocktakeTotalById?id=" + stockTakeTotalId);
  }

  public GetStocktakeById(stockTakeId)
  {
    return this.http.get(environment.api + "Stocktake/GetStockTakeById?id=" + stockTakeId)
  }

  public UpdateStocktake(stockTakeId, ustocktakeform)
  {
    var stocktake={
      "adminId": ustocktakeform.adminId,
      "stockTakeDate": ustocktakeform.stockTakeDate,
      "name": ustocktakeform.name,
      }
      return this.http.put(environment.api +"StockTake/UpdateStocktake?id=" + stockTakeId, stocktake, this.httpOptions)
  }
  public UpdateInventoryQty(id, quantity){
 
  
    return this.http.put(environment.api + "StockTake/UpdateInventory?id=" + id + "&quantity=" + quantity, this.httpOptions);
    }
}
