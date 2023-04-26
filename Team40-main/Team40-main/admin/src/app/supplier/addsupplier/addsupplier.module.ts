import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { AddsupplierPageRoutingModule } from './addsupplier-routing.module';

import { AddsupplierPage } from './addsupplier.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddsupplierPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddsupplierPage]
})
export class AddsupplierPageModule {}
