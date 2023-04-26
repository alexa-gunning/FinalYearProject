import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UtypePageRoutingModule } from './utype-routing.module';

import { UtypePage } from './utype.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UtypePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UtypePage]
})
export class UtypePageModule {}
