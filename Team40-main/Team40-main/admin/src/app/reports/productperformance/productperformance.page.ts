import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/services/product.service';
import { ProductPerformanceReport } from 'src/models/productperformancereport';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-productperformance',
  templateUrl: './productperformance.page.html',
  styleUrls: ['./productperformance.page.scss'],
})
export class ProductperformancePage {
  
  product: ProductPerformanceReport[]
  today = Date();
  constructor(private router: Router, private service: ProductService) { }

  ionViewWillEnter(): void {
  this.product = [];
  this.service.GetProductPerformanceReport().subscribe(res =>{
  var product = res as any[]
  for(var i = 0; i < product.length; i++){
  var Item = new ProductPerformanceReport();
  Item.productname  = res[i].productName;
  Item.totalProductSold  = res[i].totalProductSold;
  Item.salesRevenue = res[i].salesRevenue;
  Item.costOfProduction = res[i].costOfProduction;
  Item.netprofit = res[i].salesRevenue - res[i].costOfProduction;
  this.product.push(Item);
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
    PDF.save('ProductPerformanceReport.pdf');
  }

  )
}


}



