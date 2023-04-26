import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SupplierPage } from './supplier.page';

const routes: Routes = [
  {
    path: '',
    component: SupplierPage
  },
  {
    path: 'addsupplierpurchase',
    loadChildren: () => import('./addsupplierpurchase/addsupplierpurchase.module').then( m => m.AddsupplierpurchasePageModule)
  },  {
    path: 'updatesupplier',
    loadChildren: () => import('./updatesupplier/updatesupplier.module').then( m => m.UpdatesupplierPageModule)
  },
  {
    path: 'addsupplier',
    loadChildren: () => import('./addsupplier/addsupplier.module').then( m => m.AddsupplierPageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SupplierPageRoutingModule {}
