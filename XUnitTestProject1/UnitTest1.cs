using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Tests2;


namespace Tests2.XUnit
{
    public class UnitTest1
    {      
        DateTime dateTime = DateTime.Now;
        Program program = new Program();
        
        
        /// <summary>
        /// —войство
        /// </summary>
        private Suggest_Hotel[] _kak_test;
        public Suggest_Hotel[] Kak_Test
        {
            get
            {
                if (_kak_test == null)
                    _kak_test = program.GetSuggest("ћосква", "/suggest/hotel?term=");
                return _kak_test;
            }
        }

        /// <summary>
        /// ‘ункци€
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        public Suggest_Hotel[] GetKakTest(string City)
        {
            return program.GetSuggest(City, "/suggest/hotel?term=");
        }


        [Fact]
        public void Fact1SuggestHotel()
        {

            var x = 0;
            //тестирование эпи           
            //“ут можно вбить параметр в ручную, ожидание что будет введен город.
            //этот параметр после 
            //https://apitest.suntigo.com/api/suggest/hotel?term=
            //второй парметр не трогать!

            //результат теста.
            //если приходит пустой результат
            Assert.Equal(true, Kak_Test.Length != 0);
            //for (int i = 0; kak_test.Length > i; i++) {
            //    destination = kak_test[i].code;
            //    if (kak_test[i].name == "Moscow")
            //        }
        }
        [Fact]
        public void Fact2SuggestTiket()
        {
            //тестирование эпи           
            //“ут можно вбить параметр в ручную, ожидание что будет введен город.
            //этот параметр после 
            //https://apitest.suntigo.com/api/suggest/tiket?term=
            //второй параметр не трогать.
            //этот параметр
            Suggest_Hotel[] kak_test = program.GetSuggest("ћосква", "/suggest/ticket?Term=");

            //результат теста.
            //если приходит пустой результат
            Assert.Equal(true, kak_test.Length != 0);
        }
        [Fact]
        public void Fact3FlichtSearch()
        {
            //посылаем запрос пост на двоих человек из москвы(1) в барселону в ближайшию п€тницу возврат в через два дн€ в воскресенье(program.Friday_Sunday(dateTime)),  
            Int64 id_otvet = program.Post_F_P_BS_T("https://apitest.suntigo.com/api/1.0/flight/search", 1, 80, program.Friday_Sunday(dateTime), "80", 2);
            Assert.Equal(true, id_otvet != 0);
        }
        [Fact]
        public void Fact3FlichtStatus()
        {

            //посылаем запрос пост на двоих человек из москвы(1) в барселону в ближайшию п€тницу возврат в через два дн€ в воскресенье(program.Friday_Sunday(dateTime)),  
            Int64 id_otvet = program.Post_F_P_BS_T("https://apitest.suntigo.com/api/1.0/flight/search", 1, 80, program.Friday_Sunday(dateTime), "80", 2);
            Assert.Equal(true, id_otvet != 0);
            bool stat = program.Get_status(id_otvet, "/flight/status?RequestId=");
            Assert.Equal(true, stat);
        }
        [Fact]
        public void Fact3FlichtResults()
        {
            //посылаем запрос пост на двоих человек из москвы(1) в барселону в ближайшию п€тницу возврат в через два дн€ в воскресенье(program.Friday_Sunday(dateTime)),  
            Int64 id_otvet = program.Post_F_P_BS_T("https://apitest.suntigo.com/api/1.0/flight/search", 1, 80, program.Friday_Sunday(dateTime), "80", 2);
            Assert.Equal(true, id_otvet != 0);
            bool stat = program.Get_status(id_otvet, "/flight/status?RequestId=");
            program.Get_flicht_results(id_otvet);
            if (stat)
            {
                RootObject_flicht_result flight_2_json = program.Get_flicht_results(id_otvet);
                Assert.Equal(true, flight_2_json.flights.Count != 0);
            }
        }
        [Fact]
        public void Fact3FlichtDetails()
        {

            //посылаем запрос пост на двоих человек из москвы(1) в барселону в ближайшию п€тницу возврат в через два дн€ в воскресенье(program.Friday_Sunday(dateTime)),  
            Int64 id_otvet = program.Post_F_P_BS_T("https://apitest.suntigo.com/api/1.0/flight/search", 1, 80, program.Friday_Sunday(dateTime), "80", 2);
            Assert.Equal(true, id_otvet != 0);
            bool stat = program.Get_status(id_otvet, "/flight/status?RequestId=");
            program.Get_flicht_results(id_otvet);
            if (stat)
            {
                RootObject_flicht_result flight_2_json = program.Get_flicht_results(id_otvet);
                Assert.Equal(true, flight_2_json.flights.Count != 0);
                RootObject_flicht_details rootObject_Flicht_Det = program.Get_flicht_details(id_otvet, flight_2_json.flights[0].ticketId);
                Assert.Equal(true, rootObject_Flicht_Det.flight.routes.Count != 0);
            }
        }
        //на  момент написани€ теста работает только 1 москва 25 какойто город
        [Fact]
        public void Fact4Bus()
        {
            //DateTime dateTime = DateTime.Now;
            //1ый вариант
            //var ride_segment = program.Post_BS("https://apitest.suntigo.com/api/1/bus/search", 1, 25, program.Friday_Sunday(dateTime));

            // создаем запрос, посман
            RootObject post_v_flicht = new RootObject();
            Route route = new Route();
            Route route_2 = new Route();

            //post_v_flicht.routes = rout
            route.origin = 1;
            route.destination = 25;
            route.destinationAirportCode = "";
            route.date = program.Friday_Sunday(dateTime);

            route_2.origin = 25;
            route_2.destination = 1;
            route_2.destinationAirportCode = route_2.destination.ToString();
            //плюс два дн€, отбыти€ через два дн€
            route_2.date = route.date.AddDays(2);


            //post_v_flicht.searchProfile = parametr_searchProfile;
            post_v_flicht.routes = new List<Route>();

            post_v_flicht.routes.Add(route);
            post_v_flicht.routes.Add(route_2);

            Bus_post.RootObject buspost = new Bus_post.RootObject();
            Bus_post.RootObject rootObjectOtvet = new Bus_post.RootObject();
            buspost = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/search", post_v_flicht, rootObjectOtvet);

            Assert.Equal(true, buspost.busResponse.data.ride_list.Count != 0);

            Bus_post.RideSegmentId ride = new Bus_post.RideSegmentId();
            ride.rideSegmentId = buspost.busResponse.data.ride_list[0].ride_segment_id;
            Bus_post.RootObject_free freetickets_vpost = new Bus_post.RootObject_free();
            var otvet_freeTickets = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/freeTickets", ride, freetickets_vpost);

            Assert.Equal(true, otvet_freeTickets.data.position_list.Count != 0);

            Bus_post.RootObject_d otvet_des_otvet = new Bus_post.RootObject_d();
            var documents_otvet = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/documents", ride, otvet_des_otvet);

            Assert.Equal(true, documents_otvet.data.card_identity_list.Count != 0);

            Bus_post.RootObject_citizenship otvet_post_json = new Bus_post.RootObject_citizenship();
            var cictizen_otvet = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/citizenship", ride, otvet_post_json);

            Assert.Equal(true, cictizen_otvet.data.citizenship_list.Count != 0);

            //параметры которые пресылают ответ
            Bus_post.TemporaryBook temporary_post = new Bus_post.TemporaryBook();
            Bus_post.TemporaryBook_name.RootObject ser_tempory = new Bus_post.TemporaryBook_name.RootObject();
            temporary_post.name = "иван";
            temporary_post.freePlaceId = otvet_freeTickets.data.position_list[0].ToString();
            temporary_post.rideSegmentId = buspost.busResponse.data.ride_list[0].ride_segment_id;
            temporary_post.cardIdentityId = documents_otvet.data.card_identity_list[0].card_identity_id;
            temporary_post.seriesNumber = "1234123456";
            temporary_post.citizenshipId = cictizen_otvet.data.citizenship_list[0].citizenship_id;
            DateTime happy = new DateTime(2000, 01, 01);
            temporary_post.birthday = "2000-01-02"; //happy.ToString();
            Console.WriteLine("темпори пост  бертдэй строка вот эта " + temporary_post.birthday);
            temporary_post.gender = "1";
            temporary_post.phone = "88002006000";
            temporary_post.email = "mail@example.net";
            var otvet_tempo = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/temporaryBook", temporary_post, ser_tempory);

            Assert.Equal(true, otvet_tempo.data != null);

            Bus_post.CheckOperation.RootObject checkOper = new Bus_post.CheckOperation.RootObject();
            Bus_post.CheckOperation_zapros.RootObject zaprosChekoper = new Bus_post.CheckOperation_zapros.RootObject();
            zaprosChekoper.operationId = otvet_tempo.data.operation.operation_id;

            var otvet_checkOp = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/checkOperation", zaprosChekoper, checkOper);

            Assert.Equal(true, otvet_checkOp.data.operation != null);

            Bus_post.GetOperation.RootObject getOperation = new Bus_post.GetOperation.RootObject();
            var otvetGetOper = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/getOperation", zaprosChekoper, getOperation);

            Assert.Equal(true, otvetGetOper.data != null);

            Bus_post.BuyTicketOtvet.RootObject buyTicketOtvet = new Bus_post.BuyTicketOtvet.RootObject();
            Bus_post.BuyTicketZapros.RootObject buyTicketZapros = new Bus_post.BuyTicketZapros.RootObject();
            buyTicketZapros.operationId = otvet_tempo.data.operation.operation_id;
            buyTicketZapros.ticketId = otvet_tempo.data.operation.ticket_list[0].ticket_id.ToString();
            buyTicketZapros.ticketPrice = otvet_tempo.data.operation.ticket_list[0].price_unitiki.ToString();
            var otvetbuyTicket = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/buyTicket", buyTicketZapros, buyTicketOtvet);

            Assert.Equal(true, otvetbuyTicket.data != null);

            Bus_post.ReturnTicket.RootObject returnTicketZapros = new Bus_post.ReturnTicket.RootObject();
            returnTicketZapros.operationId = buyTicketZapros.operationId;
            returnTicketZapros.ticketId = buyTicketZapros.ticketId;

            Bus_post.ReturnTicketOtvet.RootObject returnTicketOtvet = new Bus_post.ReturnTicketOtvet.RootObject();
            var otvetReturnTicketjson = program.Post_zapros("https://apitest.suntigo.com/api/1/bus/returnTicket", returnTicketZapros, returnTicketOtvet);

            Assert.Equal(true, otvetReturnTicketjson.data != null);
        }
        [Fact]
        public void Fact5TrainSearch()
        {
            string train_POST_zap_URI = "https://apitest.suntigo.com/api/1/train/search";
            var train_id = program.Post_F_P_BS_T(train_POST_zap_URI, 1, 2, program.Friday_Sunday(dateTime), "", 2);
            //Console.WriteLine("айди поезда " + train_id);
            Assert.Equal(true, train_id != 0);

            bool status_train = program.Get_status(train_id, "/train/status?RequestId=");
            // Console.WriteLine("—татус поезда " + status_train);
            //https://apitest.suntigo.com/api/1/train/results?RequestId=58888467
            if (status_train)
            {
                var train_results = program.Get_train_results(train_id);
                Assert.Equal(true, train_results.trains.Count != 0);
                Train_details.RootObject train_details = program.Get_train_details(train_id, train_results.trains[0].routes[0].trainNumber);
                Assert.Equal(true, train_details.details != null);
            }
        }
        [Fact]
        public void Fact5TrainStatus()
        {
            string train_POST_zap_URI = "https://apitest.suntigo.com/api/1/train/search";
            var train_id = program.Post_F_P_BS_T(train_POST_zap_URI, 1, 2, program.Friday_Sunday(dateTime), "", 2);
            //Console.WriteLine("айди поезда " + train_id);
            Assert.Equal(true, train_id != 0);

            bool status_train = program.Get_status(train_id, "/train/status?RequestId=");

            Assert.Equal(true, status_train);

        }
        [Fact]
        public void Fact5TrainResults()
        {
            string train_POST_zap_URI = "https://apitest.suntigo.com/api/1/train/search";
            var train_id = program.Post_F_P_BS_T(train_POST_zap_URI, 1, 2, program.Friday_Sunday(dateTime), "", 2);
            //Console.WriteLine("айди поезда " + train_id);
            Assert.Equal(true, train_id != 0);

            bool status_train = program.Get_status(train_id, "/train/status?RequestId=");
            // Console.WriteLine("—татус поезда " + status_train);
            //https://apitest.suntigo.com/api/1/train/results?RequestId=58888467
            if (status_train)
            {
                var train_results = program.Get_train_results(train_id);
                Assert.Equal(true, train_results.trains.Count != 0);
            }
        }
        [Fact]
        public void Fact5TrainDetails()
        {
            string train_POST_zap_URI = "https://apitest.suntigo.com/api/1/train/search";
            var train_id = program.Post_F_P_BS_T(train_POST_zap_URI, 1, 2, program.Friday_Sunday(dateTime), "", 2);
            //Console.WriteLine("айди поезда " + train_id);
            Assert.Equal(true, train_id != 0);

            bool status_train = program.Get_status(train_id, "/train/status?RequestId=");
            // Console.WriteLine("—татус поезда " + status_train);
            //https://apitest.suntigo.com/api/1/train/results?RequestId=58888467
            if (status_train)
            {
                var train_results = program.Get_train_results(train_id);
                Assert.Equal(true, train_results.trains.Count != 0);
                Train_details.RootObject train_details = program.Get_train_details(train_id, train_results.trains[0].routes[0].trainNumber);
                Assert.Equal(true, train_details.details != null);
            }
        }
        [Fact]
        public void Fact6PackageSearch()
        {
            string package_POST_zap_URI = "https://apitest.suntigo.com/api/1.0/package/search";

            Int64 id_otvet_package = program.Post_F_P_BS_T(package_POST_zap_URI, 2395, 513, program.Friday_Sunday(dateTime), "513", 2);

            Assert.Equal(true, id_otvet_package != 0);

        }
        [Fact]
        public void Fact6PackageStatus()
        {
            string package_POST_zap_URI = "https://apitest.suntigo.com/api/1.0/package/search";

            Int64 id_otvet_package = program.Post_F_P_BS_T(package_POST_zap_URI, 2395, 513, program.Friday_Sunday(dateTime), "513", 2);

            Assert.Equal(true, id_otvet_package != 0);
            bool status = program.Get_status(id_otvet_package, "/package/status?RequestId=");
            Assert.Equal(true, status);

        }
        [Fact]
        public void Fact6PackageResults()
        {
            string package_POST_zap_URI = "https://apitest.suntigo.com/api/1.0/package/search";
            Int64 id_otvet_package = program.Post_F_P_BS_T(package_POST_zap_URI, 2395, 513, program.Friday_Sunday(dateTime), "513", 2);
            Assert.Equal(true, id_otvet_package != 0);
            bool status = program.Get_status(id_otvet_package, "/package/status?RequestId=");
            if (status)
            {
                var package_result = program.Get_package_results(id_otvet_package);
                Assert.Equal(true, package_result.combinations.Count != 0);
            }
        }
        [Fact]
        public void Fact6PackageAltflights()
        {
            string package_POST_zap_URI = "https://apitest.suntigo.com/api/1.0/package/search";

            Int64 id_otvet_package = program.Post_F_P_BS_T(package_POST_zap_URI, 2395, 513, program.Friday_Sunday(dateTime), "513", 2);

            Assert.Equal(true, id_otvet_package != 0);
            bool status = program.Get_status(id_otvet_package, "/package/status?RequestId=");

            if (status)
            {
                var package_result = program.Get_package_results(id_otvet_package);

                Assert.Equal(true, package_result.combinations.Count != 0);


                var packageAltho = program.Get_package_althotels(id_otvet_package, package_result.combinations[0].combinationId,
                    package_result.combinations[0].hotels[0].hotelId);
                Assert.Equal(true, packageAltho.hotels.Count != 0);

                RootObject_flicht_result flichtResult = program.Get_package_altflights(id_otvet_package, package_result.combinations[0].combinationId);
                Assert.Equal(true, flichtResult.flights[0].routes[0].segments.Count != 0);

                program.Get_package_details(id_otvet_package, flichtResult.flights[0].ticketId);

            }
        }
        [Fact]
        public void Fact6PackageAlthotels()
        {
            string package_POST_zap_URI = "https://apitest.suntigo.com/api/1.0/package/search";

            Int64 id_otvet_package = program.Post_F_P_BS_T(package_POST_zap_URI, 2395, 513, program.Friday_Sunday(dateTime), "513", 2);

            Assert.Equal(true, id_otvet_package != 0);
            bool status = program.Get_status(id_otvet_package, "/package/status?RequestId=");

            if (status)
            {
                var package_result = program.Get_package_results(id_otvet_package);
                Assert.Equal(true, package_result.combinations.Count != 0);
                var packageAltho = program.Get_package_althotels(id_otvet_package, package_result.combinations[0].combinationId,
                    package_result.combinations[0].hotels[0].hotelId);
                Assert.Equal(true, packageAltho.hotels.Count != 0);

            }
        }
        [Fact]
        public void Fact6PackageDetails()
        {
            string package_POST_zap_URI = "https://apitest.suntigo.com/api/1.0/package/search";

            Int64 id_otvet_package = program.Post_F_P_BS_T(package_POST_zap_URI, 2395, 513, program.Friday_Sunday(dateTime), "513", 2);

            Assert.Equal(true, id_otvet_package != 0);
            bool status = program.Get_status(id_otvet_package, "/package/status?RequestId=");

            if (status)
            {
                var package_result = program.Get_package_results(id_otvet_package);

                Assert.Equal(true, package_result.combinations.Count != 0);


                var packageAltho = program.Get_package_althotels(id_otvet_package, package_result.combinations[0].combinationId,
                    package_result.combinations[0].hotels[0].hotelId);
                Assert.Equal(true, packageAltho.hotels.Count != 0);

                RootObject_flicht_result flichtResult = program.Get_package_altflights(id_otvet_package, package_result.combinations[0].combinationId);
                Assert.Equal(true, flichtResult.flights[0].routes[0].segments.Count != 0);
                var otvetDetails = program.Get_package_details(id_otvet_package, flichtResult.flights[0].ticketId);
                Assert.Equal(true, otvetDetails.flight != null || otvetDetails.hotels != null);
            }
        }
        [Fact]
        public void Fact7HotelsSearch()
        {
            DateTime checkin = program.Friday_Sunday(dateTime);
            DateTime checkOut = checkin.AddDays(2);
            var id_post_hotel = program.Post_Hotel(checkin, checkOut, 513, 2);
            Assert.Equal(true, id_post_hotel != 0);
        }
        [Fact]
        public void Fact7HotelsStatus()
        {
            DateTime checkin = program.Friday_Sunday(dateTime);
            DateTime checkOut = checkin.AddDays(2);
            var id_post_hotel = program.Post_Hotel(checkin, checkOut, 513, 2);
            Assert.Equal(true, id_post_hotel != 0);

            var status_otel = program.Get_status(id_post_hotel, "/hotel/status?RequestId=");
            Assert.Equal(true, status_otel);

        }
        [Fact]
        public void Fact7HotelsResulsts()
        {
            DateTime checkin = program.Friday_Sunday(dateTime);
            DateTime checkOut = checkin.AddDays(2);
            var id_post_hotel = program.Post_Hotel(checkin, checkOut, 513, 2);
            Assert.Equal(true, id_post_hotel != 0);

            var status_otel = program.Get_status(id_post_hotel, "/hotel/status?RequestId=");
            if (status_otel)
            {
                Hotel_json_results id_is_details = program.Get_hotel_results(id_post_hotel, dateTime.ToString());
                Assert.Equal(true, id_is_details.items.Count != 0);
            }
        }
        [Fact]
        public void Fact7HotelsDetails()
        {
            DateTime checkin = program.Friday_Sunday(dateTime);
            DateTime checkOut = checkin.AddDays(2);
            var id_post_hotel = program.Post_Hotel(checkin, checkOut, 513, 2);
            Assert.Equal(true, id_post_hotel != 0);

            var status_otel = program.Get_status(id_post_hotel, "/hotel/status?RequestId=");
            if (status_otel)
            {
                Hotel_json_results id_is_details = program.Get_hotel_results(id_post_hotel, dateTime.ToString());
                Assert.Equal(true, id_is_details.items.Count != 0);
                var bookgash = program.Get_hotel_details(id_post_hotel, id_is_details.items[0].hotelId);
                Assert.Equal(true, bookgash != null);

            }
        }
        //не стоит услови€ проверки!!! нужно пон€ть что провер€ть на пустоту
        [Fact]
        public void Fact7HotelsBuyDetails()
        {
            //DateTime dateTime7 = new DateTime(2018, 09, 15);
            DateTime checkin = program.Friday_Sunday(dateTime);
            DateTime checkOut = checkin.AddDays(2);
            var id_post_hotel = program.Post_Hotel(checkin, checkOut, 513, 2);
            Assert.Equal(true, id_post_hotel != 0);

            var status_otel = program.Get_status(id_post_hotel, "/hotel/status?RequestId=");
            if (status_otel)
            {
                Hotel_json_results id_is_details = program.Get_hotel_results(id_post_hotel, dateTime.ToString());
                Assert.Equal(true, id_is_details.items.Count != 0);
                var bookgash = program.Get_hotel_details(id_post_hotel, id_is_details.items[0].hotelId);
                Assert.Equal(true, bookgash != null);
                string stroka = bookgash.hotelDetails.rooms[0].bookHash;
                var otvetBuy = program.Get_hotel_buydetails(stroka, id_post_hotel, id_is_details.items[0].hotelId);
                //otvetBuy.hotelDetails.
                Assert.Equal(true, otvetBuy.hotelDetails.rooms[0].bookHash != null);
            }
        }

