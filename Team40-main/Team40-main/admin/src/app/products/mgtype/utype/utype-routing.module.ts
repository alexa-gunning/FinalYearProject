import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UtypePage } from './utype.page';

const routes: Routes = [
  {
    path: '',
    component: UtypePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UtypePageRoutingModule {}
