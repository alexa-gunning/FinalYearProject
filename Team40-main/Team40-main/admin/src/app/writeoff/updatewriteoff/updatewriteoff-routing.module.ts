import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UpdatewriteoffPage } from './updatewriteoff.page';

const routes: Routes = [
  {
    path: '',
    component: UpdatewriteoffPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UpdatewriteoffPageRoutingModule {}
