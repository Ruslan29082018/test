using System;
using System.Collections.Generic;
using System.Text;

namespace Tests2
{
    public class TrainProfile
    {
        public class Route
        {
            public Int64 origin { get; set; }
            public Int64 destination { get; set; }
            public string destinationAirportCode { get; set; }
            public string date { get; set; }
        }

        public class Profile
        {
            public List<int> transportTypes { get; set; } //0 1 2 3 4 8
            public string stops { get; set; }
            public string serviceClass { get; set; }
        }

        public class RootObject
        {
            public int adults { get; set; }
            public int kids { get; set; }
            public int infants { get; set; }
            public string searchProfile { get; set; }
            public List<Route> routes { get; set; }
            public Profile profile { get; set; }
        }
    }
}
