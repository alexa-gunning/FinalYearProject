import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreatediscountPage } from './creatediscount.page';

const routes: Routes = [
  {
    path: '',
    component: CreatediscountPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreatediscountPageRoutingModule {}
