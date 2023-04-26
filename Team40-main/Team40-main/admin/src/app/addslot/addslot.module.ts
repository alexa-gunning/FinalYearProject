import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddslotPageRoutingModule } from './addslot-routing.module';

import { AddslotPage } from './addslot.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddslotPageRoutingModule
  ],
  declarations: [AddslotPage]
})
export class AddslotPageModule {}
