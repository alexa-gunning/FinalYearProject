import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductsPage } from './products.page';

const routes: Routes = [
  {
    path: '',
    component: ProductsPage
  },
  {
    path: 'addproduct',
    loadChildren: () => import('./addproduct/addproduct.module').then( m => m.AddproductPageModule)
  },
  {
    path: 'addprice',
    loadChildren: () => import('./addprice/addprice.module').then( m => m.AddpricePageModule)
  },
  {
    path: 'addcolor',
    loadChildren: () => import('./addcolor/addcolor.module').then( m => m.AddcolorPageModule)
  },
  {
    path: 'addtype',
    loadChildren: () => import('./addtype/addtype.module').then( m => m.AddtypePageModule)
  },
  {
    path: 'mgcolor',
    loadChildren: () => import('./mgcolor/mgcolor.module').then( m => m.MgcolorPageModule)
  },
  {
    path: 'mgtype',
    loadChildren: () => import('./mgtype/mgtype.module').then( m => m.MgtypePageModule)
  },
  {
    path: 'manageproducts',
    loadChildren: () => import('./manageproducts/manageproducts.module').then( m => m.ManageproductsPageModule)
  },
  {
    path: 'updateproduct',
    loadChildren: () => import('./updateproduct/updateproduct.module').then( m => m.UpdateproductPageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductsPageRoutingModule {}
