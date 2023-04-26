import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ProductColors } from 'src/models/productcolors';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-mgcolor',
  templateUrl: './mgcolor.page.html',
  styleUrls: ['./mgcolor.page.scss'],
})
export class MgcolorPage implements OnInit {

  colors: ProductColors[];
  constructor(private service: ProductService, private router: Router, private toast: ToastController) { 
    }
  ngOnInit(): void {
    this.colors = [];
  this.service.GetColors().subscribe(res =>{
  var colors = res as any[]
  for(var i = 0; i < colors.length; i++){
    var Item = new ProductColors();
    Item.description = res[i].description;
    Item.productColorId = res[i].productColorId;
    Item.colorName = res[i].colorName;
    this.colors.push(Item);
    console.log(Item);
  }
  });
  }
 

// IonicViewWillEnter(): void {
//   this.colors = [];
//   this.service.GetColors().subscribe(res =>{
//   var colors = res as any[]
//   for(var i = 0; i < colors.length; i++){
//     var Item = new ProductColors();
//     Item.description = res[i].description;
//     Item.productColorId = res[i].productColorId;
//     Item.colorName = res[i].colorName;
//     this.colors.push(Item);
//     console.log(Item);
//   }
//   });

// }
Update(productColorId){
  localStorage.setItem("productColorId", JSON.stringify(productColorId));
  console.log(JSON.parse(localStorage.getItem("productColorId")))
  this.router.navigate(['./ucolor']);
}

Delete(productColorId: any){

this.service.DeleteColor(productColorId).subscribe(res =>{
  this.presentToast();
  window.location.reload();
}, (response: HttpErrorResponse) => {
  this.presentErrorToast2();
   });
}
async presentErrorToast2() {
  const toast = await this.toast.create({
    message: 'Colour cannot be deleted.',
    duration: 2000
  });
  toast.present();
  }
async presentToast() {
const toast = await this.toast.create({
message: 'Colour deleted.',
duration: 2000
});
toast.present();
}
HomeBtn()
{
this.router.navigate(['./tabs/products']);
}

}
