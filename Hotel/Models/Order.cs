using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BookingId { get; set; }
        public DateTime DateArrival { get; set; }
        public DateTime DateDeparture { get; set; }
        //public int OrderServiceId { get; set; }
        public float Sum { get; set; }
        public string Status { get; set; }
        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
