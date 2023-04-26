import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreatebookingPage } from './createbooking.page';

const routes: Routes = [
  {
    path: '',
    component: CreatebookingPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreatebookingPageRoutingModule {}
