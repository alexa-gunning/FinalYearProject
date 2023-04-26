import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StocktakePage } from './stocktake.page';

const routes: Routes = [
  {
    path: '',
    component: StocktakePage
  },  {
    path: 'performstocktake',
    loadChildren: () => import('./performstocktake/performstocktake.module').then( m => m.PerformstocktakePageModule)
  },
  {
    path: 'updatestocktake',
    loadChildren: () => import('./updatestocktake/updatestocktake.module').then( m => m.UpdatestocktakePageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StocktakePageRoutingModule {}
