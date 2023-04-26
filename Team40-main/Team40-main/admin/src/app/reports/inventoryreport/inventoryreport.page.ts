import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InventoryService } from 'src/services/inventory.service';
import { Inventorysupplier } from 'src/models/Inventorysupplier';
import { InventoryReport } from 'src/models/inventoryreport';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
@Component({
  selector: 'app-inventoryreport',
  templateUrl: './inventoryreport.page.html',
  styleUrls: ['./inventoryreport.page.scss'],
})
export class InventoryreportPage  {


  supplier: InventoryReport[]
  today = Date();
  constructor(private router: Router, private service: InventoryService) { }

  ionViewWillEnter(): void {
  this.supplier = [];
  this.service.GetInventoryReport().subscribe(res =>{
  var supplier = res as any[]
  for(var i = 0; i < supplier.length; i++){
  var Item = new InventoryReport();
  Item.price = res[i].price;
  Item.quantityPurchased= res[i].quantityPurchased;
  Item.quantityOnHand = res[i].quantityOnHand;
  Item.total = res[i].total;
  Item.actualqty = res[i].actualqty;
  Item.itemName = res[i].itemName;
  this.supplier.push(Item);
}
});
  }

  HomeBtn()
{
  this.router.navigate(['./tabs/reports']);
}
public openPDF(){
  let Data = document.getElementById('htmlData')!;

  html2canvas(Data).then(canvas => {
    let fileWidth = 210;
    let fileHeight = canvas.height * fileWidth / canvas.width;

    const contentDataUrl = canvas.toDataURL('image/png');

    let PDF = new jsPDF({
      orientation: 'p',
      unit: 'mm',
      format: 'a4'
    });

    let topPosition = 10;
    let leftPosition = 0;

    PDF.addImage(contentDataUrl, 'PNG', leftPosition, topPosition, fileWidth, fileHeight);
    PDF.save('InventoryReport.pdf');
  }

  )
}
}
