using System;
using System.Collections.Generic;
using System.Text;

namespace Tests2
{
    public class PackagePostSearch
    {
        public class Route
        {
            public Int64 origin { get; set; }
            public Int64 destination { get; set; }
            public string destinationAirportCode { get; set; }
            public string date { get; set; }
        }

        public class TicketProfile
        {
            public List<int> transportTypes { get; set; }
            public string stops { get; set; }
            public string serviceClass { get; set; }
        }

        public class HotelProfile
        {
            public List<string> hotelTypes { get; set; }
            public List<string> meals { get; set; }
            public List<string> stars { get; set; }
            public string rating { get; set; }
            public bool freeCancellation { get; set; }
        }

        public class RootObject
        {
            public int adults { get; set; }
            public int kids { get; set; }
            public int infants { get; set; }
            public string searchProfile { get; set; }
            public List<Route> routes { get; set; }
            public TicketProfile ticketProfile { get; set; }
            public HotelProfile hotelProfile { get; set; }
        }
    }
}
