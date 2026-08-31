import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { DashboardComponent } from './app/components/dashboard/dashboard';
import { EmployeeList } from './app/components/employee-list/employee-list';
import { AddEmployeeComponent } from './app/components/add-employee/add-employee';
import { Login } from './app/components/login/login';

const routes: Routes = [

  { path:'', component: Login},

  { path:'dashboard', component: DashboardComponent },

  { path:'employees', component: EmployeeList },

  { path:'add-employee', component: AddEmployeeComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }