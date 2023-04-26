import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { WorkshopperformancePageRoutingModule } from './workshopperformance-routing.module';

import { WorkshopperformancePage } from './workshopperformance.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    WorkshopperformancePageRoutingModule
  ],
  declarations: [WorkshopperformancePage]
})
export class WorkshopperformancePageModule {}
