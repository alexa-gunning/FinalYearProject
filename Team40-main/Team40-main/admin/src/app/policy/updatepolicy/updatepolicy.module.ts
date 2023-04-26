import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdatepolicyPageRoutingModule } from './updatepolicy-routing.module';

import { UpdatepolicyPage } from './updatepolicy.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatepolicyPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatepolicyPage]
})
export class UpdatepolicyPageModule {}
