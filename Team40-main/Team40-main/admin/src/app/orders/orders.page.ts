import { Component, OnInit, PipeTransform } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { pipe } from 'rxjs';
import { ClienOrders } from 'src/models/clientorders';
import { DeliveryCompany } from 'src/models/deliverycompany';
import { Orders } from 'src/models/orders';
import { Products } from 'src/models/product';
import { DeliverycompanyService } from 'src/services/deliverycompany.service';
import { OrdersService } from 'src/services/orders.service';
import { ProductService } from 'src/services/product.service';
import { ClientordersService } from '../services/clientorders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.page.html',
  styleUrls: ['./orders.page.scss'],
})

export class OrdersPage implements OnInit{

  searchTerm: string;
  clientorders: ClienOrders[];
  orders: Orders[]
  DelComp: any;
  res: any;
  Prods: any;
  res1: any;
  quantity: any;
  products: Products[]
  productIds:any;
  prodnames: any;
  productIds1:any;
  productIds3: Array<any> = null;
  constructor(private router: Router, private service: ClientordersService, 
    private toast: ToastController, private oservice: OrdersService, private dservice: DeliverycompanyService, 
    private pservice: ProductService) { }


  ngOnInit() {

  }

  ionViewWillEnter(): void{

    
    this.orders=[]
    this.productIds = []
    this.oservice.GetOrders2().subscribe(res =>{
      var cOrders = res as any[]
      for(var i=0; i<= cOrders.length;i++)
      {
        var Item = new Orders();
        // Item.clientId =res[i].clientId;
        Item.date=res[i].date;
        Item.orderStatusId =res[i].orderStatusId
        Item.productName =res[i].productName
        Item.addressId =res[i].addressId
        Item.quantity =res[i].quantity
        Item.discountId =res[i].discountId
        Item.orderProductId =res[i].orderProductId
        Item.deliveryCompanyId =res[i].deliverCompanyId
        Item.deliveryCompanyName =res[i].deliveryCompanyName
        Item.deliveryCompanyBaseRate =res[i].deliveryCompanyBaseRate
        Item.name = res[i].name;
        Item.surname= res[i].surname;
        Item.description = res[i].description;
        Item.city = res[i].city;
        Item.province = res[i].province;
        Item.areaCode = res[i].areaCode;
        Item.streetName = res[i].streetName;
        Item.country = res[i].country;
        Item.streetNumber = res[i].streetNumber;
        Item.productNames = res[i].productNames;
        this.orders.push(Item)
        this.productIds.push(Item.productIds);
        // console.log(Item.productIds)
        // console.log(Item)
      }
    });
    this.productIds3 = new Array<any>();
    console.log(this.productIds)

    for(var i = 0; i < 4; i++){
      // var stringified = JSON.stringify(this.productIds);
      // console.log(stringified)
    }
}

}
