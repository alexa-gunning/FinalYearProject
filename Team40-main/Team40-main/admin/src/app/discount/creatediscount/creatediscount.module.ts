import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreatediscountPageRoutingModule } from './creatediscount-routing.module';

import { CreatediscountPage } from './creatediscount.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreatediscountPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [CreatediscountPage]
})
export class CreatediscountPageModule {}
