namespace HolidaySearch.DomainModels
{
    internal class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int PricePerNight { get; set; } // all prices in data are in whole pounds, assuming this will always be true and using int
        public List<string>? LocalAirports { get; set; }
        public int Nights { get; set; }
    }
}
