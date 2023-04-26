import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// import { DocumentViewer } from '@awesome-cordova-plugins/document-viewer/ngx';
import { IonicModule } from '@ionic/angular';

import { NewsletteraddPageRoutingModule } from './newsletteradd-routing.module';

import { NewsletteraddPage } from './newsletteradd.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    NewsletteraddPageRoutingModule,
    ReactiveFormsModule 
  ],
  declarations: [NewsletteraddPage]
})
export class NewsletteraddPageModule {}
