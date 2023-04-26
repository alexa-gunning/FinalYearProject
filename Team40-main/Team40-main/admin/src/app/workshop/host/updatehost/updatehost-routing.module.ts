import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatehostPage } from './updatehost.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatehostPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatehostPageRoutingModule {}
