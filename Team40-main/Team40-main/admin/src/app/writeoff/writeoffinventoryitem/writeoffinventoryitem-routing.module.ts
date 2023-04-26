import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WriteoffinventoryitemPage } from './writeoffinventoryitem.page';

const routes: Routes = [
  {
    path: '',
    component: WriteoffinventoryitemPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WriteoffinventoryitemPageRoutingModule {}
