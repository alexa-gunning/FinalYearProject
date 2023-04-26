import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TypePage } from './type.page';

const routes: Routes = [
  {
    path: '',
    component: TypePage
  },  {
    path: 'addtype',
    loadChildren: () => import('./addtype/addtype.module').then( m => m.AddtypePageModule)
  },
  {
    path: 'updatetype',
    loadChildren: () => import('./updatetype/updatetype.module').then( m => m.UpdatetypePageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TypePageRoutingModule {}
