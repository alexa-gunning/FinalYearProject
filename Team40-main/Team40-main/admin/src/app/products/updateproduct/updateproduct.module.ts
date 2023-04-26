import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdateproductPageRoutingModule } from './updateproduct-routing.module';

import { UpdateproductPage } from './updateproduct.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdateproductPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdateproductPage]
})
export class UpdateproductPageModule {}
