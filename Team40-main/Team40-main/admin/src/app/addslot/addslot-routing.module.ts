import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddslotPage } from './addslot.page';

const routes: Routes = [
  {
    path: '',
    component: AddslotPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddslotPageRoutingModule {}
