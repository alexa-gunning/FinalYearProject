import { Component , ElementRef,ViewChild} from '@angular/core';
import { Chart } from 'chart.js';
import { LineController,LineElement,PointElement, LinearScale,Title,CategoryScale,BarController,BarElement } from 'chart.js';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { Router } from '@angular/router';

//import { title } from 'process';


Chart.register(LineController,LineElement,PointElement, LinearScale,Title,CategoryScale,BarController,BarElement );
@Component({
  selector: 'app-orderreport',
  templateUrl: './orderreport.page.html',
  styleUrls: ['./orderreport.page.scss'],
})
export class OrderreportPage  {

  @ViewChild('barCanvas') public barCanvas: ElementRef;
  barChart: any;
  constructor(private router: Router) { }


  ionViewWillEnter(){
    //this.barChartMethod();
  //}

  //barChartMethod(){
    this.barChart =new Chart(this.barCanvas.nativeElement,
      {
      
      type:'bar',
      data:{
        labels:[2017,2018,2019,2020,2021,2022],
        
        datasets: [{
          barPercentage: 0.8,
          barThickness: 'flex',
          label: "Placed",
          stack:"Base",
          backgroundColor:"#0000FF",
          data: [10,12,8,11,13],
        },{
          barPercentage: 0.8,
          barThickness: 'flex',
          label: "Completed",
          stack:"Sensitivity",
          backgroundColor:"#00FF00",
          data: [8,9,4,11,7],

        },
        {
          barPercentage: 0.8,
          barThickness: 'flex',
          label: "Cancelled",
          stack:"true",
          backgroundColor:"#FF0000",
          data: [2,3,4,0,6],
          

        },

      ]
      },
      options: {
        scales: {
          y:
          {//[{
            //ticks: {
             beginAtZero: true
            //}
         //}]
        }
        }
      }
    })
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
        format: 'a4',
        
        
      });

      let topPosition = 10;
      let leftPosition = 0;

      PDF.addImage(contentDataUrl, 'PNG', leftPosition, topPosition, fileWidth, fileHeight);
      PDF.save('OrdersReport.pdf');
    }

    )
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/reports']);
  }

}
