using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests2
{
    //сделаем переименование название классов
    public class Segment_flicht_result
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

    public class Route_flicht_result
    {
        public string luggage { get; set; }
        public string handLuggage { get; set; }
        public string comments { get; set; }
        public List<Segment_flicht_result> segments { get; set; }
        public int duration { get; set; }
    }

    public class Flight_flicht_result
    {
        public Int64 requestId { get; set; }
        public Int64 ticketId { get; set; }
        public double price { get; set; }
        public string supplier { get; set; }
        public bool isRefundable { get; set; }
        public bool isExchangable { get; set; }
        public string luggage { get; set; }
        public string handLuggage { get; set; }
        public string comments { get; set; }
        public int duration { get; set; }
        public double recommendationFactor { get; set; }
        public List<Route_flicht_result> routes { get; set; }
    }

    public class Route2_flicht_result
    {
        public Int64 origin { get; set; }
        public Int64 destination { get; set; }
        public string destinationAirportCode { get; set; }
        public string date { get; set; }
    }

    public class Request_flicht_result
    {
        public int adults { get; set; }
        public int kids { get; set; }
        public int infants { get; set; }
        public string searchProfile { get; set; }
        public List<Route2_flicht_result> routes { get; set; }
    }

    public class RootObject_flicht_result
    {
        public List<Flight_flicht_result> flights { get; set; }
        public Request_flicht_result request { get; set; }
    }
    public class Suggest_Hotel
    {
        public int type { get; set; }
        public Int64 code { get; set; }
        public string name { get; set; }
        public string countryName { get; set; }
        public string cityName { get; set; }
        public double? longitude { get; set; }
        public double? latitude { get; set; }
        public bool hasAirport { get; set; }
    }
}

