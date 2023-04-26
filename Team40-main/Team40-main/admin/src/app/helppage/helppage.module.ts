import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HelppagePageRoutingModule } from './helppage-routing.module';

import { HelppagePage } from './helppage.page';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HelppagePageRoutingModule,
    Ng2SearchPipeModule
  ],
  declarations: [HelppagePage]
})
export class HelppagePageModule {}
