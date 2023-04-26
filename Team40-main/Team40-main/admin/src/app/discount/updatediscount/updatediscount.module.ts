import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdatediscountPageRoutingModule } from './updatediscount-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { UpdatediscountPage } from './updatediscount.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatediscountPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatediscountPage]
})
export class UpdatediscountPageModule {}
