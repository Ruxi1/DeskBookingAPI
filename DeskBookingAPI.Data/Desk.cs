using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class Desk
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsStanding { get; set; }
        public int CompanyRoomId { get; set; }
        [JsonIgnore]
        public CompanyRoom? CompanyRoom { get; set; }
        [JsonIgnore]
        public List<Booking>? Bookings { get; set; }
    }
}
