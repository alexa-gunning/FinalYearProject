import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Ng2SearchPipe, Ng2SearchPipeModule } from 'ng2-search-filter';
import { IonicModule } from '@ionic/angular';

import { ModifyslotsPageRoutingModule } from './modifyslots-routing.module';

import { ModifyslotsPage } from './modifyslots.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ModifyslotsPageRoutingModule,
    Ng2SearchPipeModule
  ],
  declarations: [ModifyslotsPage]
})
export class ModifyslotsPageModule {}
