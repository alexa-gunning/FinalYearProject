import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InventoryreportPage } from './inventoryreport.page';

const routes: Routes = [
  {
    path: '',
    component: InventoryreportPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InventoryreportPageRoutingModule {}
