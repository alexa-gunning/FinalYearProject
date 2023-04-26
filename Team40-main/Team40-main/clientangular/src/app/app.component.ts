import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Client } from './models/client';
import { ClientService } from './services/client.service';
import { ClientloginService } from './services/clientlogin.service';
// import { CartComponent } from './cart/cart.component';
// import { HelppageComponent } from './helppage/helppage.component';
// import { ForgotpasswordComponent } from './login/forgotpassword/forgotpassword.component';
// import { LoginComponent } from './login/login.component';
// import { OtpComponent } from './login/otp/otp.component';
// import { RegisterComponent } from './login/register/register.component';
// import { PolicyComponent } from './policy/policy.component';
// import { ProductsComponent } from './products/products.component';
// import { ProfileComponent } from './profile/profile.component';
// import { WorkshopComponent } from './workshop/workshop.component';
// import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'clientangular';
  res: string | undefined;
  item!: Client[];
  email: any;
  constructor(private router: Router, private cservice: ClientloginService) { }
  Logout(){
    localStorage.removeItem('Token')
    localStorage.removeItem('clientId')
    localStorage.removeItem('basket')
    localStorage.removeItem('quantities')
    localStorage.removeItem('productIds')
    localStorage.removeItem('addressId')
    localStorage.removeItem('userDetails')
    localStorage.removeItem('deliveryCompanyId')

    this.router.navigate(['./login']);
  }
  ngOnInit(): void {
    this.email= JSON.parse(localStorage.getItem("Token")!);
    console.log(this.email.userName);
    this.res = '';
    this.cservice.GetClientID(this.email.userName).subscribe((res: any)  =>{
     this.item = res;
    //  this.item.clientId = res.clientId
    console.log(res); 
  })}
  Viewbookings(clientId: any){
    localStorage.setItem("clientId" , JSON.stringify(clientId));
    // console.log(JSON.parse(localStorage.getItem("clientId")!));
  }
}
