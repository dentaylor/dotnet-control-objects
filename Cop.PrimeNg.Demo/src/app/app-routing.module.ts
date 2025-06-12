import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DropdownPageComponent } from './components/dropdown.component';

const routes: Routes = [
  { path: 'dropdown', component: DropdownPageComponent },
  // Add others here
  { path: '', redirectTo: 'dropdown', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
