using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch
{
    public interface IHolidaySearchService
    {
        HolidaySearchQueryResult GetHolidaySearchResults(HolidaySearchQuery holidaySearchQuery);
    }
}
