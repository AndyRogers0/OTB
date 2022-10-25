using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Services
{
    public class HolidaySearchService
    {
        private IHolidayDataSource _holidayDataSource;

        public HolidaySearchService(IHolidayDataSource holidayDataSource)
        {
            _holidayDataSource = holidayDataSource;
        }

        /// <summary>
        /// Query the flight and hotel data to get the best value holiday we can provide based on the customer requirements
        /// </summary>
        /// <param name="holidaySearchQuery">A fully populated holiday search query</param>
        /// <returns></returns>
        public string GetHolidaySearchResults(HolidaySearchQuery holidaySearchQuery)
        {
            return "";
        } 
    }
}
