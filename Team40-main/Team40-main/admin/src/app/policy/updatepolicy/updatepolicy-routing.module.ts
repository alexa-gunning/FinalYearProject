import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatepolicyPage } from './updatepolicy.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatepolicyPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatepolicyPageRoutingModule {}
