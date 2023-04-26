import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MgtypePageRoutingModule } from './mgtype-routing.module';

import { MgtypePage } from './mgtype.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MgtypePageRoutingModule
  ],
  declarations: [MgtypePage]
})
export class MgtypePageModule {}
