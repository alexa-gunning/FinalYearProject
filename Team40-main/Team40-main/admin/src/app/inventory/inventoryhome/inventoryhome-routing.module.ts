import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InventoryhomePage } from './inventoryhome.page';

const routes: Routes = [
  {
    path: '',
    component: InventoryhomePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InventoryhomePageRoutingModule {}
