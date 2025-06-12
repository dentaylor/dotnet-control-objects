import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { DropdownPageComponent } from './components/dropdown.component';

import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    FormsModule,
    DropdownModule,
    AppComponent,
    DropdownPageComponent
  ],
})
export class AppModule { }
