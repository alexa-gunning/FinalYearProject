import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { AppRoutingComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CartComponent } from './cart/cart.component';
import { HelppageComponent } from './helppage/helppage.component';
import { ForgotpasswordComponent } from './login/forgotpassword/forgotpassword.component';
import { LoginComponent } from './login/login.component';
import { OtpComponent } from './login/otp/otp.component';
import { RegisterComponent } from './login/register/register.component';
import { PolicyComponent } from './policy/policy.component';
import { ProductsComponent } from './products/products.component';
import { ProfileComponent } from './profile/profile.component';
import { WorkshopComponent } from './workshop/workshop.component';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MakebookingComponent } from './workshop/makebooking/makebooking.component';
import { ViewbookingsComponent } from './viewbookings/viewbookings.component';
import { AddressesComponent } from './cart/addresses/addresses.component';
import { AddaddressComponent } from './cart/addresses/addaddress/addaddress.component';
import { ViewordersComponent } from './vieworders/vieworders.component';
import { SuccessComponent } from './cart/redirect pages/success/success.component';
import { CancelledComponent } from './cart/redirect pages/cancelled/cancelled.component';
import { RediretComponent } from './cart/redirect pages/success/rediret/rediret.component';
import { UpdateaddressComponent } from './cart/updateaddress/updateaddress.component';
@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    LoginComponent,
    PolicyComponent,
    ProfileComponent,
    CartComponent,
    WorkshopComponent,
    RegisterComponent,
    ForgotpasswordComponent,
    OtpComponent,
    HelppageComponent,
    MakebookingComponent,
    ViewbookingsComponent,
    AddressesComponent,
    AddaddressComponent,
    ViewordersComponent,
    SuccessComponent,
    CancelledComponent,
    RediretComponent,
    UpdateaddressComponent,
  
  ],
  imports: [
   BrowserModule,
   AppRoutingComponent,
   HttpClientModule,
//  ToastrModule,
 ReactiveFormsModule,
 ToastrModule.forRoot({ progressBar: true}),
 BrowserAnimationsModule

  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
