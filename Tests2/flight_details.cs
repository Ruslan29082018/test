using System;
using System.Collections.Generic;
using System.Text;

namespace Tests2
{
    public class Segment_flicht_details
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

    public class Route_flicht_details
    {
        public string luggage { get; set; }
        public string handLuggage { get; set; }
        public string comments { get; set; }
        public List<Segment_flicht_details> segments { get; set; }
        public int duration { get; set; }
    }

    public class Flight_flicht_details
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
        public List<Route_flicht_details> routes { get; set; }
    }

    public class Segment2_flicht_details
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

    public class Route2_flicht_details
    {
        public string luggage { get; set; }
        public string handLuggage { get; set; }
        public string comments { get; set; }
        public List<Segment2_flicht_details> segments { get; set; }
        public int duration { get; set; }
    }

    public class FareFamily_flicht_details
    {
        public string fareFamilyTicketId { get; set; }
        public double price { get; set; }
        public string supplier { get; set; }
        public bool isRefundable { get; set; }
        public bool isExchangable { get; set; }
        public string luggage { get; set; }
        public string handLuggage { get; set; }
        public string comments { get; set; }
        public int duration { get; set; }
        public double recommendationFactor { get; set; }
        public List<Route2_flicht_details> routes { get; set; }
    }

    public class Route3_flicht_details
    {
        public Int64 origin { get; set; }
        public Int64 destination { get; set; }
        public string destinationAirportCode { get; set; }
        public string date { get; set; }
    }

    public class Request_flicht_details
    {
        public int adults { get; set; }
        public int kids { get; set; }
        public int infants { get; set; }
        public string searchProfile { get; set; }
        public List<Route3_flicht_details> routes { get; set; }
    }

    public class RootObject_flicht_details
    {
        public Flight_flicht_details flight { get; set; }
        public List<FareFamily_flicht_details> fareFamilies { get; set; }
        public Request_flicht_details request { get; set; }
        public Int64 requestId { get; set; }
    }
}
