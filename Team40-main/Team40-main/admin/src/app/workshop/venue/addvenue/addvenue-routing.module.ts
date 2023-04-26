import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddvenuePage } from './addvenue.page';

const routes: Routes = [
  {
    path: '',
    component: AddvenuePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddvenuePageRoutingModule {}
