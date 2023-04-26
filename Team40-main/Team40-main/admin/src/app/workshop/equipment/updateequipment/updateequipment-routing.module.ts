import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdateequipmentPage } from './updateequipment.page';

const routes: Routes = [
  {
    path: '',
    component: UpdateequipmentPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdateequipmentPageRoutingModule {}
