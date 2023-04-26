import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UcolorPage } from './ucolor.page';

const routes: Routes = [
  {
    path: '',
    component: UcolorPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UcolorPageRoutingModule {}
