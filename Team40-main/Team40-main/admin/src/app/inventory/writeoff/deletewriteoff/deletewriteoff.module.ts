import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DeletewriteoffPageRoutingModule } from './deletewriteoff-routing.module';

import { DeletewriteoffPage } from './deletewriteoff.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DeletewriteoffPageRoutingModule
  ],
  declarations: [DeletewriteoffPage]
})
export class DeletewriteoffPageModule {}
