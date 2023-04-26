import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ProductColors } from 'src/models/productcolors';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-ucolor',
  templateUrl: './ucolor.page.html',
  styleUrls: ['./ucolor.page.scss'],
})
export class UcolorPage implements OnInit{
res: string;
  uColorForm: FormGroup;
  item: ProductColors[];
  constructor(private service: ProductService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.uColorForm = this.formBuilder.group({
      colorName: ['',Validators.required],
     description:['',Validators.required],
      
     });
  }
  ngOnInit(): void {
    var productColorId = JSON.parse(localStorage.getItem("productColorId"))
    this.res = '';
    this.service.GetColorByID(productColorId).subscribe((res: any)  =>{
     this.item = res;
    console.log(this.item);
       }   )
  }
  // IonViewWillEnter(): void {
  //   var productColorId = JSON.parse(localStorage.getItem("productColorId"))
  //   this.res = '';
  //   this.service.GetColorByID(productColorId).subscribe((res: any)  =>{
  //    this.item = res;
  //   console.log(this.item);
  //      }   ) }



  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the color you want to update to store in the database. You can then go and select it when adding a product.',
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


update(){


  var productColorId = JSON.parse(localStorage.getItem("productColorId"))
  if(this.uColorForm.valid == true){
  this.service.UpdateColor(productColorId, this.uColorForm.value).subscribe((res: any) =>{
    this.router.navigate(['./mgcolor']);
    this.presentToast();
  }), (response: HttpErrorResponse) => {
    this.presentErrorToast();
     }

}
else{
return;
}}

  

  async presentToast() {
    const toast = await this.toast.create({
      message: 'Color Updated.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This color already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./mgcolor']);
  }

}