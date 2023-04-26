import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NgCalendarModule } from 'ionic2-calendar';
import { SlotsPage } from './slots.page';

const routes: Routes = [
  {
    path: '',
    component: SlotsPage
  },
  {
    path: 'addslots',
    loadChildren: () => import('./addslots/addslots.module').then( m => m.AddslotsPageModule)
  },  {
    path: 'modifyslots',
    loadChildren: () => import('./modifyslots/modifyslots.module').then( m => m.ModifyslotsPageModule)
  }

 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SlotsPageRoutingModule {}
