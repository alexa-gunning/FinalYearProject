import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MgcolorPage } from './mgcolor.page';

const routes: Routes = [
  {
    path: '',
    component: MgcolorPage
  },
  {
    path: 'ucolor',
    loadChildren: () => import('./ucolor/ucolor.module').then( m => m.UcolorPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MgcolorPageRoutingModule {}
