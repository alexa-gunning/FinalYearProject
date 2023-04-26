import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PerformstocktakePage } from './performstocktake.page';

const routes: Routes = [
  {
    path: '',
    component: PerformstocktakePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PerformstocktakePageRoutingModule {}
