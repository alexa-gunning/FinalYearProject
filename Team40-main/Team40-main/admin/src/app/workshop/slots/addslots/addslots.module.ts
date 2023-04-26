import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { AddslotsPageRoutingModule } from './addslots-routing.module';

import { AddslotsPage } from './addslots.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddslotsPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddslotsPage]
})
export class AddslotsPageModule {}
