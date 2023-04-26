import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WriteoffPage } from './writeoff.page';

const routes: Routes = [
  {
    path: '',
    component: WriteoffPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WriteoffPageRoutingModule {}
