import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdatevenuePageRoutingModule } from './updatevenue-routing.module';

import { UpdatevenuePage } from './updatevenue.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatevenuePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatevenuePage]
})
export class UpdatevenuePageModule {}
