using HolidaySearch.Models;
using HolidaySearch.PublicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("HolidaySearchTests")] // needed to run unit tests
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] // needed to run Moq in debug mode
namespace HolidaySearch
{
    public class HolidaySearchService : IHolidaySearchService
    {
        private IHolidayDataSource _holidayDataSource;

        public HolidaySearchService()
        {
            // public constructor out of scope for this work, here we would instantiate a concrete class
            // to use as the HolidayDataSource
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor for unit tests to inject the mocked data source
        /// </summary>
        /// <param name="holidayDataSource"></param>
        internal HolidaySearchService(IHolidayDataSource holidayDataSource)
        {
            _holidayDataSource = holidayDataSource;
        }

        /// <summary>
        /// Query the flight and hotel data to get the best value holiday we can provide based on the customer requirements
        /// </summary>
        /// <param name="holidaySearchQuery">A fully populated holiday search query</param>
        /// <returns></returns>
        public HolidaySearchQueryResult GetHolidaySearchResults(HolidaySearchQuery holidaySearchQuery)
        {
            validateHolidaySearchQuery(holidaySearchQuery);

            var hotels = _holidayDataSource.GetHotels();
            var flights = _holidayDataSource.GetFlights();

            // Outbound Flight
            // resolve list of possible departing airport
            bool isAnyAirport = holidaySearchQuery.DepartingFrom == "Any";
            var departingAirports = GetListOfAirportsFromSearchQuery(holidaySearchQuery.DepartingFrom);

            // filter flights by destination airport, departing airport, and date
            // get the cheapest and add to result

            // Hotel
            // Filter list of hotels by date, nights, and local airports
            // get the cheapest and add to the results

            var searchQueryResult = new HolidaySearchQueryResult()
            {
                Flight = 0,
                Hotel = 0
            };

            return searchQueryResult;
        }

        /// <summary>
        /// Check the pre-conditions of the method are valid
        /// </summary>
        /// <param name="holidaySearchQuery"></param>
        /// <exception cref="ArgumentException"></exception>
        private void validateHolidaySearchQuery(HolidaySearchQuery holidaySearchQuery)
        {
            if (holidaySearchQuery == null
                || string.IsNullOrEmpty(holidaySearchQuery.TravelingTo)
                || string.IsNullOrEmpty(holidaySearchQuery.DepartingFrom)
                || string.IsNullOrEmpty(holidaySearchQuery.DepartureDate)
                || holidaySearchQuery.Duration < 1)
            {
                throw new ArgumentException($"Invalid holiday search query, received: {JsonSerializer.Serialize(holidaySearchQuery)}");
            }
        }


        private List<string> GetListOfAirportsFromSearchQuery(string airportQuery)
        {
            var airPorts = new List<string>();

            // I'm making the assumption here that this is a standardised way that the front end sends requests so
            // am going to look for matches based on the string. Ideally there would be separate fields for this to avoid
            // parsing errors, e.g. an "airport" field and a "location" field, with an "Any" boolean flag. It could even simply
            // have a collection of possible airports with the parsing of "any" or "any [location]" handled on the front end.
            string[] splitQuery = airportQuery.Split(' ');
            if (splitQuery[0] == "Any" && splitQuery.Length == 2)
            {
                // "Any [Location]"
                airPorts = _holidayDataSource.GetAirportsAtLocation(splitQuery[1]);
            }
            else if (splitQuery.Length == 1 && airportQuery != "Any")
            {
                // specific airport
                airPorts.Add(airportQuery);
            }
            else if (airportQuery == "Any")
            {
                // no error, filter not needed
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Expected '[Airport code]' or 'Any [Location]', recieved {airportQuery}");
            }

            return airPorts;
        }
    }
}
