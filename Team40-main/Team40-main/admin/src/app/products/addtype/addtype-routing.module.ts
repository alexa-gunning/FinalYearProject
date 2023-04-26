import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddtypePage } from './addtype.page';

const routes: Routes = [
  {
    path: '',
    component: AddtypePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddtypePageRoutingModule {}
