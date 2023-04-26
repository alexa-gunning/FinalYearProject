import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SupplierpurchasereportPageRoutingModule } from './supplierpurchasereport-routing.module';

import { SupplierpurchasereportPage } from './supplierpurchasereport.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SupplierpurchasereportPageRoutingModule
  ],
  declarations: [SupplierpurchasereportPage]
})
export class SupplierpurchasereportPageModule {}
