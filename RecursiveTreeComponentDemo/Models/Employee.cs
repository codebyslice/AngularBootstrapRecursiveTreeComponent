using System;
using System.Collections.Generic;

namespace EmployeeHierarchy.Models
{
    public partial class Employee
    {
        public Employee(int EmployeeId,string EmployeeName,int? ManagerId)
        {
            Children = new List<Employee>(); //new HashSet<Employee>();
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.ManagerId = ManagerId;
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual List<Employee> Children { get; set; }
    }
}
