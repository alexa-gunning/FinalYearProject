import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BookingPage } from './booking.page';

const routes: Routes = [
  {
    path: '',
    component: BookingPage
  },  {
    path: 'createbooking',
    loadChildren: () => import('./createbooking/createbooking.module').then( m => m.CreatebookingPageModule)
  },
  {
    path: 'updatebooking',
    loadChildren: () => import('./updatebooking/updatebooking.module').then( m => m.UpdatebookingPageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BookingPageRoutingModule {}
