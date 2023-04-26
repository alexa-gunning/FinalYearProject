/* eslint-disable @typescript-eslint/naming-convention */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-updatewriteoff',
  templateUrl: './updatewriteoff.page.html',
  styleUrls: ['./updatewriteoff.page.scss'],
})
export class UpdatewriteoffPage implements OnInit {

  constructor(private router: Router, private toast: ToastController) { }

  ngOnInit() {
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/inventoryhome']);
  }

  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the Write-Off Reason to store in the database. You can view the Write-Off Reasons in the View Write-Off Reason Page.',
      duration:5000,
      cssClass: 'custom-toast',
      buttons: [
        {
          text: 'Dismiss',
          role: 'cancel'
        }
      ],
    });
    toast.present();
  }

}
