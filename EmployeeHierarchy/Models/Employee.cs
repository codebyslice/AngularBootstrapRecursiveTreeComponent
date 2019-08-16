using System;
using System.Collections.Generic;

namespace EmployeeHierarchy.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Children = new HashSet<Employee>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Children { get; set; }
    }
}
