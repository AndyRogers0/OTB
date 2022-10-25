using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Interfaces
{
    public interface IHolidayDataSource
    {
        List<Flight> GetFlights();
        List<Hotel> GetHotels();
    }
}
