import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DeleteequipmentPageRoutingModule } from './deleteequipment-routing.module';

import { DeleteequipmentPage } from './deleteequipment.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DeleteequipmentPageRoutingModule
  ],
  declarations: [DeleteequipmentPage]
})
export class DeleteequipmentPageModule {}