        [Fact]
        public void Fact8ReferenceAirportsAll()
        {
            var otvetReverenceAirAll = program.GetReverenceAirportsAll(1, "English");
            Assert.Equal(true, otvetReverenceAirAll[0].iataCode != null);
        }
        [Fact]
        public void Fact8ReferenceAirportsFind()
        {
            var otvetReverenceAirAll = program.GetReverenceAirportsAll(1, "English");
            var otvetRevAirFind = program.GetReverenceAirportsFind(otvetReverenceAirAll[0].iataCode);
            Assert.Equal(true, otvetRevAirFind[0].iataCode != null);
        }
        [Fact]
        public void Fact8ReferenceAirportsNearest()
        {
            var otvetNearest = program.GetReverencesAiroportsNearest(513);
            Assert.Equal(true, otvetNearest[0].name != null);
        }
        [Fact]
        public void Fact8ReferenceAirlinesAll()
        {
            var pAirlinesAll = new Dictionary<object, string>()
            {
                { 12, "English"},
            };

            var uriZaprosPol = program.V_zapros("https://apitest.suntigo.com/api/1/reference/airlines/all", pAirlinesAll);
            var reverenceAirAll = program.GetZapros<ReferenceAirlinesAll[]>(uriZaprosPol);
            Assert.Equal(true, reverenceAirAll[0].name != null);
        }
        [Fact]
        public void Fact8ReferenceAirlinesFind()
        {
            var pAirlinesAll = new Dictionary<object, string>()
            {
                { 12, "English"},
            };

            var uriZaprosPol = program.V_zapros("https://apitest.suntigo.com/api/1/reference/airlines/all", pAirlinesAll);
            var reverenceAirAll = program.GetZapros<ReferenceAirlinesAll[]>(uriZaprosPol);
            Console.WriteLine("проверка запроса аиропорты с запроса  " + reverenceAirAll[0].name);

            //https://apitest.suntigo.com/api/1/reference/airlines/find?Code=as&Language=English
            var pAirlinesAll_ynikalnui = new Dictionary<string, string>()
            {
                {"Language", "English"},
            };

            //https://apitest.suntigo.com/api/1/reference/airlines/find?Code=ds&Language=English
            var otvetFind = program.Get<ReferenceAirlinesFind[]>("https://apitest.suntigo.com/api/1/reference/airlines/find", "Code", reverenceAirAll[0].code, "Language", "English");
            Assert.Equal(true, otvetFind[0].code != null);
        }
        [Fact]
        public void Fact8ReferenceMealsAll()
        {
            var otvetMeals = program.Get<ReferenceMealsAll[]>("https://apitest.suntigo.com/api/1/reference/meals/all", "Language", "English");
            Assert.Equal(true, otvetMeals != null);
        }
        [Fact]
        public void Fact8ReferenceCitiesAll()
        {
            var otvetCitiesAll = program.Get<ReferenceCitiesAll[]>("https://apitest.suntigo.com/api/1/reference/cities/all", "Language", "English");
            Assert.Equal(true, otvetCitiesAll[0].name != null);
        }

