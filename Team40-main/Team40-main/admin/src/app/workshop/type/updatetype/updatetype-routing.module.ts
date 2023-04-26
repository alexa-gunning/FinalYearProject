import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatetypePage } from './updatetype.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatetypePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatetypePageRoutingModule {}
