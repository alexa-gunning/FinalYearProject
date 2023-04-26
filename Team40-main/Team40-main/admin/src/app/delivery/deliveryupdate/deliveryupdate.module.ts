import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';
import { ReactiveFormsModule } from '@angular/forms';
import { DeliveryupdatePageRoutingModule } from './deliveryupdate-routing.module';

import { DeliveryupdatePage } from './deliveryupdate.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DeliveryupdatePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [DeliveryupdatePage]
})
export class DeliveryupdatePageModule {}
