import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HostPageRoutingModule } from './host-routing.module';

import { HostPage } from './host.page';

import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HostPageRoutingModule,
    Ng2SearchPipeModule
  ],
  declarations: [HostPage]
})
export class HostPageModule {}
