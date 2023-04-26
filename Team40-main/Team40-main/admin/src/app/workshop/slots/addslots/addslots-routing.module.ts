import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddslotsPage } from './addslots.page';

const routes: Routes = [
  {
    path: '',
    component: AddslotsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddslotsPageRoutingModule {}
