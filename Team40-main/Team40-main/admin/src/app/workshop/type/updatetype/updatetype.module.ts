import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdatetypePageRoutingModule } from './updatetype-routing.module';

import { UpdatetypePage } from './updatetype.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatetypePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatetypePage]
})
export class UpdatetypePageModule {}
