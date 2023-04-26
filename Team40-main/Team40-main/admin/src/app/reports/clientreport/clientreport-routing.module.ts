import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClientreportPage } from './clientreport.page';

const routes: Routes = [
  {
    path: '',
    component: ClientreportPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientreportPageRoutingModule {}
