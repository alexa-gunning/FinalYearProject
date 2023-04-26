import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddpolicyPageRoutingModule } from './addpolicy-routing.module';

import { AddpolicyPage } from './addpolicy.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddpolicyPageRoutingModule
  ],
  declarations: [AddpolicyPage]
})
export class AddpolicyPageModule {}
