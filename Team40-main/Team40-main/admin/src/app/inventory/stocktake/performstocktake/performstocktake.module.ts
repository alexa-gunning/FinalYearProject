import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { PerformstocktakePageRoutingModule } from './performstocktake-routing.module';

import { PerformstocktakePage } from './performstocktake.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PerformstocktakePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [PerformstocktakePage]
})
export class PerformstocktakePageModule {}
