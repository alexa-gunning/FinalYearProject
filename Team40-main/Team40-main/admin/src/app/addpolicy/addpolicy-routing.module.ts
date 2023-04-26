import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddpolicyPage } from './addpolicy.page';

const routes: Routes = [
  {
    path: '',
    component: AddpolicyPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddpolicyPageRoutingModule {}
