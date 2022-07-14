using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class CompanyRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
        [JsonIgnore]
        public Company? Company { get; set; }
        [JsonIgnore]
        List<Desk>? Desks { get; set; }
    }
}
