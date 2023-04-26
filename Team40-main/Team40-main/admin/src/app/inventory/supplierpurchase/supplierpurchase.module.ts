import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SupplierpurchasePageRoutingModule } from './supplierpurchase-routing.module';

import { SupplierpurchasePage } from './supplierpurchase.page';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SupplierpurchasePageRoutingModule,
    Ng2SearchPipeModule
  ],
  declarations: [SupplierpurchasePage]
})
export class SupplierpurchasePageModule {}
