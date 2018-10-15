using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests2
{

    public class Hotel_json
    {
        public string checkOut { get; set; }
        public string checkIn { get; set; }
        public Int64 destination { get; set; }
        public int adults { get; set; }
        public int kids { get; set; }
        public int infants { get; set; }
        public string searchProfile { get; set; }
    }
    public class Req
    {
        public int requestId { get; set; }
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
        public double price { get; set; }
        public List<Image2> images { get; set; }
        public List<CancelationPolicy> cancelationPolicy { get; set; }
        public bool isRefundable { get; set; }
        public List<CancelationPolicyMessage> cancelationPolicyMessage { get; set; }
        public string freeCancellationBefore { get; set; }
        public List<Meal> meals { get; set; }
        public List<RoomType> roomTypes { get; set; }
        public string bookHash { get; set; }
    }

    public class HotelDetails
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

    public class Request_hotels
    {
        public string checkOut { get; set; }
        public string checkIn { get; set; }
        public Int64 destination { get; set; }
        public int adults { get; set; }
        public int kids { get; set; }
        public int infants { get; set; }
        public string searchProfile { get; set; }
        public List<string> meals { get; set; }
        public List<int> stars { get; set; }
    }

    public class RootObject__hotels
    {
        public HotelDetails hotelDetails { get; set; }
        public Request_hotels request { get; set; }
    }

}