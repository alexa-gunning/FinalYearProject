import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdatehostPageRoutingModule } from './updatehost-routing.module';

import { UpdatehostPage } from './updatehost.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatehostPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatehostPage]
})
export class UpdatehostPageModule {}
