import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { UpdateequipmentPageRoutingModule } from './updateequipment-routing.module';
import { UpdateequipmentPage } from './updateequipment.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdateequipmentPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdateequipmentPage]
})
export class UpdateequipmentPageModule {}
