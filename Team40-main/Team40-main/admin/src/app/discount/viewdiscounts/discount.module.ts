import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DiscountPageRoutingModule } from './discount-routing.module';

import { DiscountPage } from './discount.page';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DiscountPageRoutingModule,
    Ng2SearchPipeModule
  ],
  declarations: [DiscountPage]
})
export class DiscountPageModule {}
