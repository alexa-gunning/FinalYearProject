import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { InventoryreportPageRoutingModule } from './inventoryreport-routing.module';

import { InventoryreportPage } from './inventoryreport.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    InventoryreportPageRoutingModule
  ],
  declarations: [InventoryreportPage]
})
export class InventoryreportPageModule {}
