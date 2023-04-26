import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientandAddress } from 'src/models/ClientandAddress';
import { Clients } from 'src/models/clients';
import { ClientService } from 'src/services/client.service';
import { ItemsPageRoutingModule } from 'src/app/inventory/items/viewitems/items-routing.module';
import { ToastController } from '@ionic/angular';
@Component({
  selector: 'app-client',
  templateUrl: './client.page.html',
  styleUrls: ['./client.page.scss'],
})
export class ClientPage implements OnInit {
  items: Clients[];
  searchTermClient: string;
  constructor(private router: Router, private service: ClientService, private toast: ToastController) {

   }

  ionViewWillEnter(): void {
    this.items = [];
    this.service.GetAllClients().subscribe(res =>{
    var items = res as any[]
    for(var i = 0; i < items.length; i++){
      var Item = new Clients();
      Item.clientId = res[i].clientId;
      Item.name = res[i].name;
      Item.surname= res[i].surname;
      Item.emailAddress = res[i].emailAddress;
      Item.birthDate= res[i].birthDate;
      Item.phoneNumber= res[i].phoneNumber;
      // Item.streetName= res[i].streetName;
      // Item.streetNumber= res[i].streetNumber;
      // Item.city= res[i].city;
      // Item.province= res[i].province;
      // Item.areaCode = res[i].areaCode;
      // Item.country= res[i].country;
      this.items.push(Item);
    }
    });

  }

  ngOnInit() {
  }
  AddBtn(){
    this.router.navigate(['./createclient']);
  }
  Update(clientId){
    localStorage.setItem("clientId", JSON.stringify(clientId));
    this.router.navigate(['./updateclient']);
  }
  Delete(clientId: any){
    this.service.DeleteClient(clientId).subscribe(res =>{
    });
    this.presentToast();
    window.location.reload(); 
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Client deleted.',
      duration: 2000
    });
    toast.present();
  }
}
