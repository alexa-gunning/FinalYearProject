import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { TakeattendancePageRoutingModule } from './takeattendance-routing.module';

import { TakeattendancePage } from './takeattendance.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TakeattendancePageRoutingModule,ReactiveFormsModule
  ],
  declarations: [TakeattendancePage]
})
export class TakeattendancePageModule {}
