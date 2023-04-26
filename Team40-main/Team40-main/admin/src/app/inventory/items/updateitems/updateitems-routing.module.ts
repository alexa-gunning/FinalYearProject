import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdateitemsPage } from './updateitems.page';

const routes: Routes = [
  {
    path: '',
    component: UpdateitemsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdateitemsPageRoutingModule {}
