import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
  },
  {
    path: 'create',
    loadChildren: () => import('./CRUDtemplate/create/create.module').then( m => m.CreatePageModule)
  },
  {
    path: 'read',
    loadChildren: () => import('./CRUDtemplate/read/read.module').then( m => m.ReadPageModule)
  },
  {
    path: 'update',
    loadChildren: () => import('./CRUDtemplate/update/update.module').then( m => m.UpdatePageModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'client',
    loadChildren: () => import('./client/view/client.module').then( m => m.ClientPageModule)
  },
  {
    path: 'newsletter',
    loadChildren: () => import('./newsletter/newsletter.module').then( m => m.NewsletterPageModule)
  },
  {
    path: 'discount',
    loadChildren: () => import('./discount/viewdiscounts/discount.module').then( m => m.DiscountPageModule)
  },
  {
    path: 'slots',
    loadChildren: () => import('./workshop/slots/slots.module').then( m => m.SlotsPageModule)
  },
  {
    path: 'addslots',
    loadChildren: () => import('./workshop/slots/addslots/addslots.module').then( m => m.AddslotsPageModule)
  },
  {
    path: 'modifyslots',
    loadChildren: () => import('./workshop/slots/modifyslots/modifyslots.module').then( m => m.ModifyslotsPageModule)
  },
  {
    path: 'feedback',
    loadChildren: () => import('./workshop/feedback/feedback.module').then( m => m.FeedbackPageModule)
  },

  {
    path: 'venue',
    loadChildren: () => import('./workshop/venue/viewvenues/venue.module').then( m => m.VenuePageModule)
  },
  {
    path: 'type',
    loadChildren: () => import('./workshop/type/type.module').then( m => m.TypePageModule)
  },
  {
    path: 'equipment',
    loadChildren: () => import('./workshop/equipment/viewequipment/equipment.module').then( m => m.EquipmentPageModule)
  },
  {
    path: 'createequipment',
    loadChildren: () => import('./workshop/equipment/createequipment/createequipment.module').then( m => m.CreateequipmentPageModule)
  },
  {
    path: 'updateequipment',
    loadChildren: () => import('./workshop/equipment/updateequipment/updateequipment.module').then( m => m.UpdateequipmentPageModule)
  },
  {
    path: 'deleteequipment',
    loadChildren: () => import('./workshop/equipment/deleteequipment/deleteequipment.module').then( m => m.DeleteequipmentPageModule)
  },
  {
    path: 'attendance',
    loadChildren: () => import('./workshop/attendance/attendance.module').then( m => m.AttendancePageModule)
  },
  {
    path: 'host',
    loadChildren: () => import('./workshop/host/viewhost/host.module').then( m => m.HostPageModule)
  },
  {
    path: 'booking',
    loadChildren: () => import('./workshop/booking/booking.module').then( m => m.BookingPageModule)
  },
  {
    path: 'products',
    loadChildren: () => import('./products/products.module').then( m => m.ProductsPageModule)
  },
  {
    path: 'delivery',
    loadChildren: () => import('./delivery/delivery.module').then( m => m.DeliveryPageModule)
  },
  {
    path: 'deliveryadd',
    loadChildren: () => import('./delivery/deliveryadd/deliveryadd.module').then( m => m.DeliveryaddPageModule)
  },
  {
    path: 'deliveryupdate',
    loadChildren: () => import('./delivery/deliveryupdate/deliveryupdate.module').then( m => m.DeliveryupdatePageModule)
  },
  {
    path: 'orders',
    loadChildren: () => import('./orders/orders.module').then( m => m.OrdersPageModule)
  },
  {
    path: 'items',
    loadChildren: () => import('./inventory/items/viewitems/items.module').then( m => m.ItemsPageModule)
  },
  {
    path: 'writeoff',
    loadChildren: () => import('./inventory/writeoff/writeoff.module').then( m => m.WriteoffPageModule)
  },
  {
    path: 'writeoffcreate',
    loadChildren: () => import('./inventory/writeoff/createwriteoff/createwriteoff.module').then( m => m.CreatewriteoffPageModule)
  },
  {
    path: 'writeoffupdate',
    loadChildren: () => import('./inventory/writeoff/updatewriteoff/updatewriteoff.module').then( m => m.UpdatewriteoffPageModule)
  },
  {
    path: 'writeoffdelete',
    loadChildren: () => import('./inventory/writeoff/deletewriteoff/deletewriteoff.module').then( m => m.DeletewriteoffPageModule)
  },
  {
    path: 'stocktake',
    loadChildren: () => import('./inventory/stocktake/stocktake.module').then( m => m.StocktakePageModule)
  },
  {
    path: 'policy',
    loadChildren: () => import('./policy/policy.module').then( m => m.PolicyPageModule)
  },
  {
    path: 'supplier',
    loadChildren: () => import('./supplier/supplier.module').then( m => m.SupplierPageModule)
  },
  {
    path: 'reports',
    loadChildren: () => import('./reports/reports.module').then( m => m.ReportsPageModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./workshop/home/home.module').then( m => m.HomePageModule)
  },
  {
    path: 'updateclient',
    loadChildren: () => import('./client/update/update.module').then( m => m.UpdatePageModule)
  },
  {
    path: 'createclient',
    loadChildren: () => import('./client/create/create.module').then( m => m.CreatePageModule)
  },
  {
    path: 'updatediscount',
    loadChildren: () => import('./discount/updatediscount/updatediscount.module').then( m => m.UpdatediscountPageModule)
  },
  {
    path: 'creatediscount',
    loadChildren: () => import('./discount/creatediscount/creatediscount.module').then( m => m.CreatediscountPageModule)
  },
  {
    path: 'addvenue',
    loadChildren: () => import('./workshop/venue/addvenue/addvenue.module').then( m => m.AddvenuePageModule)
  },
  {
    path: 'updatevenue',
    loadChildren: () => import('./workshop/venue/updatevenue/updatevenue.module').then( m => m.UpdatevenuePageModule)
  },
  {
    path: 'updatehost',
    loadChildren: () => import('./workshop/host/updatehost/updatehost.module').then( m => m.UpdatehostPageModule)
  },
  {
    path: 'addhost',
    loadChildren: () => import('./workshop/host/addhost/addhost.module').then( m => m.AddhostPageModule)
  },
  {
    path: 'inventoryhome',
    loadChildren: () => import('./inventory/inventoryhome/inventoryhome.module').then( m => m.InventoryhomePageModule)
  },
  {
    path: 'additems',
    loadChildren: () => import('./inventory/items/additems/additems.module').then( m => m.AdditemsPageModule)
  },
  {
    path: 'updateitems',
    loadChildren: () => import('./inventory/items/updateitems/updateitems.module').then( m => m.UpdateitemsPageModule)
  },
  {
    path: 'supplierpurchase',
    loadChildren: () => import('./inventory/supplierpurchase/supplierpurchase.module').then( m => m.SupplierpurchasePageModule)
  },
  {
    path: 'addsupplierpurchase',
    loadChildren: () => import('./supplier/addsupplierpurchase/addsupplierpurchase.module').then( m => m.AddsupplierpurchasePageModule)
  },
  {
    path: 'inventoryreport',
    loadChildren: () => import('./reports/inventoryreport/inventoryreport.module').then( m => m.InventoryreportPageModule)
  },
  {
    path: 'clientreport',
    loadChildren: () => import('./reports/clientreport/clientreport.module').then( m => m.ClientreportPageModule)
  },
  {
    path: 'orderreport',
    loadChildren: () => import('./reports/orderreport/orderreport.module').then( m => m.OrderreportPageModule)
  },
  {
    path: 'addtype',
    loadChildren: () => import('./workshop/type/addtype/addtype.module').then( m => m.AddtypePageModule)
  },
  {
    path: 'updatetype',
    loadChildren: () => import('./workshop/type/updatetype/updatetype.module').then( m => m.UpdatetypePageModule)
  },
  {
    path: 'item',
    loadChildren: () => import('./writeoff/writeoffitem/item/item.module').then( m => m.ItemPageModule)
  },
  {
    path: 'newsletteradd',
    loadChildren: () => import('./newsletter/newsletteradd/newsletteradd.module').then( m => m.NewsletteraddPageModule)
  },
  {
    path: 'addpolicy',
    loadChildren: () => import('./policy/addpolicy/addpolicy.module').then( m => m.AddpolicyPageModule)
  },
  {
    path: 'updatepolicy',
    loadChildren: () => import('./policy/updatepolicy/updatepolicy.module').then( m => m.UpdatepolicyPageModule)
  },
  {
    path: 'registerpage',
    loadChildren: () => import('./login/register/register.module').then( m => m.RegisterPageModule)
  },
  {
    path: 'supplierpurchasereport',
    loadChildren: () => import('./reports/supplierpurchasereport/supplierpurchasereport.module').then( m => m.SupplierpurchasereportPageModule)
  },
  {
    path: 'addsupplier',
    loadChildren: () => import('./supplier/addsupplier/addsupplier.module').then( m => m.AddsupplierPageModule)
  },
  {
    path: 'updatesupplier',
    loadChildren: () => import('./supplier/updatesupplier/updatesupplier.module').then( m => m.UpdatesupplierPageModule)
  },
  {
    path: 'otp',
    loadChildren: () => import('./login/otp/otp.module').then( m => m.OtpPageModule)
  },
  {
    path: 'helppage',
    loadChildren: () => import('./helppage/helppage.module').then( m => m.HelppagePageModule)
  },
  {
    path: 'updatebooking',
    loadChildren: () => import('./workshop/booking/updatebooking/updatebooking.module').then( m => m.UpdatebookingPageModule)
  },
  {
    path: 'createbooking',
    loadChildren: () => import('./workshop/booking/createbooking/createbooking.module').then( m => m.CreatebookingPageModule)
  },
  {
    path: 'adddiscounttype',
    loadChildren: () => import('./discount/addtype/addtype.module').then( m => m.AddtypePageModule)
  }
  ,
  {
    path: 'addproduct',
    loadChildren: () => import('./products/addproduct/addproduct.module').then( m => m.AddproductPageModule)
  }

  ,
  {
    path: 'addprice',
    loadChildren: () => import('./products/addprice/addprice.module').then( m => m.AddpricePageModule)
  }
  ,
  {
    path: 'addcolor',
    loadChildren: () => import('./products/addcolor/addcolor.module').then( m => m.AddcolorPageModule)
  }
  ,
  {
    path: 'addprodtype',
    loadChildren: () => import('./products/addtype/addtype.module').then( m => m.AddtypePageModule)
  }  ,
  {
    path: 'addpurchase',
    loadChildren: () => import('./inventory/supplierpurchase/addpurchase/addpurchase.module').then( m => m.AddpurchasePageModule)
  }  
  ,
  {
    path: 'updatepurchase',
    loadChildren: () => import('./inventory/supplierpurchase/updatepurchase/updatepurchase.module').then( m => m.UpdatepurchasePageModule)
  } , {
    path: 'updateworkshopslot',
    loadChildren: () => import('./workshop/slots/modifyslots/updateslot/updateslot.module').then( m => m.UpdateslotPageModule)
  } 
  ,
  {
    path: 'mgtype',
    loadChildren: () => import('./products/mgtype/mgtype.module').then( m => m.MgtypePageModule)
  } ,
   {
    path: 'mgcolor',
    loadChildren: () => import('./products/mgcolor/mgcolor.module').then( m => m.MgcolorPageModule)
  },
  {
   path: 'ucolor',
   loadChildren: () => import('./products/mgcolor/ucolor/ucolor.module').then( m => m.UcolorPageModule)
 },
 {
  path: 'takeattendance',
  loadChildren: () => import('./workshop/attendance/takeattendance/takeattendance.module').then( m => m.TakeattendancePageModule)
},
 {
  path: 'utype',
  loadChildren: () => import('./products/mgtype/utype/utype.module').then( m => m.UtypePageModule)
},
{
  path: 'forgotpassword',
  loadChildren: () => import('./login/forgotpassword/forgotpassword.module').then( m => m.ForgotpasswordPageModule)
},{
  path: 'manageproducts',
  loadChildren: () => import('./products/manageproducts/manageproducts.module').then( m => m.ManageproductsPageModule)
},{
  path: 'updateproduct',
  loadChildren: () => import('./products/updateproduct/updateproduct.module').then( m => m.UpdateproductPageModule)
},
  {
    path: 'writeoffinventoryitem',
    loadChildren: () => import('./writeoff/writeoffinventoryitem/writeoffinventoryitem.module').then( m => m.WriteoffinventoryitemPageModule)
  },
  {
    path: 'performstocktake',
    loadChildren: () => import('./inventory/stocktake/performstocktake/performstocktake.module').then( m => m.PerformstocktakePageModule)
  },
  {
    path: 'UpdateStocktake',
    loadChildren: () => import('./inventory/stocktake/updatestocktake/updatestocktake.module').then( m => m.UpdatestocktakePageModule)
  },  {
    path: 'updatewriteoff',
    loadChildren: () => import('./writeoff/updatewriteoff/updatewriteoff.module').then( m => m.UpdatewriteoffPageModule)
  },


];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
