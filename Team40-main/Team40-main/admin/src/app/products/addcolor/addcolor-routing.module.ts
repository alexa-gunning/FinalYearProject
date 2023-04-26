import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddcolorPage } from './addcolor.page';

const routes: Routes = [
  {
    path: '',
    component: AddcolorPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddcolorPageRoutingModule {}
