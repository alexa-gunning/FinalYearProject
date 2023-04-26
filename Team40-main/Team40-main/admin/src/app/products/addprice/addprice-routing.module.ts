import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddpricePage } from './addprice.page';

const routes: Routes = [
  {
    path: '',
    component: AddpricePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddpricePageRoutingModule {}
