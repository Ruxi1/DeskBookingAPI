using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DeskId { get; set; }
      
        public DateTime Date { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }
        [JsonIgnore]
        public Desk? Desk { get; set; }
    }
}
