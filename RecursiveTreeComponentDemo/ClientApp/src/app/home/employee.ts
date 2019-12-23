 //public partial class Employee {
 //   public Employee() {
 //       Children = new HashSet<Employee>();
 //   }

 //   public int EmployeeId { get; set; }
 //       public string EmployeeName { get; set; }
 //       public int ? ManagerId { get; set; }

 //       public virtual Employee Manager { get; set; }
 //       public virtual ICollection < Employee > Children { get; set; }
 //   }

export class employee{
    employeeId: number;
    employeeName: string;
    manager: employee;
    managerId?: number;
    children: employee[] = [];
    visible: boolean;

}
