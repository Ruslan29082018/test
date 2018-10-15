using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests2
{
    public class Train_details
    {
        public class AvailableSeat
        {
            public int seatType { get; set; }
            public double price { get; set; }
            public int totalAvailable { get; set; }
            public List<int> seatNumbers { get; set; }
        }

        public class Car
        {
            public string carType { get; set; }
            public string carCategory { get; set; }
            public string carClass { get; set; }
            public List<string> carServices { get; set; }
            public int carNumber { get; set; }
            public string carId { get; set; }
            public string description { get; set; }
            public bool isGendered { get; set; }
            public List<AvailableSeat> availableSeats { get; set; }
            public List<string> availableTariffs { get; set; }
        }

        public class Segment
        {
            public string trainNumber { get; set; }
            public string trainName { get; set; }
            public List<string> trainCategories { get; set; }
            public string departureStationCode { get; set; }
            public string departureStationName { get; set; }
            public string departureWaitTime { get; set; }
            public string arrivalStationCode { get; set; }
            public string arrivalStationName { get; set; }
            public string arrivalWaitTime { get; set; }
            public int duration { get; set; }
            public string departureDateTime { get; set; }
            public string arrivalDateTime { get; set; }
            public int distance { get; set; }
            public bool isElectronicRegistrationAvailable { get; set; }
            public bool isTwoStorey { get; set; }
            public List<Car> cars { get; set; }
        }

        public class Route
        {
            public List<Segment> segments { get; set; }
        }

        public class Item
        {
            public Int64 requestId { get; set; }
            public Int64 ticketId { get; set; }
            public float minCost { get; set; }
            public List<Route> routes { get; set; }
        }

        public class Route2
        {
            public Int64 origin { get; set; }
            public Int64 destination { get; set; }
            public string destinationAirportCode { get; set; }
            public string date { get; set; }
        }

        public class Profile
        {
            public List<int> transportTypes { get; set; }
            public string stops { get; set; }
            public string serviceClass { get; set; }
        }

        public class Request
        {
            public int adults { get; set; }
            public int kids { get; set; }
            public int infants { get; set; }
            public string searchProfile { get; set; }
            public List<Route2> routes { get; set; }
            public Profile profile { get; set; }
        }

        public class RootObject
        {
            public Item item { get; set; }
            public Request request { get; set; }
            public Int64 requestId { get; set; }
        }
    }
}
