import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddsupplierpurchasePage } from './addsupplierpurchase.page';

const routes: Routes = [
  {
    path: '',
    component: AddsupplierpurchasePage
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddsupplierpurchasePageRoutingModule {}
