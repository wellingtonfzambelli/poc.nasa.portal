import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PictureofthedayComponent } from './pages/pictureoftheday/pictureoftheday.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'pictureoftheday', component: PictureofthedayComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }