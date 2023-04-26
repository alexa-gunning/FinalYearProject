import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';
import { PreloadAllModules } from '@angular/router';

const routes: Routes = [
  {
    path: 'tabs',
    component: TabsPage,
    children: [
      {
        path: 'create',
        loadChildren: () => import('../CRUDtemplate/create/create.module').then( m => m.CreatePageModule)
      },
      {
        path: 'read',
        loadChildren: () => import('../CRUDtemplate/read/read.module').then( m => m.ReadPageModule)
      },
      {
        path: 'update',
        loadChildren: () => import('../CRUDtemplate/update/update.module').then( m => m.UpdatePageModule)
      },
      {
        path: 'login',
        loadChildren: () => import('../login/login.module').then( m => m.LoginPageModule)
      },
      {
        path: 'client',
        loadChildren: () => import('../client/view/client.module').then( m => m.ClientPageModule)
      },
      {
        path: 'newsletter',
        loadChildren: () => import('../newsletter/newsletter.module').then( m => m.NewsletterPageModule)
      },
      {
        path: 'discount',
        loadChildren: () => import('../discount/viewdiscounts/discount.module').then( m => m.DiscountPageModule)
      },
      {
        path: 'slots',
        loadChildren: () => import('../workshop/slots/slots.module').then( m => m.SlotsPageModule)
      },
      {
        path: 'feedback',
        loadChildren: () => import('../workshop/feedback/feedback.module').then( m => m.FeedbackPageModule)
      },

      {
        path: 'venue',
        loadChildren: () => import('../workshop/venue/viewvenues/venue.module').then( m => m.VenuePageModule)
      },
      {
        path: 'type',
        loadChildren: () => import('../workshop/type/type.module').then( m => m.TypePageModule)
      },
      {
        path: 'wshome',
        loadChildren: () => import('../workshop/home/home.module').then( m => m.HomePageModule)
      },
      {
        path: 'equipment',
        loadChildren: () => import('../workshop/equipment/viewequipment/equipment.module').then( m => m.EquipmentPageModule)
      },
      {
        path: 'attendance',
        loadChildren: () => import('../workshop/attendance/attendance.module').then( m => m.AttendancePageModule)
      },
      {
        path: 'host',
        loadChildren: () => import('../workshop/host/viewhost/host.module').then( m => m.HostPageModule)
      },
      {
        path: 'booking',
        loadChildren: () => import('../workshop/booking/booking.module').then( m => m.BookingPageModule)
      },
      {
        path: 'products',
        loadChildren: () => import('../products/products.module').then( m => m.ProductsPageModule)
      },
      {
        path: 'delivery',
        loadChildren: () => import('../delivery/delivery.module').then( m => m.DeliveryPageModule)
      },
      {
        path: 'orders',
        loadChildren: () => import('../orders/orders.module').then( m => m.OrdersPageModule)
      },
      {
        path: 'items',
        loadChildren: () => import('../inventory/items/viewitems/items.module').then( m => m.ItemsPageModule)
      },
      {
        path: 'writeoff',
        loadChildren: () => import('../inventory/writeoff/writeoff.module').then( m => m.WriteoffPageModule)
      },
      {
        path: 'stocktake',
        loadChildren: () => import('../inventory/stocktake/stocktake.module').then( m => m.StocktakePageModule)
      },
      {
        path: 'policy',
        loadChildren: () => import('../policy/policy.module').then( m => m.PolicyPageModule)
      },
      {
        path: 'supplier',
        loadChildren: () => import('../supplier/supplier.module').then( m => m.SupplierPageModule)
      },
      {
        path: 'reports',
        loadChildren: () => import('../reports/reports.module').then( m => m.ReportsPageModule)
      },
      {
        path: 'inventoryhome',
        loadChildren: () => import('../inventory/inventoryhome/inventoryhome.module').then( m => m.InventoryhomePageModule)
      },
        {
          path: 'supplierpurchasereport',
        loadChildren: () => import('../reports/supplierpurchasereport/supplierpurchasereport.module').then( m => m.SupplierpurchasereportPageModule)
      },
      {
        path: 'helppage',
        loadChildren: () => import('../helppage/helppage.module').then( m => m.HelppagePageModule)
      }
    
    ]
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class TabsPageRoutingModule {}
