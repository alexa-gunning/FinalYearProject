import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreatewriteoffPageRoutingModule } from './createwriteoff-routing.module';

import { CreatewriteoffPage } from './createwriteoff.page';

import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreatewriteoffPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [CreatewriteoffPage]
})
export class CreatewriteoffPageModule {}