        [Fact]
        public void Fact8ReferenceCitiesFind()
        {
            //https://apitest.suntigo.com/api/1/reference/cities/all?Language=English
            var otvetCitiesAll = program.Get<ReferenceCitiesAll[]>("https://apitest.suntigo.com/api/1/reference/cities/all", "Language", "English");


            //https://apitest.suntigo.com/api/1/reference/cities/find?Name=Moscow&Language=English
            var otvetCitiesFind = program.Get<ReferenceCitiesAll[]>("https://apitest.suntigo.com/api/1/reference/cities/find", "Name", otvetCitiesAll[0].name, "Language", "English");
            Assert.Equal(true, otvetCitiesFind[0].name != null);
        }
        [Fact]
        public void Fact8ReferenceCountriesAll()
        {
            var otvetCoutriesAll = program.Get<ReferenceCountriesAll[]>("https://apitest.suntigo.com/api/1/reference/countries/all", "Language", "English");
            Assert.Equal(true, otvetCoutriesAll[0].name != null);
        }
        [Fact]
        public void Fact8ReferenceCountriesfind()
        {
            var otvetCoutriesAll = program.Get<ReferenceCountriesAll[]>("https://apitest.suntigo.com/api/1/reference/countries/all", "Language", "English");
            //https://apitest.suntigo.com/api/1/reference/countries/find?Name=Abkhazia&Language=English
            var otvetCountriesFind = program.Get<ReferenceCountriesAll[]>("https://apitest.suntigo.com/api/1/reference/countries/find", "Name", otvetCoutriesAll[0].name, "Language", "English");
            Assert.Equal(true, otvetCountriesFind[0].name != null);
        }
    }
}
