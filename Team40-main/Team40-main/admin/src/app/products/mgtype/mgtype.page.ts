import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WindowScrollController } from '@fullcalendar/angular';
import { ToastController } from '@ionic/angular';
import { ProductTypes } from 'src/models/producttypes';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-mgtype',
  templateUrl: './mgtype.page.html',
  styleUrls: ['./mgtype.page.scss'],
})
export class MgtypePage implements OnInit {
types: ProductTypes[];
  constructor(private service: ProductService, private router: Router, private toast: ToastController) { }
  ngOnInit(): void {
    this.types = [];
    this.service.GetTypes().subscribe(res =>{
    var types = res as any[]
    for(var i = 0; i <types.length; i++){
      var Item = new ProductTypes();
      Item.description = res[i].description;
      Item.productTypeId = res[i].productTypeId;
      Item.productTypeName= res[i].productTypeName;
      this.types.push(Item);
      console.log(Item)
    }
    });
  }

Update(productTypeId){
  localStorage.setItem("productTypeId", JSON.stringify(productTypeId));
  console.log(JSON.parse(localStorage.getItem("productTypeId")))
  this.router.navigate(['./utype']);
}

Delete(productTypeId: any){

this.service.DeleteType(productTypeId).subscribe(res =>{
  this.presentToast();
  window.location.reload();
}, (response: HttpErrorResponse) => {
  this.presentErrorToast2();
   });
}
async presentErrorToast2() {
  const toast = await this.toast.create({
    message: 'Product type cannot be deleted.',
    duration: 2000
  });
  toast.present();
  }
async presentToast() {
const toast = await this.toast.create({
message: 'Product type deleted.',
duration: 2000
});
toast.present();
}
HomeBtn()
{
this.router.navigate(['./tabs/products']);
}
}

