import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdatepurchasePageRoutingModule } from './updatepurchase-routing.module';

import { UpdatepurchasePage } from './updatepurchase.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatepurchasePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatepurchasePage]
})
export class UpdatepurchasePageModule {}
