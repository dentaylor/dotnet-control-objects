import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule],
  template: `
    <h1>PrimeNG Storybook</h1>
    <nav>
      <a routerLink="/dropdown">Dropdown</a>
    </nav>
    <router-outlet />
  `
})
export class AppComponent {}
