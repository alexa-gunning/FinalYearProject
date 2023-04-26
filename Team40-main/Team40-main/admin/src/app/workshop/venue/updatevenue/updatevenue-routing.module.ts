import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatevenuePage } from './updatevenue.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatevenuePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatevenuePageRoutingModule {}
