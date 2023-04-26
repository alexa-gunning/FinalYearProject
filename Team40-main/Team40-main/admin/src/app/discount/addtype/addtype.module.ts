import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddtypePageRoutingModule } from './addtype-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddtypePage } from './addtype.page';

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
