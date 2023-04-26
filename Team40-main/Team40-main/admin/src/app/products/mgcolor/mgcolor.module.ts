import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MgcolorPageRoutingModule } from './mgcolor-routing.module';

import { MgcolorPage } from './mgcolor.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MgcolorPageRoutingModule
  ],
  declarations: [MgcolorPage]
})
export class MgcolorPageModule {}
