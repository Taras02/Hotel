using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Booking
    {

        public int BookingId { get; set; }
        //public int CustomerID { get; set; }
        
        public int RoomID { get; set;  }
        public int CodeOrder { get; set; }
        public DateTime Checkin { get; set;  }
        public DateTime Checkout { get; set; }
        public string Status { get; set; }
        //public DateTime DateBooking { get; set; }
        public virtual ICollection <Room> Rooms { get; set; }

    }
}
