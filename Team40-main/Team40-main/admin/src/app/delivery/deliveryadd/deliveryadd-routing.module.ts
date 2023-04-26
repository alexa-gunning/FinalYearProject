import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DeliveryaddPage } from './deliveryadd.page';

const routes: Routes = [
  {
    path: '',
    component: DeliveryaddPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DeliveryaddPageRoutingModule {}
