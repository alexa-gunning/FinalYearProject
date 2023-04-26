import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HostService } from 'src/services/host.service';
import { Hosts } from 'src/models/hosts';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-host',
  templateUrl: './host.page.html',
  styleUrls: ['./host.page.scss'],
})
export class HostPage {
  Host: Hosts[]
  searchTerm: string;
  host;
  constructor(private router: Router, private service: HostService, private toast: ToastController) { }

  ionViewWillEnter(): void {
  this.Host = [];
  this.service.GetAllHosts().subscribe(res =>{
  var Host = res as any[]
  for(var i = 0; i < Host.length; i++){
    var Item = new Hosts();
    Item.hostId = res[i].hostId;
    Item.hostName = res[i].hostName;
    Item.hostSurname = res[i].hostSurname;
    Item.hostEmail = res[i].hostEmail;
    this.Host.push(Item);
    }
    })
  };


  getHosts(){
    this.Host = [];
    this.service.GetAllHosts().subscribe(res =>{
    var Host = res as any[]
    for(var i = 0; i < Host.length; i++){
    var Item = new Hosts();
    Item.hostId = res[i].hostId;
    Item.hostName = res[i].hostName;
    Item.hostSurname = res[i].hostSurname;
    Item.hostEmail = res[i].hostEmail;
    this.Host.push(Item);
    }
    });
  }

  AddBtn(){
    this.router.navigate(['./addhost']);
  }

  Update(hostId){
    localStorage.setItem("hostId", JSON.stringify(hostId));
    console.log(JSON.parse(localStorage.getItem("hostId")))
    this.router.navigate(['./updatehost']);
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }

  Delete(hostId: any){
    this.service.DeleteHostPost(hostId).subscribe(res =>{
    });
    this.presentToast();
    window.location.reload();
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Host deleted.',
      duration: 2000
    });
    toast.present();
  }

}
