import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { UpdatewriteoffPageRoutingModule } from './updatewriteoff-routing.module';

import { UpdatewriteoffPage } from './updatewriteoff.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UpdatewriteoffPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [UpdatewriteoffPage]
})
export class UpdatewriteoffPageModule {}
