import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddcolorPageRoutingModule } from './addcolor-routing.module';

import { AddcolorPage } from './addcolor.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddcolorPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddcolorPage]
})
export class AddcolorPageModule {}
