import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {

  employees:any = [

    {
      id:1,
      name:'Ram',
      email:'ram@gmail.com',
      department:'IT'
    },

    {
      id:2,
      name:'Shyam',
      email:'shyam@gmail.com',
      department:'HR'
    }

  ];

  getEmployees(){

    return this.employees;

  }

  addEmployee(emp:any){

    this.employees.push(emp);

  }

}