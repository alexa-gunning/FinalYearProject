import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProductperformancePageRoutingModule } from './productperformance-routing.module';

import { ProductperformancePage } from './productperformance.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProductperformancePageRoutingModule
  ],
  declarations: [ProductperformancePage]
})
export class ProductperformancePageModule {}
