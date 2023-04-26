import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UcolorPageRoutingModule } from './ucolor-routing.module';

import { UcolorPage } from './ucolor.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UcolorPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UcolorPage]
})
export class UcolorPageModule {}
