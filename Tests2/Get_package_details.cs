using System;
using System.Collections.Generic;
using System.Text;

namespace Tests2
{
    public class Get_package_details
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

        public class AmenityList
        {
            public List<string> amenities { get; set; }
            public string group_slug { get; set; }
            public string group_name { get; set; }
        }

        public class Image
        {
            public string thumbnailURL { get; set; }
            public string url { get; set; }
        }

        public class Image2
        {
            public string thumbnailURL { get; set; }
            public string url { get; set; }
        }

        public class CancelationPolicy
        {
            public string start { get; set; }
            public string end { get; set; }
            public double penalty { get; set; }
        }

        public class CancelationPolicyMessage
        {
            public int order { get; set; }
            public string message { get; set; }
        }

        public class Meal
        {
            public string code { get; set; }
            public string title { get; set; }
        }

        public class RoomType
        {
            public string code { get; set; }
            public string title { get; set; }
        }

        public class Room
        {
            public string name { get; set; }
            public string description { get; set; }
            public int price { get; set; }
            public List<Image2> images { get; set; }
            public List<CancelationPolicy> cancelationPolicy { get; set; }
            public bool isRefundable { get; set; }
            public List<CancelationPolicyMessage> cancelationPolicyMessage { get; set; }
            public string freeCancellationBefore { get; set; }
            public List<Meal> meals { get; set; }
            public List<RoomType> roomTypes { get; set; }
            public string bookHash { get; set; }
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
            public string checkInTime { get; set; }
            public string checkOutTime { get; set; }
            public string policy { get; set; }
            public List<AmenityList> amenityList { get; set; }
            public List<Image> images { get; set; }
            public List<Room> rooms { get; set; }
            public string propertyType { get; set; }
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
            public Flight flight { get; set; }
            public List<Hotel> hotels { get; set; }
            public Request request { get; set; }
        }
    }
}
