import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddhostPageRoutingModule } from './addhost-routing.module';

import { AddhostPage } from './addhost.page';

import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddhostPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [AddhostPage]
})
export class AddhostPageModule {}
