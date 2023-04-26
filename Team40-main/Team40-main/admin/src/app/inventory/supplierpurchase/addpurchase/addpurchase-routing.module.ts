import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddpurchasePage } from './addpurchase.page';

const routes: Routes = [
  {
    path: '',
    component: AddpurchasePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddpurchasePageRoutingModule {}
