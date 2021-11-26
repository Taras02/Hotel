using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Postion { get; set; }
        public float Salary { get; set; }
        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
