import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { InventoryhomePageRoutingModule } from './inventoryhome-routing.module';

import { InventoryhomePage } from './inventoryhome.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    InventoryhomePageRoutingModule
  ],
  declarations: [InventoryhomePage]
})
export class InventoryhomePageModule {}
