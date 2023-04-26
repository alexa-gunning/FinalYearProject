import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateequipmentPage } from './createequipment.page';

const routes: Routes = [
  {
    path: '',
    component: CreateequipmentPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreateequipmentPageRoutingModule {}
