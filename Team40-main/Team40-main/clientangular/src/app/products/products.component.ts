import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { textChangeRangeIsUnchanged } from 'typescript';
import { Client } from '../models/client';
import { Products } from '../models/product';
import { ClientloginService } from '../services/clientlogin.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css',]
})
export class ProductsComponent implements OnInit {

  // searchTerm: string | undefined;
  Product!: Products[];
  quantities: Array<any> = [];
  productForm!: FormGroup;
  productList!: Products[];
  basketList: Array<Products> = [];
  productIds: Array<any> = [];
  // basketList!: any;
  // array!: [] 
  // productName!: string;
  // quantity!: number;
  // price!: number;
  email: any;
  // res: any;
  item!: any;
  @ViewChild('quantity', {static: true}) quantityElement: ElementRef | undefined;
  constructor(private router: Router, private service: ProductService, private toast: ToastrService, private sanitizer: DomSanitizer, private cservice: ClientloginService) { }

   ngOnInit(): void {
     
    this.service.GetProducts().subscribe(res =>{
   
      this.Product = res;

    });
    this.email= JSON.parse(localStorage.getItem("Token")!);
      console.log(this.email.userName);
      // this.res = '';
      this.cservice.GetClientID(this.email.userName).subscribe((res: any)  =>{
       this.item = res;
      console.log(this.item.clientId);
     
      }); 
      console.log(JSON.parse(localStorage.getItem("clientId")!));
 }

 
   async presentToast() {
    this.toast.error("Click to view products")
   }
  addProduct(product: Products)
  {
    const basketProduct = {
      ...product,
      Quantity: parseInt((<HTMLInputElement>document.getElementById("quantity("+ product.productId + ")")).value),
   
    };
    if(basketProduct.Quantity <= product.quantityOnHand){
    this.basketList = JSON.parse(localStorage.getItem('basket')!);
    if(this.basketList == null){
      this.basketList = [];
      // this.basketList = basketProduct;
      // this.basketList.forEach((basketProduct: any) => {
        this.basketList.push(basketProduct);
      // });
          // this.basketList.push(basketProduct);
         
      localStorage.setItem('basket',JSON.stringify(this.basketList));
      
      this.productIds = [];
      this.productIds.push(basketProduct.productId);
      localStorage.setItem('productIds', JSON.stringify(this.productIds));
      console.log(this.productIds)
      this.quantities = [];
      this.quantities.push(basketProduct.Quantity);
      localStorage.setItem('quantities', JSON.stringify(this.quantities));
      console.log(this.quantities)
    }

    else{
    //   // this.basketList = basketProduct;
    //   // this.basketList.push(basketProduct);
    //   // this.basketList.forEach((basketProduct: any) => {
        this.basketList.push(basketProduct);
    //   // });
      localStorage.setItem('basket',JSON.stringify(this.basketList));
      

   
      this.productIds.push(basketProduct.productId);
      localStorage.setItem('productIds', JSON.stringify(this.productIds));
      console.log(this.productIds)
      
      this.quantities.push(basketProduct.Quantity);
      localStorage.setItem('quantities', JSON.stringify(this.quantities));
      console.log(this.quantities)
    }
    this.successtoast()
  }
    else{
      this.presentQtyError()
        }
    console.log(this.basketList)
  } 
//   else{
// this.presentQtyError()
//   }
    // this.router.navigate(['cart']);


  // console.log(this.basketList)

  
// }
  async presentQtyError() {
    this.toast.error("That quantity isn't available!");
   }
   successtoast(){
    this.toast.success('Product added to cart.')
  }
}