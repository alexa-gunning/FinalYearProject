import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Supplier } from 'src/models/supplier';
import { SupplierService } from '../services/supplierservice.service';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.page.html',
  styleUrls: ['./supplier.page.scss'],
})
export class SupplierPage implements OnInit {

  searchTerm: string;
  Supply: Supplier [];
  constructor(private router: Router, private service: SupplierService, private toast: ToastController) { }
  ngOnInit(): void {
    
  }

  ionViewWillEnter(): void{
    this.Supply=[]
    this.service.GetAllSupplier().subscribe(res =>{
      var Supply = res as any[]
      for(var i=0; i<Supply.length;i++)
      {
        var Item = new Supplier();
        Item.supplierName= res[i].supplierName;
        Item.supplierPhoneNumber =res[i].supplierPhoneNumber;
        Item.supplierEmail=res[i].supplierEmail;
        Item.supplierAddress=res[i].supplierAddress;
        Item.supplierId=res[i].supplierId;
        // Item.method=res[i].method;
        this.Supply.push(Item)
      }
    });
  }


  AddBtn(){
    this.router.navigate(['./addsupplier']);
  }
  Update(supplierId){
    localStorage.setItem("supplierId", JSON.stringify(supplierId));
 
    this.router.navigate(['./updatesupplier']);
  }

  HomeBtn()
  {
    this.router.navigate(['./tabs/supplier']);
  }
  Delete(supplierId: any){
  
    this.service.DeleteSupplierPost(supplierId).subscribe(res =>{
      this.presentToast();
    });
 
    
    // this.router.navigate(['./tabs/supplier']);
  }
  async presentToast() {
    const toast = await this.toast.create({
      message: 'Supplier Successfully Deleted.',
      duration: 2000,
      position:'middle'
    });
    toast.present();
    }
}
