import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PolicyPage } from './policy.page';

const routes: Routes = [
  {
    path: '',
    component: PolicyPage
  },  {
    path: 'addpolicy',
    loadChildren: () => import('./addpolicy/addpolicy.module').then( m => m.AddpolicyPageModule)
  },
  {
    path: 'updatepolicy',
    loadChildren: () => import('./updatepolicy/updatepolicy.module').then( m => m.UpdatepolicyPageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PolicyPageRoutingModule {}
