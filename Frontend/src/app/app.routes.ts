import { Routes } from '@angular/router';

import { Login } from './components/login/login';
import { Layout } from './layout/layout';
import { DashboardComponent } from './components/dashboard/dashboard';

export const routes: Routes = [
{
    path:'',
    redirectTo:'login',
    pathMatch:'full'
},

{
    path:'login',
    component:Login
},

{
    path:'',
    component:Layout,

    children:[

        {
            path:'dashboard',
            loadComponent:()=>
                import('./components/dashboard/dashboard')
                .then(m=>m.DashboardComponent)
        },
        {
            path:'check-in',
            loadComponent:()=>import('./components/check-in/check-in')
            .then(c=>c.CheckIn)
        },
        {
            path:'check-out',
            loadComponent:()=>import('./components/check-out/check-out')
            .then(c=>c.CheckOut)
        },
        {
            path:'attendance-history',
            loadComponent:()=>import('./components/attendance-history/attendance-history')
            .then(c=>c.AttendanceHistory)
        },
        {
            path:'monthly-report',
            loadComponent:()=>import('./components/monthly-report/monthly-report')
            .then(c=>c.MonthlyReport)
        },
        {
            path:'attendance-details/:id',
            loadComponent:()=>import('./components/attendance-details/attendance-details')
            .then(c=>c.AttendanceDetails)
        }
    ]
}

];