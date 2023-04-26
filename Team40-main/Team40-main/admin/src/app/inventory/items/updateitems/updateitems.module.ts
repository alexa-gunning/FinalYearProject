import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UpdateitemsPageRoutingModule } from './updateitems-routing.module';

import { UpdateitemsPage } from './updateitems.page';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdateitemsPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdateitemsPage]
})
export class UpdateitemsPageModule {}
