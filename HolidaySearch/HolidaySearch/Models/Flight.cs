using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? Airline { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public int Price { get; set; } // all prices in data are in whole pounds, assuming this will always be true and using int
        public DateTime DepartureDate { get; set; }
    }
}
