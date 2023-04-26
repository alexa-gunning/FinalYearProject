import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { InventoryService } from 'src/services/inventory.service';
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-additems',
  templateUrl: './additems.page.html',
  styleUrls: ['./additems.page.scss'],
})
export class AdditemsPage  {

  ItemForm: FormGroup;
  constructor(private service: InventoryService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.ItemForm = this.formBuilder.group({
      itemName: ['',Validators.required],
      quantityOnHand:['',Validators.required],
      lastUpdated:['',Validators.required]
     });
  }
  Info(){
    this.infoToast();
  }
  async infoToast(){
    const toast = await this.toast.create({
      message: 'Please enter the details of the item to store in the database. You can view the items in the view page.',
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

getDate(){
  const date = new Date();
  date.toLocaleString("en-GB");
  console.log(date);
  return date;
}

  addItem(){
    if (this.ItemForm.valid == true) {
    this.service.AddInventory(this.ItemForm.value).subscribe(() =>{
      this.router.navigate(['./items']);
      this.presentToast()
    } , (response: HttpErrorResponse) => {
      this.presentErrorToast();
       })


  }
    else {
      return;
    }
  }

  async presentToast() {
    const toast = await this.toast.create({
      message: 'New item added.',
      duration: 2000
    });
    toast.present();
  }
  async presentErrorToast() {
    const toast = await this.toast.create({
      message: 'This item already exists.',
      duration: 2000
    });
    toast.present();
  }

  HomeBtn()
  {
    this.router.navigate(['./items']);
  }

}
