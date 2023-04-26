import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WorkshopperformancePage } from './workshopperformance.page';

const routes: Routes = [
  {
    path: '',
    component: WorkshopperformancePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WorkshopperformancePageRoutingModule {}
