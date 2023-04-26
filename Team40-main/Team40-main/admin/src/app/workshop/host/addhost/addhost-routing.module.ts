import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddhostPage } from './addhost.page';

const routes: Routes = [
  {
    path: '',
    component: AddhostPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddhostPageRoutingModule {}
