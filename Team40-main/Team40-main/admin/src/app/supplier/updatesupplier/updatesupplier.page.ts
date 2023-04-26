import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { SupplierService } from 'src/app/services/supplierservice.service';
import { Supplier } from 'src/models/supplier';
import { Validators } from '@angular/forms';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-updatesupplier',
  templateUrl: './updatesupplier.page.html',
  styleUrls: ['./updatesupplier.page.scss'],
})
export class UpdatesupplierPage implements OnInit {

  SupplierForm: FormGroup;
  supplier: Supplier;
  supplierList: Supplier[];
  supplierComp: any;
  res: string;
  info;
  constructor(private router: Router, private supplierService: SupplierService, private toastCtrl: ToastController,  private formBuilder: FormBuilder)
   {
    this.SupplierForm = this.formBuilder.group({
      supplierName:['',Validators.required],
      supplierPhoneNumber:['',Validators.required],
      supplierEmail:['',Validators.required],
      supplierAddress: ['',Validators.required]

    });

    }

    ionViewWillEnter(): void{
      var supplierId = JSON.parse(localStorage.getItem("supplierId"))
      this.res='';
      this.supplierService.GetSupplierByID(supplierId).subscribe((res:any) =>{
        this.supplierComp = res;
        console.log(this.supplierComp)
      })
    }

  ngOnInit() {
  }

  Update(){
    var supplierId = JSON.parse(localStorage.getItem("supplierId"));
    if(this.SupplierForm.valid ==true){
      this.supplierService.UpdateSupplier(supplierId, this.SupplierForm.value).subscribe((res:any) => {
      
      this.router.navigate(['./tabs/supplier']);
      this.presentToast()
      })
      
      
    }
    else{
      return;
    }
  }

  async presentToast(){
    const toast = await this.toastCtrl.create({
      message: 'Supplier Details Successfully Updated!',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toastCtrl.create({
      message: 'Sorry! This Supplier already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/supplier']);
  }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toastCtrl.create({
      message: 'Please enter the details of the supplier company to store in the database. You can view the supplier company details in the view page.',
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

