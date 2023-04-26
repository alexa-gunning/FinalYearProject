import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Products } from 'src/app/models/product';
import { ClientService } from 'src/app/services/client.service';
import { DeliverycompanyService } from 'src/app/services/deliverycompany.service';
import { OrderService } from 'src/app/services/order.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-success',
  templateUrl: './success.component.html',
  styleUrls: ['./success.component.css']
})
export class SuccessComponent implements OnInit {
  basketList: any;
  updateqty: any;
  updateprod: any;
  clientId: any;
  basket1: any;
  Quantity: any;
  price: any;
  quantity1: any;
  productId: any;
  orderProductId = Math.floor((Math.random() * 1000) + 1000);
  address: any;
  item!: Products[];  
  delcomp: any;
  delcompbase: any;
  delcomp1: any;
  address1: any;

  constructor(private toast: ToastrService, private dservice: DeliverycompanyService, 
    private csevice: ClientService, private router: Router, private oservice: OrderService,
    private pservice: ProductService) {
   }

  ngOnInit(): void {
    // this.oservice.GetNaxOrderId().subscribe(()=>{})
    this.basketList = JSON.parse(localStorage.getItem('basket')!);
    // console.log(this.basketList)
    this.dservice.GetAll().subscribe(res =>{
this.delcomp = res; 
// console.log(this.delcomp)
    })
    this.clientId = JSON.parse(localStorage.getItem('clientId')!);
    this.csevice.GetAddressByClientID(this.clientId).subscribe(res =>{
      this.address = res; 
          })
          localStorage.setItem('orderProductId', JSON.stringify(this.orderProductId))
          // for(var x = 0; x < this.basketList.length; x++){
          //   this.addorder()
          // this.addproductorder()
          this.createorder()
        // }
         
  }
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
    this.pservice.UpdateProductQty(productId1, quantity11).subscribe(res=>{})
  }
    localStorage.removeItem('basket')
      }
     addorder()
    
      {
        for(var x = 0; x < this.basketList.length; x++){
          var add = {
            "addressId":  localStorage.getItem('addressId')!,
            "deliveryCompanyId":  localStorage.getItem('deliveryCompanyId')!,
            "clientId": this.clientId,
            "orderProductId": this.orderProductId,
            "orderStatusId": 1,
            "discountId": 1
          }
        this.oservice.AddOrder(add).subscribe(res=>{
          
          console.log("order added")
       
        }) }
      }

    addproductorder(){
        
        for(var i = 0; i < this.basketList.length; i++){
          this.productId=  JSON.parse(localStorage.getItem('productIds')!);
          
          console.log(parseInt(this.productId[i]));
          var productId = this.productId[i];
          this.quantity1=  JSON.parse(localStorage.getItem('quantities')!);
          console.log(parseInt(this.quantity1[i]));
          var quantity1 = this.quantity1[i]; 
        this.orderprodservice(productId, quantity1)
      }
        }
        orderprodservice(productId: any, quantity1: any){
          this.oservice.AddOrderProduct(productId, quantity1, this.orderProductId).subscribe(res=>{
            console.log("order product added")
          })
        }
}
