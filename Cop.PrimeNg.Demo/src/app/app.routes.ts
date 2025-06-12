import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'dropdown', loadComponent: () => import('./components/dropdown.component').then(m => m.DropdownPageComponent) },
  { path: '', redirectTo: 'dropdown', pathMatch: 'full' }
];
