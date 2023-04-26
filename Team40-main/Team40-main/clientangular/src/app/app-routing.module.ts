import { NgModule } from '@angular/core';
import{Routes, RouterModule} from '@angular/router';
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
import { MakebookingComponent } from './workshop/makebooking/makebooking.component';
import { ViewbookingsComponent } from './viewbookings/viewbookings.component';
import { AddressesComponent } from './cart/addresses/addresses.component';
import { AddaddressComponent } from './cart/addresses/addaddress/addaddress.component';
import { ViewordersComponent } from './vieworders/vieworders.component';
import { SuccessComponent } from './cart/redirect pages/success/success.component';
import { CancelledComponent } from './cart/redirect pages/cancelled/cancelled.component';
import { RediretComponent } from './cart/redirect pages/success/rediret/rediret.component';
import { UpdateaddressComponent } from './cart/updateaddress/updateaddress.component';

const routes: Routes = [
  {path: '', redirectTo: 'products', pathMatch: 'full'},
  {path : 'products', component : ProductsComponent},
  {path : 'workshop', component : WorkshopComponent},
  {path : 'login', component : LoginComponent},
  {path : 'cart', component : CartComponent},
  {path : 'profile', component : ProfileComponent},
  {path : 'policy', component : PolicyComponent},
  {path : 'otp', component : OtpComponent},
  {path : 'register', component : RegisterComponent},
  {path : 'forgotpassword', component : ForgotpasswordComponent},
  {path : 'help', component : HelppageComponent},
  {path : 'makebooking', component : MakebookingComponent},
  {path : 'viewbookings', component : ViewbookingsComponent},
  {path : 'addresses', component : AddressesComponent},
  {path : 'addaddress', component : AddaddressComponent},
  {path : 'vieworders', component : ViewordersComponent},
  {path : 'success', component : SuccessComponent},
  {path : 'cancelled', component : CancelledComponent},
  {path : 'redirect', component : RediretComponent},
  {path : 'updateaddress', component : UpdateaddressComponent},
];
exports: [
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
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingComponent { }
