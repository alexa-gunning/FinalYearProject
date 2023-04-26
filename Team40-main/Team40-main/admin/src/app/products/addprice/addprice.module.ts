import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddpricePageRoutingModule } from './addprice-routing.module';

import { AddpricePage } from './addprice.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddpricePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddpricePage]
})
export class AddpricePageModule {}
