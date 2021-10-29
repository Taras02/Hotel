using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public  class OrderService
    {
        public int OrderServiceId { get; set; }
        
        public string NameOrderService { get; set; }

        public float Cost { get; set; }
        public DateTime Date { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; } 
    }
}
