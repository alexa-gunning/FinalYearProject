import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { UpdateslotPageRoutingModule } from './updateslot-routing.module';

import { UpdateslotPage } from './updateslot.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdateslotPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdateslotPage]
})
export class UpdateslotPageModule {}
