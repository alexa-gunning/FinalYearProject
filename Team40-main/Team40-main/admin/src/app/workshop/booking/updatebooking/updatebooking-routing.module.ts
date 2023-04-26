import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatebookingPage } from './updatebooking.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatebookingPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatebookingPageRoutingModule {}
