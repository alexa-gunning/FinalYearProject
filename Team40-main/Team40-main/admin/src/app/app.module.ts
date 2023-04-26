import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgCalendarModule } from 'ionic2-calendar';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import   Chart   from 'chart.js/auto';
import { CommonModule } from '@angular/common';
import { BnNgIdleService } from 'bn-ng-idle';
@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, IonicModule.forRoot(), AppRoutingModule, HttpClientModule, FormsModule,
    ReactiveFormsModule,NgCalendarModule]
,  providers: [{ provide: RouteReuseStrategy, useClass: IonicRouteStrategy }, BnNgIdleService],
  bootstrap: [AppComponent],
})
export class AppModule {} 
