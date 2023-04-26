import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from 'src/services/client.service';
import { ClientandAddress } from 'src/models/ClientandAddress';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-clientreport',
  templateUrl: './clientreport.page.html',
  styleUrls: ['./clientreport.page.scss'],
})
export class ClientreportPage implements OnInit {

  client: ClientandAddress[]
  today = Date();
  constructor(private router: Router, private service: ClientService) { }

  ionViewWillEnter(): void {
    this.client = [];
    this.service.GetAllClientsWithAddress().subscribe(res =>{
    var supplier = res as any[]
  for(var i = 0; i < supplier.length; i++) {
    var Client = new ClientandAddress();
    Client.clientId = res[i].clientId;
    Client.name = res[i].name;
    Client.surname= res[i].surname;
    Client.phoneNumber = res[i].phoneNumber;
    Client.birthDate= res[i].birthDate;
    Client.emailAddress = res[i].emailAddress;
    Client.streetNumber = res[i].streetNumber;
    Client.streetName = res[i].streetName;
    Client.city = res[i].city;
    Client.province = res[i].province;
    Client.areaCode = res[i].areaCode;
    Client.country = res[i].country;
    this.client.push(Client);
  }
  });
  }

  ngOnInit() {
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
      PDF.save('ClientReport.pdf');
    }

    )
  }
}
