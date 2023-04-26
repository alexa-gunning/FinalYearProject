import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SupplierpurchasePage } from './supplierpurchase.page';

const routes: Routes = [
  {
    path: '',
    component: SupplierpurchasePage
  },
  {
    path: 'addpurchase',
    loadChildren: () => import('./addpurchase/addpurchase.module').then( m => m.AddpurchasePageModule)
  },
  {
    path: 'updatepurchase',
    loadChildren: () => import('./updatepurchase/updatepurchase.module').then( m => m.UpdatepurchasePageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SupplierpurchasePageRoutingModule {}
