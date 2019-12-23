import { Component, Inject } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { employee } from './employee';
import { Observable } from 'rxjs/Observable';
import { RecursiveTreeComponent } from '../recursive-tree/recursive-tree.component';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    public employees: any; // Employee[] = [];
    public any: any;
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

        http.get<Employee[]>(baseUrl + 'api/Employees/GetEmployees').subscribe(result => {
            debugger;
            this.employees = result;
        }, error => console.error(error));
    }
}


export class Employee {
  public employeeId: number;
  public employeeName: string;
  public managerId: number;
  public manager: Employee
    public children: Employee[];
    public visible: false;
}
//employeeId":1,"employeeName":"John A","managerId":null,"manager":null,"children"
