import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DeliverycompanyService } from 'src/services/deliverycompany.service';
import { ToastController } from '@ionic/angular';
import { AlertController } from '@ionic/angular';
import { ReactiveFormsModule } from '@angular/forms';
import { Validators,FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { DeliveryCompany } from 'src/models/deliverycompany';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-deliveryupdate',
  templateUrl: './deliveryupdate.page.html',
  styleUrls: ['./deliveryupdate.page.scss'],
})
export class DeliveryupdatePage implements OnInit {

  DeliveryForm: FormGroup;
  DelCompanies: DeliveryCompany[];
  DelComp: any;
res:string;
info;

  constructor(private router: Router, private deliverCompanyService: DeliverycompanyService, private toast:ToastController, public alertCtrl: AlertController, private formBuilder: FormBuilder) 
  {
    this.DeliveryForm = this.formBuilder.group({
      deliveryCompanyName:['',Validators.required],
      deliveryCompanyEmail:['',Validators.required],
      contactPersonName:['',Validators.required],
      deliveryCompanyBaseRate: ['',Validators.required],
      // method: ['',Validators.required]

    });
   }
 

  ionViewWillEnter(): void{
    var deliveryCompanyId = JSON.parse(localStorage.getItem("deliveryCompanyId"))
    this.res='';
    this.deliverCompanyService.GetDeliveryCompanyByID(deliveryCompanyId).subscribe((res:any) =>{
      this.DelComp = res;
      console.log(this.DelComp)
    })
  }

  ngOnInit() {
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/delivery']);
  }

  Update(){
    var deliveryCompanyId = JSON.parse(localStorage.getItem("deliveryCompanyId"))
    if(this.DeliveryForm.valid ==true){
      this.deliverCompanyService.UpdateDeliveryCompany(deliveryCompanyId, this.DeliveryForm.value).subscribe(()=> {
        
      this.router.navigate(['./tabs/delivery']);
      this.presentToast()
      
    }  , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       }) 
      
      
      
    }
    else{
      return;
    }
  }

  async presentToast(){
    const toast = await this.toast.create({
      message: 'Delivery Company Details Successfully Updated!',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This delivery company already exists.',
      duration: 2000
    });
    toast.present();
  }

  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the delivery company to store in the database. You can view the delivery company details in the view page.',
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

