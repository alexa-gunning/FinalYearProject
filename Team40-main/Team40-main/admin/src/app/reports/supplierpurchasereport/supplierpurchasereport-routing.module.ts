import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SupplierpurchasereportPage } from './supplierpurchasereport.page';

const routes: Routes = [
  {
    path: '',
    component: SupplierpurchasereportPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SupplierpurchasereportPageRoutingModule {}
