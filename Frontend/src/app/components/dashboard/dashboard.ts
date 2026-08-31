import { Component, OnInit } from '@angular/core';
import { DashboardService } from  '../../services/dashboard.service';
import { Dashboard } from '../../models/dashboard.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class DashboardComponent implements OnInit {

  dashboard!: Dashboard;

  constructor(private dashboardService: DashboardService) {}

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard() {
    this.dashboardService.getDashboard().subscribe({
      next: (res) => {
        this.dashboard = res;
        console.log('Dashboard data:', this.dashboard);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}