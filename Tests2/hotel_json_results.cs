using System;
using System.Collections.Generic;
using System.Text;

namespace Tests2
{
    public class Item
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

    public class Hotel_json_results
    {
        public Request request { get; set; }
        public List<Item> items { get; set; }
        public string timestamp { get; set; }
        public bool isDone { get; set; }
    }
}
