import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { StocktakePageRoutingModule } from './stocktake-routing.module';

import { StocktakePage } from './stocktake.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    StocktakePageRoutingModule,
    Ng2SearchPipeModule
  ],
  declarations: [StocktakePage]
})
export class StocktakePageModule {}
