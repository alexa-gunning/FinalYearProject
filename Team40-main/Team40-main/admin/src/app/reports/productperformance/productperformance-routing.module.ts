import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductperformancePage } from './productperformance.page';

const routes: Routes = [
  {
    path: '',
    component: ProductperformancePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductperformancePageRoutingModule {}
