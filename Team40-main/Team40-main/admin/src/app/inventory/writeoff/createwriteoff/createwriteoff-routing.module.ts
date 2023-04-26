import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreatewriteoffPage } from './createwriteoff.page';

const routes: Routes = [
  {
    path: '',
    component: CreatewriteoffPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreatewriteoffPageRoutingModule {}
