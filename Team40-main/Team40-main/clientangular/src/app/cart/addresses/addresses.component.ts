import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClientService } from 'src/app/services/client.service';
import { Address } from 'src/app/models/address';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-addresses',
  templateUrl: './addresses.component.html',
  styleUrls: ['./addresses.component.css']
})
export class AddressesComponent implements OnInit {
  addresses: any;
  constructor(private router: Router, private location: Location, private formBuilder: FormBuilder, 
    private service: ClientService, private toast: ToastrService) { 

  }

  ngOnInit(): void {
    var clientId = JSON.parse(localStorage.getItem("clientId")!)
    this.service.GetAddressByClientID(clientId).subscribe(res =>{
      this.addresses = res;
      console.log(this.addresses)
    })
  }
Back(): void{
this.location.back()
}
Add(){
  this.router.navigate(['./addaddress'])
  }
  Delete(i: Address){
    this.service.DeleteAddress(i).subscribe(res => {
   this.presentToast()
   
    },(response: HttpErrorResponse) =>{
   
     
       this.presentErrorToast();
    }
    )};
   
     async presentErrorToast(){
       this.toast.error("Could not delete address")
     }
   
   async presentToast(){
     this.toast.success("Address deleted")
   }
   Update(addressId: any){
    localStorage.setItem('updateaddressid', addressId);
    console.log(addressId)
    this.router.navigate(['./updateaddress'])
   }
}
