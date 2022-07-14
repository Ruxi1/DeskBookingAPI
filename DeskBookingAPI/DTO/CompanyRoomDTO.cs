﻿using System.Text.Json.Serialization;

namespace DeskBookingAPI.DTO
{
    public class CompanyRoomDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public int? CompanyId { get; set; }
     
        public string? Floor { get; set; }
      
        public string? Number { get; set; }

        
    }
}
