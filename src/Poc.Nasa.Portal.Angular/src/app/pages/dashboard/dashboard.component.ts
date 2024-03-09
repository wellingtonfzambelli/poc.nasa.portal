import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../services/dashboard.service';
import { Dashboard } from '../../models/dashboard.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})

export class DashboardComponent implements OnInit {
  public dashboard = <Dashboard>{};
  private _dashboardService: DashboardService;

  constructor(dashboardService: DashboardService){
    this._dashboardService = dashboardService;
  }

  ngOnInit(): void {
    
     this._dashboardService.GetDashboard()
       .subscribe(data => {
          this.dashboard = data;
       });
  }
}