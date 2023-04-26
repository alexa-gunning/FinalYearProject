import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreateequipmentPageRoutingModule } from './createequipment-routing.module';

import { CreateequipmentPage } from './createequipment.page';

import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreateequipmentPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [CreateequipmentPage]
})
export class CreateequipmentPageModule {}
