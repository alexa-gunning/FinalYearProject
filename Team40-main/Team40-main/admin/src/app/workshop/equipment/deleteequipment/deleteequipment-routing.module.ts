import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DeleteequipmentPage } from './deleteequipment.page';

const routes: Routes = [
  {
    path: '',
    component: DeleteequipmentPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DeleteequipmentPageRoutingModule {}
