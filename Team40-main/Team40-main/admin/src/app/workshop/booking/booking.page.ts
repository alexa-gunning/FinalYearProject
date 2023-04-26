import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/services/booking.service';
import { Bookings } from 'src/models/bookings';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { Router } from '@angular/router';


@Component({
  selector: 'app-booking',
  templateUrl: './booking.page.html',
  styleUrls: ['./booking.page.scss'],
})
export class BookingPage implements OnInit {
 item: Bookings[];
  constructor(private service: BookingService, private router: Router) { }

  searchTerm:string;
  ngOnInit(): void {
  this.item = [];
  this.service.GetBookingsWithClients().subscribe(res=>{
    var item = res as any[]
    for(var i = 0; i < item.length; i++){
      var Item = new Bookings();
     //  var image = Item.productImage;;
 
       // if(Item.productImage !== null)
       // {
       //   let objectURL = 'data:image/png;base64,' + Item.productImage;
       //   image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
       // }
       // else {
       //   image = "assets/images/noImage2.jpg"
       // }
 
      Item.clientId = res[i].clientId;
      Item.name = res[i].name;
      Item.surname = res[i].surname;
      Item.workshopId = res[i].workshopId;
      Item.workshopDate= res[i].workshopDate;
      Item.typeDescription= res[i].typeDescription;
     //  Item.productPriceId =res[i].productPriceId;
      Item.bookingId =res[i].bookingId;
      Item.hostName=res[i].hostName;
      Item.venueName =res[i].venueName;
      Item.attendanceStatusName =res[i].attendanceStatusName;


     //  Item.productImage = image;
      this.item.push(Item);
    console.log(item) 
  }
  })
}

HomeBtn()
  {
    this.router.navigate(['./tabs/wshome']);
  }

}
