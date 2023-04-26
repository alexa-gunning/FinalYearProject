import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Products } from 'src/app/models/product';
import { ClientService } from 'src/app/services/client.service';
import { DeliverycompanyService } from 'src/app/services/deliverycompany.service';
import { OrderService } from 'src/app/services/order.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-rediret',
  templateUrl: './rediret.component.html',
  styleUrls: ['./rediret.component.css']
})
export class RediretComponent implements OnInit {
  basketList: any;
  updateqty: any;
  updateprod: any;
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
  // orderProductId = Math.floor((Math.random() * 1000) + 1000);
orderProductId: any;
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
    private pservice: ProductService) {
    // this.onRemoteSiteUserData = new Map<string,string>();
    // this.onRemoteSiteUserData.set('merchant_id','10027471');
    // this.onRemoteSiteUserData.set('merchant_key','w5t5y5f1076qe')
   }

  ngOnInit(): void {
    this.basketList = JSON.parse(localStorage.getItem('basket')!);
    // async addproductorder(){
      // setTimeout(() => {
        this.orderProductId=  JSON.parse(localStorage.getItem('orderProductId')!);
      for(var i = 0; i < this.basketList.length; i++){
        this.productId=  JSON.parse(localStorage.getItem('productIds')!);
        
        console.log(parseInt(this.productId[i]));
        var productId = this.productId[i];
        this.quantity1=  JSON.parse(localStorage.getItem('quantities')!);
        console.log(parseInt(this.quantity1[i]));
        var quantity1 = this.quantity1[i];
        
        this.oservice.AddOrderProduct(productId, quantity1, this.orderProductId).subscribe(res=>{
          console.log("order product added")
        })
        }
      //    setTimeout
      // }, 5000);
      // window.location.reload

    // }
  }

}
