import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NewsletteraddPage } from './newsletteradd.page';

const routes: Routes = [
  {
    path: '',
    component: NewsletteraddPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NewsletteraddPageRoutingModule {}
