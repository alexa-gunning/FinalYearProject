import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { UpdatestocktakePageRoutingModule } from './updatestocktake-routing.module';

import { UpdatestocktakePage } from './updatestocktake.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatestocktakePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatestocktakePage]
})
export class UpdatestocktakePageModule {}
