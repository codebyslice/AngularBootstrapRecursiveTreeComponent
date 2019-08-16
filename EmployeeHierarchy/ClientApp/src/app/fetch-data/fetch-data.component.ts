import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public employees: Employee[]=[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Employee[]>(baseUrl + 'api/Employees').subscribe(result => {
      debugger;
      this.employees = result;
    }, error => console.error(error));
  }
}

  export  class Employee {
    public EmployeeId: number;
    public EmployeeName: string;
    public ParentId: number;
    public Parent: Employee
    public InverseParent: Employee[];
    }
