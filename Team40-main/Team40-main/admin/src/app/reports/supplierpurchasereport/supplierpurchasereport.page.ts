import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InventoryService } from 'src/services/inventory.service';
import { Supplierreport } from 'src/models/Supplierreport';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-supplierpurchasereport',
  templateUrl: './supplierpurchasereport.page.html',
  styleUrls: ['./supplierpurchasereport.page.scss'],
})
export class SupplierpurchasereportPage  {

  supplier: Supplierreport[]
  today = Date();
  constructor(private router: Router, private service: InventoryService) { }
  ionViewWillEnter(): void {
    this.supplier = [];
    this.service.GetTopSuppliers().subscribe(res =>{
    var supplier = res as any[]
    for(var i = 0; i < supplier.length; i++){
    var Item = new Supplierreport();
    Item.price = res[i].price;
    Item.quantityPurchased= res[i].quantityPurchased;
   Item.supplierName = res[i].supplierName;
   Item.supplierPhoneNumber = res[i].supplierPhoneNumber;
   Item.count = res[i].count;
    Item.totalCost = res[i].totalCost;
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
    PDF.save('SupplierPurchaseReport.pdf');
  }

  )
}

}
