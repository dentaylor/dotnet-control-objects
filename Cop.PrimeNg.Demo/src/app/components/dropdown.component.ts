import { Component } from '@angular/core';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dropdown-page',
  standalone: true,
  imports: [CommonModule, FormsModule, DropdownModule],
  template: `
    <h2>PrimeNG Dropdown</h2>
    <p-dropdown 
      [options]="cities" 
      optionLabel="name" 
      placeholder="Select a City">
    </p-dropdown>
    <p *ngIf="selectedCity">You selected: {{ selectedCity.name }}</p>
  `
})
export class DropdownPageComponent {
  cities = [
    { name: 'New York', code: 'NY' },
    { name: 'Rome', code: 'RM' },
    { name: 'London', code: 'LDN' },
    { name: 'Istanbul', code: 'IST' },
    { name: 'Paris', code: 'PRS' }
  ];

  selectedCity: any;
}
