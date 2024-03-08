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
  public dashboard = new Observable<Dashboard>();
  private _dashboardService: DashboardService;

  constructor(dashboardService: DashboardService){
    this._dashboardService = dashboardService;
  }

  ngOnInit(): void {
    this.dashboard = this._dashboardService.GetDashboard();

    // this._dashboardService.GetDashboard()
    //   .subscribe(pictures => this.dashboard = pictures)
  }
}