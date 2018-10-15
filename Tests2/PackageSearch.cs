using System;
using System.Collections.Generic;
using System.Text;

namespace Tests2
{
    /// <summary>
    /// класс для отправки пост запроса в пэкаджах черч 
    /// </summary>
    public class PackageSearchProfile
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
            public TicketProfile() { }
            //public TicketProfile(string stopsK, string serviceClassK, params Int32[] transportTypesK)
            //{
            //    stops = stopsK;
            //    serviceClass = serviceClassK;
            //}
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

        ///методы тикет профаил

        public TicketProfile TicketProfileStudent()
        {
            TicketProfile ticketProfileOne = new TicketProfile();
            //ticketProfileOne.serviceClass = "E";
            ticketProfileOne.serviceClass = ServiceClass.E.ToString();
            ticketProfileOne.stops = "0,4";
            List<int> mastransportTypes = new List<int>();
            mastransportTypes.Add(1);
            mastransportTypes.Add(2);
            mastransportTypes.Add(3);
            ticketProfileOne.transportTypes = mastransportTypes;
            return ticketProfileOne;
        }

        public TicketProfile TicketProfileEconom()
        {
            TicketProfile ticketProfileOne = new TicketProfile();
            ticketProfileOne.serviceClass = ServiceClass.E.ToString();
            ticketProfileOne.stops = "0,3";
            List<int> mastransportTypes = new List<int>();
            mastransportTypes.Add(1);
            mastransportTypes.Add(2);
            mastransportTypes.Add(3);
            ticketProfileOne.transportTypes = mastransportTypes;
            return ticketProfileOne;
        }

        public TicketProfile TicketProfileEconomPlus()
        {

            TicketProfile ticketProfileOne = new TicketProfile();
            ticketProfileOne.serviceClass = ServiceClass.E.ToString();
            ticketProfileOne.stops = "0,2";
            List<int> mastransportTypes = new List<int>();
            mastransportTypes.Add(1);
            mastransportTypes.Add(2);
            mastransportTypes.Add(3);
            ticketProfileOne.transportTypes = mastransportTypes;
            return ticketProfileOne;
        }

        public TicketProfile TicketProfileVIP()
        {

            TicketProfile ticketProfileOne = new TicketProfile();           
            ticketProfileOne.serviceClass = ServiceClass.B.ToString();
            ticketProfileOne.stops = "0,1";
            List<int> mastransportTypes = new List<int>();
            mastransportTypes.Add(1);
            mastransportTypes.Add(2);
            mastransportTypes.Add(3);
            ticketProfileOne.transportTypes = mastransportTypes;
            return ticketProfileOne;
        }

        ///методы HotelProfile для студента эконом экономплюс и вип
        public HotelProfile HotelProfileVIP()
        {
            HotelProfile hotelProfile = new HotelProfile();
            hotelProfile.freeCancellation = false;
            List<string> hoteltyp = new List<string>();
            hoteltyp.Add("hotel");
            hoteltyp.Add("apartment");
            hotelProfile.hotelTypes = hoteltyp;

            List<string> stars = new List<string>();
            stars.Add("4");
            stars.Add("5");

            hotelProfile.stars = stars;
            hotelProfile.rating = "7,10";
            return hotelProfile;
        }

        public HotelProfile HotelProfileStudent()
        {
            HotelProfile hotelProfile = new HotelProfile();
            hotelProfile.freeCancellation = false;
            List<string> hoteltyp = new List<string>();
            hoteltyp.Add("hotel");
            hoteltyp.Add("hostel");
            hoteltyp.Add("apartment");
            hoteltyp.Add("mini-hotel");
            hotelProfile.hotelTypes = hoteltyp;
            //хотел типс заполнен
            //милсы нуль132

            List<string> stars = new List<string>();
            stars.Add("1");
            stars.Add("2");
            stars.Add("3");
            hotelProfile.stars = stars;
            hotelProfile.rating = "5,8";
            return hotelProfile;
        }

        public HotelProfile HotelProfileEconomy()
        {
            HotelProfile hotelProfile = new HotelProfile();
            hotelProfile.freeCancellation = false;
            List<string> hoteltyp = new List<string>();
            hoteltyp.Add("hotel");
            hoteltyp.Add("apartment");
            hoteltyp.Add("mini-hotel");
            hotelProfile.hotelTypes = hoteltyp;
            //хотел типс заполнен
            //милсы нуль132

            List<string> stars = new List<string>();
            stars.Add("1");
            stars.Add("2");
            stars.Add("3");
            hotelProfile.stars = stars;
            hotelProfile.rating = "4,10";
            return hotelProfile;
        }

