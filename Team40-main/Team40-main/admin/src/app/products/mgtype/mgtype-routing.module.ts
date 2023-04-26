import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MgtypePage } from './mgtype.page';

const routes: Routes = [
  {
    path: '',
    component: MgtypePage
  },
  {
    path: 'utype',
    loadChildren: () => import('./utype/utype.module').then( m => m.UtypePageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MgtypePageRoutingModule {}
