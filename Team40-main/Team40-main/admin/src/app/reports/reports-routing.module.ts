import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReportsPage } from './reports.page';

const routes: Routes = [
  {
    path: '',
    component: ReportsPage
  },
  {
    path: 'inventoryreport',
    loadChildren: () => import('./inventoryreport/inventoryreport.module').then( m => m.InventoryreportPageModule)
  },
  {
    path: 'clientreport',
    loadChildren: () => import('./clientreport/clientreport.module').then( m => m.ClientreportPageModule)
  },
  {
    path: 'orderreport',
    loadChildren: () => import('./orderreport/orderreport.module').then( m => m.OrderreportPageModule)
  },
  {
    path: 'supplierpurchasereport',
    loadChildren: () => import('./supplierpurchasereport/supplierpurchasereport.module').then( m => m.SupplierpurchasereportPageModule)
  },
  {
    path: 'productperformance',
    loadChildren: () => import('./productperformance/productperformance.module').then( m => m.ProductperformancePageModule)
  },
  {
    path: 'workshopperformance',
    loadChildren: () => import('./workshopperformance/workshopperformance.module').then( m => m.WorkshopperformancePageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ReportsPageRoutingModule {}
