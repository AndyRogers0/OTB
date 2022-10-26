using HolidaySearch.Models;
using HolidaySearch.PublicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("HolidaySearchTests")]
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
            var hotels = _holidayDataSource.GetHotels();
            var flights = _holidayDataSource.GetFlights();

            // Outbound Flight
            // resolve list of possible departing airport
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
    }
}
