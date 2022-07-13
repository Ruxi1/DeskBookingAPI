using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class Desk
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsStanding { get; set; }
        public int CompanyRoomId { get; set; }
        public CompanyRoom CompanyRoom { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
