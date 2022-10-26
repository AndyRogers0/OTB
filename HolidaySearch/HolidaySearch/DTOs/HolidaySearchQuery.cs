using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class HolidaySearchQuery
    {
        public string? DepartingFrom { get; set; }
        public string? TravelingTo { get; set; }
        public string? DepartureDate { get; set; }
        public int Duration { get; set; }
    }
}
