import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ClientService } from 'src/app/services/client.service';

@Component({
  selector: 'app-addaddress',
  templateUrl: './addaddress.component.html',
  styleUrls: ['./addaddress.component.css']
})
export class AddaddressComponent implements OnInit {
  Address!: FormGroup
  clientId: any;
  constructor(private router: Router, private formBuilder: FormBuilder, private location: Location, private service: ClientService, private toast: ToastrService) { 
    this.Address = this.formBuilder.group({
    streetNumber: ['',Validators.required],
    streetName: ['',Validators.required],

    city: ['',Validators.required],
    province: ['',Validators.required],

    areaCode: ['',Validators.required],

    })

  }

  ngOnInit(): void {
   this.clientId = JSON.parse(localStorage.getItem("clientId")!)
  }
Back(): void{
this.location.back()
}
Save(){
  
 var clientId = JSON.parse(localStorage.getItem("clientId")!);
  this.service.AddAddress(clientId, this.Address.value).subscribe(res => {
    this.successtoast()
    this.router.navigate(['./addresses'])

  })
}
successtoast(){
  this.toast.success('Address added')
}
}
