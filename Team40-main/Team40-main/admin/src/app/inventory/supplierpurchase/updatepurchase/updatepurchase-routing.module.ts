import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatepurchasePage } from './updatepurchase.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatepurchasePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatepurchasePageRoutingModule {}
