import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-vieworders',
  templateUrl: './vieworders.component.html',
  styleUrls: ['./vieworders.component.css']
})
export class ViewordersComponent implements OnInit {

  clientId!: number;
  productIds!: any;
  orders!: any;
  constructor(private service: OrderService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.clientId = JSON.parse(localStorage.getItem("clientId")!);
    this.service.GetOrderByClientID2(this.clientId).subscribe(res =>{
     this.orders = res;
    console.log(this.orders)
    });
  }

}
