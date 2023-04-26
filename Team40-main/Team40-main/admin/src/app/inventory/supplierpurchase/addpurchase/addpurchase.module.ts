import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddpurchasePageRoutingModule } from './addpurchase-routing.module';

import { AddpurchasePage } from './addpurchase.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddpurchasePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddpurchasePage]
})
export class AddpurchasePageModule {}
