import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddvenuePageRoutingModule } from './addvenue-routing.module';

import { AddvenuePage } from './addvenue.page';

//import this for add to work
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddvenuePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddvenuePage]
})
export class AddvenuePageModule {}
