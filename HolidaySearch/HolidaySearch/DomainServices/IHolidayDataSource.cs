using HolidaySearch.DomainModels;

namespace HolidaySearch.PublicInterfaces
{
    internal interface IHolidayDataSource
    {
        List<Flight> GetFlights();
        List<Hotel> GetHotels();
        List<string> GetAirportsAtLocation(string location);
    }
}
