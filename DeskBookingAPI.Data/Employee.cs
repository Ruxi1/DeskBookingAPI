using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
        [JsonIgnore]
        public Company? Company { get; set; }
        [JsonIgnore]
        public List<Booking>? Bookings { get; set; }
    }
}
