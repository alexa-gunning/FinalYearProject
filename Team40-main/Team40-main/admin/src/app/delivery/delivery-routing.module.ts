import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DeliveryPage } from './delivery.page';

const routes: Routes = [
  {
    path: '',
    component: DeliveryPage
  },
  {
    path: 'deliveryupdate',
    loadChildren: () => import('./deliveryupdate/deliveryupdate.module').then( m => m.DeliveryupdatePageModule)
  },
  {
    path: 'deliveryadd',
    loadChildren: () => import('./deliveryadd/deliveryadd.module').then( m => m.DeliveryaddPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DeliveryPageRoutingModule {}
