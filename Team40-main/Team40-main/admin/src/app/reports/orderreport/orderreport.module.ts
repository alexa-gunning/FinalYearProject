import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { registerables } from 'chart.js';
import  Chart  from 'chart.js/auto';

import { IonicModule } from '@ionic/angular';

import { OrderreportPageRoutingModule } from './orderreport-routing.module';

import { OrderreportPage } from './orderreport.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OrderreportPageRoutingModule

  ],
  declarations: [OrderreportPage]
})
export class OrderreportPageModule {}