        public HotelProfile HotelProfileEconomyPlus()
        {
            HotelProfile hotelProfile = new HotelProfile();
            hotelProfile.freeCancellation = false;
            List<string> hoteltyp = new List<string>();
            hoteltyp.Add("hotel");
            hoteltyp.Add("apartment");
            hoteltyp.Add("mini-hotel");
            hotelProfile.hotelTypes = hoteltyp;
            //хотел типс заполнен
            //милсы нуль132

            List<string> stars = new List<string>();
            stars.Add("3");
            stars.Add("4");
            stars.Add("5");
            hotelProfile.stars = stars;
            hotelProfile.rating = "5,10";
            return hotelProfile;
        }
        /// <summary>
        /// Метод который возвращает тип рут из Москвы в Казань в ближайшию пятницу
        /// </summary>
        /// <returns></returns>
        public Route GetRouteOne()
        {
            Program program = new Program();
            DateTime dateTime = DateTime.Now;
            Route routePackage = new Route();
            routePackage.origin = 2395;
            routePackage.destination = 513;
            routePackage.destinationAirportCode = routePackage.destination.ToString();
            routePackage.date = program.Friday_Sunday(dateTime).ToString();
            return routePackage;
        }

        public Route GetRouteTwo()
        {
            Program program = new Program();
            DateTime dateTime = DateTime.Now;
            Route routePackage = new Route();
            routePackage.origin = 513;
            routePackage.destination = 2395;
            routePackage.destinationAirportCode = routePackage.destination.ToString();
            routePackage.date = program.Friday_Sunday(dateTime).AddDays(2).ToString();
            return routePackage;
        }

        public RootObject Economy()
        {
            RootObject packageSearchProfile = new RootObject();
            Route routePackage = GetRouteOne();
            Route routePackage2 = GetRouteTwo();
            packageSearchProfile.adults = 2;
            packageSearchProfile.routes = new List<Route>();
            packageSearchProfile.routes.Add(routePackage);
            packageSearchProfile.routes.Add(routePackage2);
            packageSearchProfile.ticketProfile = TicketProfileEconom();
            packageSearchProfile.hotelProfile = HotelProfileEconomy();
            return packageSearchProfile;
        }

        public RootObject Student()
        {
            RootObject packageSearchProfile = new RootObject();
            Route routePackage = GetRouteOne();
            Route routePackage2 = GetRouteTwo();
            packageSearchProfile.adults = 2;
            packageSearchProfile.routes = new List<Route>();
            packageSearchProfile.routes.Add(GetRouteOne());
            packageSearchProfile.routes.Add(GetRouteTwo());
            packageSearchProfile.ticketProfile = TicketProfileStudent();
            packageSearchProfile.hotelProfile = HotelProfileStudent();
            return packageSearchProfile;
        }
        public RootObject EconomyPlus()
        {
            RootObject packageSearchProfile = new RootObject();
            Route routePackage = GetRouteOne();
            Route routePackage2 = GetRouteTwo();
            packageSearchProfile.adults = 2;
            packageSearchProfile.routes = new List<Route>();
            packageSearchProfile.routes.Add(routePackage);
            packageSearchProfile.routes.Add(routePackage2);
            packageSearchProfile.ticketProfile = TicketProfileEconomPlus();
            packageSearchProfile.hotelProfile = HotelProfileEconomyPlus();
            return packageSearchProfile;
        }
        public RootObject VIP()
        {
            RootObject packageSearchProfile = new RootObject();
            Route routePackage = GetRouteOne();
            Route routePackage2 = GetRouteTwo();
            packageSearchProfile.adults = 2;
            packageSearchProfile.routes = new List<Route>();
            packageSearchProfile.routes.Add(routePackage);
            packageSearchProfile.routes.Add(routePackage2);
            packageSearchProfile.ticketProfile = TicketProfileVIP();
            packageSearchProfile.hotelProfile = HotelProfileVIP();
            return packageSearchProfile;
        }
    }

    enum ServiceClass
    {
        E, B
    }
}
