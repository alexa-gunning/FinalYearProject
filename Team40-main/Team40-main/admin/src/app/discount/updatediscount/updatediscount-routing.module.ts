import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatediscountPage } from './updatediscount.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatediscountPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatediscountPageRoutingModule {}
