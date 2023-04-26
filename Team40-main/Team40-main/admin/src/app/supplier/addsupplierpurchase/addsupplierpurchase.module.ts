import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddsupplierpurchasePageRoutingModule } from './addsupplierpurchase-routing.module';

import { AddsupplierpurchasePage } from './addsupplierpurchase.page';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddsupplierpurchasePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddsupplierpurchasePage]
})
export class AddsupplierpurchasePageModule {}
