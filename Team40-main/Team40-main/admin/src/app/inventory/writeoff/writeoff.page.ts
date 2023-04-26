import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReasonService } from 'src/services/reason.service';
import { Reasons } from 'src/models/reasons';
import { Observable } from 'rxjs';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-writeoff',
  templateUrl: './writeoff.page.html',
  styleUrls: ['./writeoff.page.scss'],
})
export class WriteoffPage implements OnInit {

  searchTerm: string;
  reasons: Reasons[];

  constructor(private router: Router, private service: ReasonService, private toast: ToastController) { }

  ionViewWillEnter(): void {
    this.reasons = [];
    this.service.GetAllReasons().subscribe(res => {
    var items = res as any[]
    for(var i = 0; i < items.length; i++){
      var Reason = new Reasons();
      Reason.writeOffReasonId = res[i].writeOffReasonId;
      Reason.writeOffReasonDescription= res[i].writeOffReasonDescription;
      this.reasons.push(Reason);
      console.log(Reason)
    }
    }); 
  }

  ngOnInit() {
  }

  AddBtn()
  {
    this.router.navigate(['./writeoffcreate']);
  }

  AddBtn1()
  {
    this.router.navigate(['./item']);
  }

  Update(writeOffReasonId: any){
    localStorage.setItem("work", JSON.stringify(writeOffReasonId));
    console.log(JSON.parse(localStorage.getItem("writeOffReasonId")))
    this.router.navigate(['./updatewriteoff']);
  }

  HomeBtn()
  {
    this.router.navigate(['./item']);
  }

  Delete(writeOffReasonId: any){

    this.service.DeleteReasonPost(writeOffReasonId).subscribe(res =>{
      this.presentToast();
      window.location.reload();
    });

  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Write-Off Reason deleted.',
      duration: 2000
    });
    toast.present();
    }

}
