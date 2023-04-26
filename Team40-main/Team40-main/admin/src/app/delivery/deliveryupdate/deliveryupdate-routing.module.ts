import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DeliveryupdatePage } from './deliveryupdate.page';

const routes: Routes = [
  {
    path: '',
    component: DeliveryupdatePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DeliveryupdatePageRoutingModule {}
