using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using HolidaySearch.Services;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchTests
{
    [TestClass]
    public class HolidaySearchServiceTests
    {
        private HolidaySearchService _holidaySearchService;
        private Mock<IHolidayDataSource> _holidayDataSourceMock;

        public HolidaySearchServiceTests()
        {
            // create the mocked data service to inject into the holiday search service
            _holidayDataSourceMock = new Mock<IHolidayDataSource>();
            _holidaySearchService = new HolidaySearchService(_holidayDataSourceMock.Object);
        }

        [TestInitialize]
        public void Setup()
        {
            // mock the data interface
            var flights = GetFlights();
            var hotels = GetHotels();

            _holidayDataSourceMock.Setup(h => h.GetHotels()).Returns(hotels);
            _holidayDataSourceMock.Setup(h => h.GetFlights()).Returns(flights);
        }

        [TestMethod]
        public void TestCustomer1()
        {
        }

        [TestMethod]
        public void TestCustomer2()
        {
        }

        [TestMethod]
        public void TestCustomer3()
        {
        }

        private List<Flight> GetFlights()
        {
            // this could be read from a file if we want to preserve the JSON formatting
            string flightsJSON = @"
                [
                  {
                    ""Id"": 1,
                    ""Airline"": ""First Class Air"",
                    ""From"": ""MAN"",
                    ""To"": ""TFS"",
                    ""Price"": 470,
                    ""DepartureDate"": ""2023-07-01""
                  },
                  {
                    ""Id"": 2,
                    ""Airline"": ""Oceanic Airlines"",
                    ""From"": ""MAN"",
                    ""To"": ""AGP"",
                    ""Price"": 245,
                    ""DepartureDate"": ""2023-07-01""
                  },
                  {
                    ""Id"": 3,
                    ""Airline"": ""Trans American Airlines"",
                    ""From"": ""MAN"",
                    ""To"": ""PMI"",
                    ""Price"": 170,
                    ""DepartureDate"": ""2023-06-15""
                  },
                  {
                    ""Id"": 4,
                    ""Airline"": ""Trans American Airlines"",
                    ""From"": ""LTN"",
                    ""To"": ""PMI"",
                    ""Price"": 153,
                    ""DepartureDate"": ""2023-06-15""

                  },
                  {
                    ""Id"": 5,
                    ""Airline"": ""Fresh Airways"",
                    ""From"": ""MAN"",
                    ""To"": ""PMI"",
                    ""Price"": 130,
                    ""DepartureDate"": ""2023-06-15""
                  },
                  {
                    ""Id"": 6,
                    ""Airline"": ""Fresh Airways"",
                    ""From"": ""LGW"",
                    ""To"": ""PMI"",
                    ""Price"": 75,
                    ""DepartureDate"": ""2023-06-15""
                  },
                  {
                    ""Id"": 7,
                    ""Airline"": ""Trans American Airlines"",
                    ""From"": ""MAN"",
                    ""To"": ""LPA"",
                    ""Price"": 125,
                    ""DepartureDate"": ""2022-11-10""
                  },
                  {
                    ""Id"": 8,
                    ""Airline"": ""Fresh Airways"",
                    ""From"": ""MAN"",
                    ""To"": ""LPA"",
                    ""Price"": 175,
                    ""DepartureDate"": ""2023-11-10""
                  },
                  {
                    ""Id"": 9,
                    ""Airline"": ""Fresh Airways"",
                    ""From"": ""MAN"",
                    ""To"": ""AGP"",
                    ""Price"": 140,
                    ""DepartureDate"": ""2023-04-11""
                  },
                  {
                    ""Id"": 10,
                    ""Airline"": ""First Class Air"",
                    ""From"": ""LGW"",
                    ""To"": ""AGP"",
                    ""Price"": 225,
                    ""DepartureDate"": ""2023-07-01""
                  },
                  {
                    ""Id"": 11,
                    ""Airline"": ""First Class Air"",
                    ""From"": ""LGW"",
                    ""To"": ""AGP"",
                    ""Price"": 155,
                    ""DepartureDate"": ""2023-07-01""
                  },
                  {
                    ""Id"": 12,
                    ""Airline"": ""Trans American Airlines"",
                    ""From"": ""MAN"",
                    ""To"": ""AGP"",
                    ""Price"": 202,
                    ""DepartureDate"": ""2023-10-25""
                  }
                ]
            ";

            List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(flightsJSON);
            return flights;
        }

        private List<Hotel> GetHotels()
        {
            // this could be read from a file if we want to preserve the JSON formatting
            string hotelsJSON = @"
                [
                  {
                    ""Id"": 1,
                    ""Name"": ""Iberostar Grand Portals Nous"",
                    ""ArrivalDate"": ""2022-11-05"",
                    ""PricePerNight"": 100,
                    ""LocalAirports"": [""TFS""],
                    ""Nights"": 7
                  },
                  {
                    ""Id"": 2,
                    ""Name"": ""Laguna Park 2"",
                    ""ArrivalDate"": ""2022-11-05"",
                    ""PricePerNight"": 50,
                    ""LocalAirports"": [""TFS""],
                    ""Nights"": 7
                  },
                  {
                    ""Id"": 3,
                    ""Name"": ""Sol Katmandu Park & Resort"",
                    ""ArrivalDate"": ""2023-06-15"",
                    ""PricePerNight"": 59,
                    ""LocalAirports"": [""PMI""],
                    ""Nights"": 14
                  },
                  {
                    ""Id"": 4,
                    ""Name"": ""Sol Katmandu Park & Resort"",
                    ""ArrivalDate"": ""2023-06-15"",
                    ""PricePerNight"": 59,
                    ""LocalAirports"": [""PMI""],
                    ""Nights"": 14
                  },
                  {
                    ""Id"": 5,
                    ""Name"": ""Sol Katmandu Park & Resort"",
                    ""ArrivalDate"": ""2023-06-15"",
                    ""PricePerNight"": 60,
                    ""LocalAirports"": [""PMI""],
                    ""Nights"": 10
                  },
                  {
                    ""Id"": 6,
                    ""Name"": ""Club Maspalomas Suites and Spa"",
                    ""ArrivalDate"": ""2022-11-10"",
                    ""PricePerNight"": 75,
                    ""LocalAirports"": [""LPA""],
                    ""Nights"": 14
                  },
                  {
                    ""Id"": 7,
                    ""Name"": ""Club Maspalomas Suites and Spa"",
                    ""ArrivalDate"": ""2022-09-10"",
                    ""PricePerNight"": 76,
                    ""LocalAirports"": [""LPA""],
                    ""Nights"": 14
                  },
                  {
                    ""Id"": 8,
                    ""Name"": ""Boutique Hotel Cordial La Peregrina"",
                    ""ArrivalDate"": ""2022-10-10"",
                    ""PricePerNight"": 45,
                    ""LocalAirports"": [""LPA""],
                    ""Nights"": 7
                  },
                  {
                    ""Id"": 9,
                    ""Name"": ""Nh Malaga"",
                    ""ArrivalDate"": ""2023-07-01"",
                    ""PricePerNight"": 83,
                    ""LocalAirports"": [""AGP""],
                    ""Nights"": 7
                  },
                  {
                    ""Id"": 10,
                    ""Name"": ""Barcelo Malaga"",
                    ""ArrivalDate"": ""2023-07-05"",
                    ""PricePerNight"": 45,
                    ""LocalAirports"": [""AGP""],
                    ""Nights"": 10
                  },
                  {
                    ""Id"": 11,
                    ""Name"": ""Parador De Malaga Gibralfaro"",
                    ""ArrivalDate"": ""2023-10-16"",
                    ""PricePerNight"": 100,
                    ""LocalAirports"": [""AGP""],
                    ""Nights"": 7
                  },
                  {
                    ""Id"": 12,
                    ""Name"": ""MS Maestranza Hotel"",
                    ""ArrivalDate"": ""2023-07-01"",
                    ""PricePerNight"": 45,
                    ""LocalAirports"": [""AGP""],
                    ""Nights"": 14
                  },
                  {
                    ""Id"": 13,
                    ""Name"": ""Jumeirah Port Soller"",
                    ""ArrivalDate"": ""2023-06-15"",
                    ""PricePerNight"": 295,
                    ""LocalAirports"": [""PMI""],
                    ""Nights"": 10
                  }
                ]
            ";

            List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(hotelsJSON);
            return hotels;
        }
    }
}
