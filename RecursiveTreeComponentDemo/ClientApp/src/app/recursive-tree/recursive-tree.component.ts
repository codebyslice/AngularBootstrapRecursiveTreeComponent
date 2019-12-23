import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'recursive-tree',
    templateUrl: './recursive-tree.component.html'

})
export class  RecursiveTreeComponent {

    @Input() treeData: any;// Employee[];
    @Input() temp: string;
  @Input() expandAll: boolean;

    public employees: Employee[] = [];
    public any: any;
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    }

    
    toggleChildren(employee:any) {
    employee.visible = !employee.visible;
  }

}

export class Employee {
    public employeeId: number;
    public employeeName: string;
    public managerId: number;
    public manager: Employee
    public children: Employee[];
}


