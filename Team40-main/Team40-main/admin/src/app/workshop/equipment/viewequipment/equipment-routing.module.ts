import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EquipmentPage } from './equipment.page';

const routes: Routes = [
  {
    path: '',
    component: EquipmentPage
  },
  {
    path: 'createequipment',
    loadChildren: () => import('../createequipment/createequipment.module').then( m => m.CreateequipmentPageModule)
  },
  {
    path: 'updateequipment',
    loadChildren: () => import('../updateequipment/updateequipment.module').then( m => m.UpdateequipmentPageModule)
  },
  {
    path: 'deleteequipment',
    loadChildren: () => import('../deleteequipment/deleteequipment.module').then( m => m.DeleteequipmentPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EquipmentPageRoutingModule {}
