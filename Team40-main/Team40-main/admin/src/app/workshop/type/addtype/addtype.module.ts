import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddtypePageRoutingModule } from './addtype-routing.module';

import { AddtypePage } from './addtype.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddtypePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddtypePage]
})
export class AddtypePageModule {}
