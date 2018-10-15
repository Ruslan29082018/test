using System;
using System.Collections.Generic;
using System.Text;

//sddsgfds 

namespace Tests2
{
    public class Package_result
    {
        public class Segment
        {
            public string supplier { get; set; }
            public string supplierName { get; set; }
            public string aircraft { get; set; }
            public string aircraftCode { get; set; }
            public string flightNumber { get; set; }
            public int duration { get; set; }
            public string departureDateTime { get; set; }
            public string departureAirportCode { get; set; }
            public string departureAirportName { get; set; }
            public string departureCity { get; set; }
            public string arrivalDateTime { get; set; }
            public string arrivalAirportCode { get; set; }
            public string arrivalAirportName { get; set; }
            public string arrivalCity { get; set; }
            public string serviceClass { get; set; }
            public string baggageInfo { get; set; }
        }

        public class Route
        {
            public string luggage { get; set; }
            public string handLuggage { get; set; }
            public string comments { get; set; }
            public List<Segment> segments { get; set; }
            public int duration { get; set; }
        }

        public class Flight
        {
            public double price { get; set; }
            public string supplier { get; set; }
            public bool isRefundable { get; set; }
            public bool isExchangable { get; set; }
            public string luggage { get; set; }
            public string handLuggage { get; set; }
            public string comments { get; set; }
            public int duration { get; set; }
            public double recommendationFactor { get; set; }
            public List<Route> routes { get; set; }
            public bool fareFamily { get; set; }
        }

        public class SerpFilter
        {
            public string code { get; set; }
            public string title { get; set; }
        }

        public class MealType
        {
            public string code { get; set; }
            public string title { get; set; }
        }

        public class City
        {
            public string code { get; set; }
            public string title { get; set; }
        }

        public class Hotel
        {
            public Int64 hotelId { get; set; }
            public Int64 requestId { get; set; }
            public string description { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string name { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public float rating { get; set; }
            public int reviewCount { get; set; }
            public string mainPhoto { get; set; }
            public List<SerpFilter> serpFilters { get; set; }
            public int stars { get; set; }
            public string roomTitle { get; set; }
            public double price { get; set; }
            public List<MealType> mealType { get; set; }
            public string hotelType { get; set; }
            public string countryCode { get; set; }
            public Int64 cityId { get; set; }
            public City city { get; set; }
            public List<double> dailyPrices { get; set; }
            public bool isFreeCancellationAvailable { get; set; }
        }

        public class Combination
        {
            public int combinationId { get; set; }
            public Flight flight { get; set; }
            public List<Hotel> hotels { get; set; }
        }

        public class Route2
        {
            public Int64 origin { get; set; }
            public Int64 destination { get; set; }
            public string destinationAirportCode { get; set; }
            public string date { get; set; }
        }

        public class Request
        {
            public int adults { get; set; }
            public int kids { get; set; }
            public int infants { get; set; }
            public string searchProfile { get; set; }
            public List<Route2> routes { get; set; }
        }

        public class RootObject
        {
            public List<Combination> combinations { get; set; }
            public Request request { get; set; }
        }
    }
}
