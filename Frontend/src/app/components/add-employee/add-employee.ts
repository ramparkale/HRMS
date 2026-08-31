import { Component } from '@angular/core';
import { Router } from '@angular/router';
//import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-add-employee',
  imports: [],
  templateUrl: './add-employee.html',
  styleUrl: './add-employee.css',
})
export class AddEmployeeComponent {

  employee:any={};

  constructor(
   // private empService:EmployeeService,
    private router:Router
  ){}

  saveEmployee(){

    // this.empService.addEmployee(this.employee);

    alert("Employee Added");

    this.router.navigate(['/employees']);

  }
}
