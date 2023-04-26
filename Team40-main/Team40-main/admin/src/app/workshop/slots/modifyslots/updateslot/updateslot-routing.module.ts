import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdateslotPage } from './updateslot.page';

const routes: Routes = [
  {
    path: '',
    component: UpdateslotPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdateslotPageRoutingModule {}
