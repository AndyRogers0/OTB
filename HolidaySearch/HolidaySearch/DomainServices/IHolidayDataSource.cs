using HolidaySearch.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.PublicInterfaces
{
    internal interface IHolidayDataSource
    {
        List<Flight> GetFlights();
        List<Hotel> GetHotels();
    }
}
