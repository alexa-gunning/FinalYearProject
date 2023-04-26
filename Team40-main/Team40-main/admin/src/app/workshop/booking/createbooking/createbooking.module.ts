import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreatebookingPageRoutingModule } from './createbooking-routing.module';

import { CreatebookingPage } from './createbooking.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreatebookingPageRoutingModule
  ],
  declarations: [CreatebookingPage]
})
export class CreatebookingPageModule {}
