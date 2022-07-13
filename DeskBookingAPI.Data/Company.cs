using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Adress { get; set; }
        [JsonIgnore]
        List<Employee> Employees { get; set; }
        [JsonIgnore]
        List<CompanyRoom> CompanyRooms { get; set; }

    }
}
