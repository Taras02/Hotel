using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Phone { get; set; }
        public string PassportID { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }


    }
}
