import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { WriteoffinventoryitemPageRoutingModule } from './writeoffinventoryitem-routing.module';

import { WriteoffinventoryitemPage } from './writeoffinventoryitem.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    WriteoffinventoryitemPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [WriteoffinventoryitemPage]
})
export class WriteoffinventoryitemPageModule {}
