import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkshopService } from 'src/services/workshop.service';
import { WorkshopPerformanceReport } from 'src/models/WorkshopPerformanceReport';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-workshopperformance',
  templateUrl: './workshopperformance.page.html',
  styleUrls: ['./workshopperformance.page.scss'],
})

export class WorkshopperformancePage {
  
  workshop: WorkshopPerformanceReport[]
  today = Date();
  constructor(private router: Router, private service: WorkshopService) { }

  ionViewWillEnter(): void {
  this.workshop = [];
  this.service.GetWorkshopPerformanceReport().subscribe(res =>{
  var workshop = res as any[]
  for(var i = 0; i < workshop.length; i++){
  var Item = new WorkshopPerformanceReport();

    Item.workshoptype=res[i].workshoptype;
    Item.netprofit=res[i].netprofit;
    Item.numerattended=res[i].numerattended;
    Item.salesrevenue = res[i].numerattended * res[i].workshopprice;
    Item.totalBookings = res[i].totalBookings;
    Item.workshopdate = res[i].workshopdate;
    Item.workshopprice = res[i].workshopprice;
    Item.workshopvenue = res[i].workshopvenue;

  this.workshop.push(Item);
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
    PDF.save('WorkshopPerformanceReport.pdf');
  }

  )
}


}



