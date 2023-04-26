import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgCalendarModule } from 'ionic2-calendar';
import { IonicModule } from '@ionic/angular';

import { SlotsPageRoutingModule } from './slots-routing.module';

import { SlotsPage } from './slots.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SlotsPageRoutingModule, NgCalendarModule
  ],
  declarations: [SlotsPage]
})
export class SlotsPageModule {}
