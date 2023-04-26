import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ClientreportPageRoutingModule } from './clientreport-routing.module';

import { ClientreportPage } from './clientreport.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ClientreportPageRoutingModule
  ],
  declarations: [ClientreportPage]
})
export class ClientreportPageModule {}
