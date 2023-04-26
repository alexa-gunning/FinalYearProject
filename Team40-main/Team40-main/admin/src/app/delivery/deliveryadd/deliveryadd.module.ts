import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { DeliveryaddPageRoutingModule } from './deliveryadd-routing.module';

import { DeliveryaddPage } from './deliveryadd.page';

@NgModule({
  imports: [ 
    CommonModule,
    FormsModule,
    IonicModule,
    DeliveryaddPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [DeliveryaddPage]
})
export class DeliveryaddPageModule {}
