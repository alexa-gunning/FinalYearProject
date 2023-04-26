import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ResolveEnd, Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs';
import { Client } from '../models/client';
import { Orders } from '../models/orders';
import { Products } from '../models/product';
import { ClientService } from '../services/client.service';
import { ClientloginService } from '../services/clientlogin.service';
import { DeliverycompanyService } from '../services/deliverycompany.service';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  basketList: any;
  productIds: any;
  quantities: any;
  clientId: any;
  basket1: any;
  Quantity: any;
  price: any;
  quantity1: any;
  productId: any;
  Products!: Products[]
   basket: Products = {
    productName: '',
    colorName: '',
    colorDescription: '',
    date: '',
    price: 0,
    typeDescription: '',
    productTypeName: '',
    productId: 0,
    quantity: 0,
    quantityOnHand: 0
  }
  orderProductId = Math.floor((Math.random() * 1000) + 1000);
  res2: any | undefined;
  item2!: Client[];
 email: any;
  address: any;
  item!: Products[];  
  delcomp: any;
  delcompbase: any;
  delcomp1: any;
  address1: any;
  get Total2(): number {
    let value = 0;
    this.basketList?.forEach((e: any) => {
      value += (e.price * e.Quantity);
    });
    return value;
  }
  get BaseRate(): number {
    let value = 0;
    this.delcomp1.forEach((e: any) => {
      value = e.deliveryCompanyBaseRate;
    });
    return value;
  }
  get TotalWithDelivery(): number {
    let value = 0;
    this.delcomp1?.forEach((e: any) => {
      value = e.deliveryCompanyBaseRate;
    });
    let val2 = 0;
    this.basketList?.forEach((e: any) => {
      val2 += (e.price * e.Quantity);
    });
    return value + val2;
  }
  constructor(private toast: ToastrService, private dservice: DeliverycompanyService, 
    private csevice: ClientService, private router: Router, private oservice: OrderService,
    private lservice: ClientloginService) {
    this.onRemoteSiteUserData = new Map<string,string>();
    this.onRemoteSiteUserData.set('merchant_id','10027471');
    this.onRemoteSiteUserData.set('merchant_key','w5t5y5f1076qe')
   }

  ngOnInit() {
    // var maxId = this.oservice.GetNaxOrderId().subscribe((res)=>{
    //   console.log(maxId)
    // })
    // console.log(maxId)
    this.basketList = JSON.parse(localStorage.getItem('basket')!);
    console.log(this.basketList)
    this.dservice.GetAll().subscribe(res =>{
this.delcomp = res; 
console.log(this.delcomp)
    })
    this.clientId = JSON.parse(localStorage.getItem('clientId')!);
    this.csevice.GetAddressByClientID(this.clientId).subscribe(res =>{
      this.address = res; 
      console.log(this.address)
          })
    this.email= JSON.parse(localStorage.getItem("Token")!);
    console.log(this.email.userName);
    this.res2 = '';
    this.lservice.GetClientID(this.email.userName).subscribe((res3: any)=>{
     this.item2= res3.clientId;
    console.log(this.item2);
  })
}
  onRemoteSiteUserData: Map<string,string>;
 
  deleteItem(item: any){
    this.removeAlert();
    this.basketList.splice(this.basketList.indexOf(item),1);
    this.productIds = JSON.parse(localStorage.getItem('productIds')!);
    this.quantities = JSON.parse(localStorage.getItem('quantities')!);
    this.productIds.splice(this.productIds.indexOf(item),1);
    this.quantities.splice(this.quantities.indexOf(item),1);
    localStorage.setItem('basket',JSON.stringify(this.basketList));
    localStorage.setItem('productIds',JSON.stringify(this.productIds));
    localStorage.setItem('quantities',JSON.stringify(this.quantities));
  }

  async removeAlert(){

    this.toast.error("Product removed from basket.")
  }


  Deliver(){

  }
  Address(){
this.router.navigate(['./addresses'])
  }
  Place(){

  }
  Addcomp(event : any){
    let selectedIndex:number = event.target["selectedIndex"];
    var deliveryCompanyId = event.target.options[selectedIndex].getAttribute("deliveryCompanyId")
    localStorage.setItem('deliveryCompanyId',deliveryCompanyId);
    console.log(event.target.options[selectedIndex].getAttribute("deliveryCompanyId"))
this.dservice.GetDeliveryCompanyByID(deliveryCompanyId).subscribe(res=> {
  this.delcomp1 = res;
  console.log(this.delcomp1);


})
}
Addaddress(event : any){
  let selectedIndex:number = event.target["selectedIndex"];
  var addressId = event.target.options[selectedIndex].getAttribute("addressId")
  localStorage.setItem('addressId',addressId);
  console.log(event.target.options[selectedIndex].getAttribute("addressId"))
this.csevice.GetAddressByID(addressId).subscribe((res: any)=> {
this.address1 = res;
console.log(this.address1);
})
}
// var orderProductId = Math.floor((Math.random() * 1000) + 1000);
// console.log(orderProductId)
createorder(){
  // var orderProductId = Math.floor((Math.random() * 1000) + 1000);
  console.log(this.orderProductId)
  for(var i = 0; i < this.basketList.length; i++){
    this.productId=  JSON.parse(localStorage.getItem('productIds')!);
      console.log(parseInt(this.productId[i]));
      var productId1 = this.productId[i];
      this.quantity1=  JSON.parse(localStorage.getItem('quantities')!);
      console.log(parseInt(this.quantity1[i]));
      var quantity11 = this.quantity1[i];
    var add = {
      "addressId":  localStorage.getItem('addressId')!,
      "deliveryCompanyId":  localStorage.getItem('deliveryCompanyId')!,
      "clientId": this.clientId,
      "orderProductId": this.orderProductId,
      "orderStatusId": 1,
      "discountId": 1,
      "productId": productId1,
      "quantity": quantity11,
    }
  this.oservice.AddOrder(add).subscribe(res=>{
    
    console.log("order added")
  }) 
}
  // var quantity11;
  // var productId1;
  // for(var i = 0; i < this.basketList.length; i++){
    
  //   this.productId=  JSON.parse(localStorage.getItem('productIds')!);
  //   console.log(parseInt(this.productId[i]));
  //   var productId1 = this.productId[i];
  //   this.quantity1=  JSON.parse(localStorage.getItem('quantities')!);
  //   console.log(parseInt(this.quantity1[i]));
  //   var quantity11 = this.quantity1[i];
  //   this.oservice.AddOrderProduct(productId1, quantity11, this.orderProductId).subscribe(()=>{})
  //   }
    // this.oservice.AddOrderProduct(productId1, quantity11, this.orderProductId).subscribe(res=>{
    //   console.log("order product added")
    // }) 

  }

}
