using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading;
using Tests2.Api.Reverence.Get;
using System.Reflection;

///переделаны типы для компиляции дататаймы некторые инты в  строки searchProfile и т.д.
/**
 * Задача ставилось на проверку API адресов пустой ли приходит ответ.
 * 
 * данные запросы APi имеют свои параметры, если параметры не верны ответ будет ошибычным придет пустой.(логическая ошибка или нет??)
 * запросы посылаются на ближайшию пятницу(если пятница сегодня то на следующию пятниц .) выезд через два дня то есть в воскресенье.
 * кол-во людей два
 * параметры отправляются конкретные, на один запрос конкретные параметры.

 * Вначале код писался под конкретный запрос
 * в самом конце используются, более оптимизированные методы. для пост и гет запросов. Если в дальнейшим будут добавлены другие ГЕТ и Пост запросы, 
 * для гет запросов метод public T Get<T>(string url, params object[] parametr) гет запрос Т обозначает тип который будет возвращен.
 * Это тип который из строки образуется в объект
 * 
 * для пост public V Post_zapros<T, V>(string zapros_post_URI, T ser_v_post, V des) 
 * Где Т это объект который посылается в запрос, V это тип который приходит из запроса в объекте
 *
 * на момент на писания теста, по автобусам не работают некоторые запросы(они на данный момент не правильно сделаны).
 * Поэтому будет красным результат, закоментирован.
 * 
 * Тесты использовать нужно через обозреватель тестов, там есть синяя кнопка выполнить.
 * Если приходит зеленый ответ то это говорит о том что ответ пришел не пустым.
 * Проверяется условием булева как правило проверяется конктретный параметр на пустоту, строка на null если число на 0
 * Если же ответ красный значит условия не верны и зафиксирован нулевый ответ.
 * 
 * Особое внимание нужно уделить проверку на пустоту, так как создатель написал как мог и вероятней всего нужно что то изменить.
 * Не реализована запись логов, проверка на разные параметры.
 * Отчета об ошибки тоже нет. Если будет красный свет это значит что угодно, от неверных параметров отправленных до пустого ответа.
 * Более подробно можно посмотреть кликнув тест.
 * Ответ приходит строкой которые обрабатываются в джейсон объекты, для компиляции не которые свойства(поля, переменные) изменены с числа на строку, иначе возникает ошибка.
 * 
 * код юни теста находится в UnitTest1.cs
 * писались методы запроса Program.cs
 * остальное свойства для ответа и вопроса ь 
 * имена методов говорят что они делают.
 **/
namespace Tests2
{
    public class Program
    {
        /// <summary>
        /// дата высчитывается с сегодняшнего дня определяет когда будет ближайшая пятница
        /// </summary>
        /// <param name="dateTime_Now"></param>
        /// <returns></returns>
        public DateTime Friday_Sunday(DateTime dateTime_Now)
        {
            if (dateTime_Now.DayOfWeek == DayOfWeek.Friday)
                dateTime_Now = dateTime_Now.AddDays(6);
            for (int i = 1; dateTime_Now.DayOfWeek != DayOfWeek.Friday; i++)
            {
                //перебираем дни, до пятницы 
                //double day_do_patnis = (dateTime_Now.Day) + i;
                DateTime dateTime_for = dateTime_Now.AddDays((double)i);

                if (dateTime_for.DayOfWeek == DayOfWeek.Friday)
                    return dateTime_for;
            }
            return dateTime_Now;
        }
        /// <summary>
        /// конст ури адреса эпи, он один такой
        /// </summary>
        public const string API_URI = "https://apitest.suntigo.com/api/";
        public const string Version = "1.0";
        public const string URLPOSTfliqhtSearch = API_URI + Version +"/flight/search";
        public const string URLPOSTPackageSearch = API_URI + Version +"/package/search";
        public const string URLGETPackageResults = API_URI + Version +"/package/results";
        public const string URLPOSTTrainSearch = API_URI + Version + "/train/search";

        //запрос юри это адресс запроса, обж это объект в которым отправляется
        //для автоматизации нужно передать еще два типа, это для сериализации и десериализации, возвращать будет тоже тип
        //для сериализации реализован
        //для десериал V
        /// <summary>
        /// zapros_post_URI в этот параметр передается вторая часть строки пример "1/package/results"
        /// она плюсуется к константе "https://apitest.suntigo.com/api/"
        /// string URLzapros = API_URI + zapros_post_URI;
        ///  Убираю перехват ошибки, так как 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="zapros_post_URI"></param>
        /// <param name="ser_v_post"></param>
        /// <param name="des"></param>
        /// <returns></returns>
        public V Post_zapros<T, V>(string zapros_post_URI, T ser_v_post, V des)
        {
            MemoryStream stream1 = new MemoryStream();
            //это лучше передать в этот метод 
            //сериализовали в джейсон, но он пуст 
            DataContractJsonSerializer zapros = new DataContractJsonSerializer(typeof(T));

            //заполняем жейсон
            zapros.WriteObject(stream1, ser_v_post);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string sss = sr.ReadToEnd();

            //создаем запрос по юрл
            //string URLzapros = API_URI + zapros_post_URI;

            //HttpWebRequest http_flicht = (HttpWebRequest)WebRequest.Create(zapros_post_URI);
            HttpWebRequest http_flicht = (HttpWebRequest)WebRequest.Create(zapros_post_URI);
            http_flicht.Method = "POST";
            http_flicht.ContentType = "application/json";

            ASCIIEncoding aSCII = new ASCIIEncoding();
            //152 строка изменена
            byte[] byte1 = aSCII.GetBytes(sss);

            //для чего это строка? вроде как для распределении памяти
            http_flicht.ContentLength = byte1.Length;

            //создаем поток с запросом
            Stream stream = http_flicht.GetRequestStream();

            //в поток записываем байты
            stream.Write(byte1, 0, byte1.Length);
            //получаем ответ

            //try
            //{
                var httpResponse = http_flicht.GetResponse();

                //ответ в поток
                var responseStream = httpResponse.GetResponseStream();

                //записать поток в чтение
                var reader = new StreamReader(responseStream);
                //что прочли в строку

                string response = reader.ReadToEnd();

                //return response;
                var p = JsonConvert.DeserializeObject<V>(response);
                return p;
                //написать проверку на ответ, должен прийти флайт реквест
                // Console.WriteLine(response);
                //if (p.busResponse.data.ride_list.Count != 0)
                //    return p.busResponse.data.ride_list[0].ride_segment_id;
                //else return null;
            //}
            //catch (WebException rt)
            //{
            //    Console.WriteLine(rt.Message);
            //    Stream qweqwe = rt.Response.GetResponseStream();
            //    StreamReader streamReaderqweqe = new StreamReader(qweqwe);
            //    string qwe = streamReaderqweqe.ReadToEnd();
            //    Console.WriteLine(qwe);
            //    return des;
            //}
        }
        //общий метод для вовзрата из потока строки
        //если вовзрат эрор то ошибка запроса
        //это только гет
        /// <summary>
        /// Перестаю перехватывать ошибки от серевера для отображения ошибки в тестах. Иначе происходит перехват и понять что за веб ошибка можно с помощью отладки.
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        string Poluchi_stroku_posle_zaprosa(string res)
        {
           // try
           // {
           
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(res);

                //отправить запрос и получить ответ
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Получить из ответа поток ввода.
                Stream istrm = response.GetResponseStream();
                StreamReader reader = new StreamReader(istrm, Encoding.UTF8);
                //response.Close();
                return reader.ReadToEnd();
           // }
           // catch (WebException rt)
            //{
            //    Console.WriteLine(rt.Message);
            //    Stream qweqwe = rt.Response.GetResponseStream();
            //    StreamReader streamReaderqweqe = new StreamReader(qweqwe);
            //    string eror_stream = streamReaderqweqe.ReadToEnd();
            //    Console.WriteLine(eror_stream);
            //    return eror_stream;
            //}
        }

        //public Suggest_Hotel[] DoTest(string grad, string hotel_ticket)
        //{
        //    Suggest_Hotel[] suggests;

        //пишим метод который вставляет параметры 

        //в этом методе мы можем любой гет эпи проверить, если изменить строки после api
        //для проверки эпи нужно заменить AiB
        public Suggest_Hotel[] GetSuggest(string term, string hotel_ticket2, int count = 5)
        {

            string BiC = "&Count=";
            string c = Convert.ToString(count);
            //цепляем строки в запрос

            string res = API_URI + Version + hotel_ticket2 + term + BiC + c;

            // проверить строку 39 на наличие ошибок, проверка в блоках кэтч
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(res);

            //отпраить запрос и получить ответ
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Получить из ответа поток ввода.
            Stream istrm = response.GetResponseStream();

            //строка из потока
            string res_URI = StreamToString(istrm);

            //возврат виде строки
            string StreamToString(Stream stream)
            {
                //stream.Position = 0;
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
            //запись в строку стрима
            //проверка строки без чара
            //спомощью длины строки
            //string res_URI = StringWriter(istrm);
            //Console.WriteLine(res_URI);
            //test_ok = !(res_URI.Length < 3);

            //получаем джейсон из сайта, получения номера
            Suggest_Hotel[] p = JsonConvert.DeserializeObject<Suggest_Hotel[]>(res_URI);
            for (int mass_json_p = 0; p.Length > mass_json_p; mass_json_p++)
            {
                Console.WriteLine(p[mass_json_p].code);
            }
            response.Close();
            return p;
            // }
            //suggests = GetSuggest(grad, hotel_ticket);
            //return suggests;
        }
        /// <summary>
        /// статус если два еще не готов, если 3 готов
        /// используется в трех запросах флайты пакеты и поезда
        /// AiB это конкретный запрос адреса пример /flight/status?RequestId=
        /// полный адрес https://apitest.suntigo.com/api/1/flight/status?RequestId=58888279
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public bool Get_status(Int64 id, string AiB)
        {
            string res = API_URI + Version + AiB + Convert.ToString(id);
            int stat;
            int thumin = 0;
            do
            {
                const int milesek = 1000;
                Thread.Sleep(1000);
                string json_string = Poluchi_stroku_posle_zaprosa(res);
                Status_ status_status = JsonConvert.DeserializeObject<Status_>(json_string);
                stat = status_status.status;
                thumin = thumin + milesek;
                Console.WriteLine("пуск нн " + thumin);
                if (thumin == 120000) return false;

            } while (stat != 3);
            return true;
        }


        //api/{version}/flight/results
        //https://apitest.suntigo.com/api/1/flight/results?RequestId=58888279&Language=English
        /// <summary>
        /// в свагере на сайте json объект описан, там все типы как они должны быть. изменены: типы дататайм на стринг, searchProfile на стринг!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="param_lang"></param>
        public RootObject_flicht_result Get_flicht_results(Int64 id, string param_lang = "English")
        {
            string res = API_URI + Version + "/flight/results?RequestId=" + Convert.ToString(id) + "&Language=" + param_lang;

            string json_string = Poluchi_stroku_posle_zaprosa(res);
            //тут очень аккуратно нужно попасть в нужные типы, так как может не попасть
            RootObject_flicht_result flight_2_json = JsonConvert.DeserializeObject<RootObject_flicht_result>(json_string);
            return flight_2_json;
            //обработка запросов
            //for (int i = 0; i != flight_2_json.flights.Count; i++)
            //{
            //    Console.WriteLine("");
            //    Console.WriteLine("тикет айди " + flight_2_json.flights[i].ticketId);
            //    for (int ii = 0; ii != flight_2_json.flights[i].routes.Count; ii++)
            //    {
            //        Console.WriteLine("кол-во роутер у этого флайта " + flight_2_json.flights[i].routes.Count);
            //        for (int iii = 0; iii != flight_2_json.flights[i].routes[ii].segments.Count; iii++)
            //        {
            //            Console.WriteLine("кол-во сегментов " + flight_2_json.flights[i].routes[ii].segments.Count);
            //            Console.WriteLine("откуда летим {1} куда летим {2}  дата отбытия {0} дата прибытия {3}, запрос код аиропорта {4}", flight_2_json.flights[i].routes[ii].segments[iii].departureDateTime, flight_2_json.flights[i].routes[ii].segments[iii].departureCity, flight_2_json.flights[i].routes[ii].segments[iii].arrivalCity,
            //        flight_2_json.flights[i].routes[ii].segments[iii].arrivalDateTime, flight_2_json.request.routes[ii].destinationAirportCode);
            //        }
            //    }
            //}
        }
        //https://apitest.suntigo.com/api/1/package/results?RequestId=21171&Language=Russian
        public Package_result.RootObject Get_package_results(Int64 id, string param_lang = "Russian")
        {
            string result = API_URI + Version + "/package/results?RequestId=" + Convert.ToString(id) + "&Language=" + param_lang;

            string json_string = Poluchi_stroku_posle_zaprosa(result);
            //тут очень аккуратно нужно попасть в нужные типы, так как может не попасть
            Package_result.RootObject package_result_json = JsonConvert.DeserializeObject<Package_result.RootObject>(json_string);
            Console.WriteLine("разные типы кол-во комбинации combinations " + package_result_json.combinations.Count);
            if (package_result_json.combinations.Count != 0)
                Console.WriteLine("комбинация айди " + package_result_json.combinations[0].combinationId);
            return package_result_json;
        }


        //https://apitest.suntigo.com/api/1/flight/details?RequestId=58888283&TicketId=0&Language=English
        /// <summary>
        ///  в свагере на сайте json объект описан, там все типы как они должны быть. изменены: типы дататайм на стринг, searchProfile на стринг!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t_id"></param>
        /// <param name="version"></param>
        /// <param name="param_lang"></param>
        public RootObject_flicht_details Get_flicht_details(Int64 id, Int64 t_id, double version = 1.0, string param_lang = "English")
        {
            string res = API_URI + Version + "/flight/details?RequestId=" + (Convert.ToString(id)) + "&TicketId=" + (Convert.ToString(t_id)) + "&Language=" + param_lang;
            string json_string = Poluchi_stroku_posle_zaprosa(res);

            RootObject_flicht_details rootObject_Flicht_Det = JsonConvert.DeserializeObject<RootObject_flicht_details>(json_string);
            Console.WriteLine("запрос детали цена " + rootObject_Flicht_Det.flight.price);
            Console.WriteLine("реквест айди " + rootObject_Flicht_Det.requestId);
            return rootObject_Flicht_Det;
        }

        //https://apitest.suntigo.com/api/1/package/althotels?RequestId=21138&CombinationId=0&HotelId=0
        public Package_result.Combination Get_package_althotels(Int64 id, Int64 combId, Int64 hotelID)
        {
            string res = API_URI + Version + "/package/althotels?RequestId=" + (Convert.ToString(id)) + "&CombinationId="
            + (Convert.ToString(combId)) + "&HotelId=" + (Convert.ToString(hotelID));
            string json_string = Poluchi_stroku_posle_zaprosa(res);

            //проверить джейсон так как экспериментально вставлен в класс покэж результ
            Package_result.Combination hotellist = JsonConvert.DeserializeObject<Package_result.Combination>(json_string);
            Console.WriteLine("отель айди кол-во? если нуль то пустой " + hotellist.hotels.Count);
            return hotellist;
        }

        //https://apitest.suntigo.com/api/1/package/altflights?RequestId=21147&CombinationId=0
        //метод нужно допольнить так как мы ввели только обязательные параметры
        public RootObject_flicht_result Get_package_altflights(Int64 id, Int64 combId, Int64 hotelID = 0, Int64 tickedID = 0)
        {
            string res = API_URI + Version + "/package/altflights?RequestId=" + (Convert.ToString(id)) + "&CombinationId="
                + (Convert.ToString(combId));
            string json_string = Poluchi_stroku_posle_zaprosa(res);

            //джейсон подходит под этот тип
            RootObject_flicht_result package_altflights = JsonConvert.DeserializeObject<RootObject_flicht_result>(json_string);
            Console.WriteLine("гет пакеты алт флайты реквест тикет прайс " + package_altflights.flights[0].ticketId +
                package_altflights.flights[0].ticketId);
            return package_altflights;
        }

        //https://apitest.suntigo.com/api/1/package/details?RequestId=21149&TicketId=0&Language=English
        //второй вариант с отелем
        //https://apitest.suntigo.com/api/1/package/details?RequestId=21243&HotelIds=1647044&TicketId=3&Language=English
        /// <summary>
        /// Int64 ticketID этот параметр это кол-во массива комбинации из результа. Но можно вбить номер за пределы этого массива и ответ может быть!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticketID"></param>
        /// <param name="language"></param>
        /// <param name="hotel_id"></param>
        /// <param name="version"></param>
        public Get_package_details.RootObject Get_package_details(Int64 id, Int64 ticketID, string language = "English", Int64 hotel_id = 0)
        {
            string res;
            if (hotel_id == 0)
            {
                res = API_URI + Version + "/package/details?RequestId=" + (Convert.ToString(id)) +
                    "&TicketId=" + (Convert.ToString(ticketID)) + "&Language=" + language;
            }
            else
            {
                res = API_URI + Version + "/package/details?RequestId=" + (Convert.ToString(id)) +
                  "&HotelIds=" + (Convert.ToString(hotel_id)) + "&TicketId=" + (Convert.ToString(ticketID)) + "&Language=" + language;
            }
            string json_string = Poluchi_stroku_posle_zaprosa(res);

            Get_package_details.RootObject details = JsonConvert.DeserializeObject<Get_package_details.RootObject>(json_string);
            Console.WriteLine("проверка цена детаилс " + details.flight.price);
            return details;
        }


        //https://apitest.suntigo.com/api/1/train/results?RequestId=58888467
        public Train_json.RootObject Get_train_results(Int64 id)
        {
            string res = API_URI + Version + "/train/results?RequestId=" + Convert.ToString(id);
            string json_string = Poluchi_stroku_posle_zaprosa(res);

            Train_json.RootObject train_results = JsonConvert.DeserializeObject<Train_json.RootObject>(json_string);
            Console.WriteLine("что то от поезда " + train_results.trains[0].routes[0].trainNumber);
            return train_results;
        }

        //https://apitest.suntigo.com/api/1/train/details?RequestId=58888500&TrainNumber=258%D0%90
        public Train_details.RootObject Get_train_details(Int64 id, string TrainNumber)
        {
            string res = API_URI + Version + "/train/details?RequestId=" + Convert.ToString(id) +
                "&TrainNumber=" + TrainNumber;
            string json_string = Poluchi_stroku_posle_zaprosa(res);
            Train_details.RootObject train_details = JsonConvert.DeserializeObject<Train_details.RootObject>(json_string);

            return train_details;
        }



        /// <summary>
        /// этот метод подходит для POST запроса в Flicht, Package, train/search
        /// не подходит для bus запроса - ответ другой, запрос другие параметры. подумать над обработкой для автобуса
        /// </summary>
        /// <param name="zapros_post_URI"></param>
        /// <param name="parametr_origin"></param>
        /// <param name="parametr_destination"></param>
        /// <param name="parametr_date"></param>
        /// <param name="parametr_destinationAirportCode"></param>
        /// <param name="parametr_adults"></param>
        /// <param name="parametr_kids"></param>
        /// <param name="parametr_infants"></param>
        /// <param name="parametr_searchProfile"></param>
        /// <returns></returns>
        //параметры для пост запроса в флайтах
        //обязательно первые три параметра для вызыва данного метода 
        //можно заменить на тип рутобжикт, но то же самое
        public Int64 Post_F_P_BS_T(string zapros_post_URI, Int64 parametr_origin, Int64 parametr_destination, DateTime parametr_date, string parametr_destinationAirportCode = "t", int parametr_adults = 2, int parametr_kids = 0, int parametr_infants = 0)
        {
            // создаем запрос, посман
            RootObject post_v_flicht = new RootObject();
            Route route = new Route();
            Route route_2 = new Route();

            //post_v_flicht.routes = rout
            route.origin = parametr_origin;
            route.destination = parametr_destination;
            route.destinationAirportCode = parametr_destinationAirportCode;
            route.date = parametr_date;

            route_2.origin = parametr_destination;
            route_2.destination = parametr_origin;
            route_2.destinationAirportCode = route_2.destination.ToString();
            //плюс два дня, отбытия через два дня
            route_2.date = parametr_date.AddDays(2);

            post_v_flicht.adults = parametr_adults;
            post_v_flicht.kids = parametr_kids;
            post_v_flicht.infants = parametr_infants;
            //post_v_flicht.searchProfile = parametr_searchProfile;
            post_v_flicht.routes = new List<Route>();

            post_v_flicht.routes.Add(route);
            post_v_flicht.routes.Add(route_2);

            //память для вставки в жейсон
            MemoryStream stream1 = new MemoryStream();

            //сериализовали в джейсон, но он пуст 
            DataContractJsonSerializer zapros_POST_Flicht = new DataContractJsonSerializer(typeof(RootObject));

            //заполняем жейсон
            zapros_POST_Flicht.WriteObject(stream1, post_v_flicht);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string sss = sr.ReadToEnd();

            //создаем запрос по юрл
            HttpWebRequest http_flicht = (HttpWebRequest)WebRequest.Create(zapros_post_URI);
            http_flicht.Method = "POST";
            http_flicht.ContentType = "application/json";

            ASCIIEncoding aSCII = new ASCIIEncoding();
            //152 строка изменена
            byte[] byte1 = aSCII.GetBytes(sss);

            //для чего это строка? вроде как для распределении памяти
            http_flicht.ContentLength = byte1.Length;

            //создаем поток с запросом
            Stream stream = http_flicht.GetRequestStream();

            //в поток записываем байты
            stream.Write(byte1, 0, byte1.Length);
            //получаем ответ

           // try
            //{
                var httpResponse = http_flicht.GetResponse();

                //ответ в поток
                var responseStream = httpResponse.GetResponseStream();

                //записать поток в чтение
                var reader = new StreamReader(responseStream);
                //что прочли в строку

                string response = reader.ReadToEnd();

                ID_nom p = JsonConvert.DeserializeObject<ID_nom>(response);
                //написать проверку на ответ, должен прийти флайт реквест
                Console.WriteLine(response);
                bool post_flight_otvet = response != null;
                return p.requestId;
            //}
            //catch (WebException rt)
            //{
            //    Console.WriteLine(rt.Message);
            //    Stream qweqwe = rt.Response.GetResponseStream();
            //    StreamReader streamReaderqweqe = new StreamReader(qweqwe);
            //    string qwe = streamReaderqweqe.ReadToEnd();
            //    Console.WriteLine(qwe);
            //    return 0;
            //}
        }

        //https://apitest.suntigo.com/api/1/hotel/search
        public Int64 Post_Hotel(DateTime checkInParametrs, DateTime checkOutParametrs, Int64 destinationParametrs, int adultsParametrs)
        {
            Hotel_json post = new Hotel_json();
            post.checkIn = checkInParametrs.ToString();
            post.checkOut = checkOutParametrs.ToString();
            post.destination = destinationParametrs;
            post.adults = adultsParametrs;

            //память для вставки в жейсон
            MemoryStream stream1 = new MemoryStream();

            //сериализовали в джейсон, но он пуст 
            DataContractJsonSerializer zapros_POST_hotel = new DataContractJsonSerializer(typeof(Hotel_json));

            //заполняем жейсон
            zapros_POST_hotel.WriteObject(stream1, post);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string sss = sr.ReadToEnd();

            //создаем запрос по юрл

            HttpWebRequest http_hotel = (HttpWebRequest)WebRequest.Create(API_URI + Version + "/hotel/search");
            http_hotel.Method = "POST";
            http_hotel.ContentType = "application/json";

            ASCIIEncoding aSCII = new ASCIIEncoding();
            //152 строка изменена
            byte[] byte1 = aSCII.GetBytes(sss);

            //для чего это строка? вроде как для распределении памяти
            http_hotel.ContentLength = byte1.Length;

            //создаем поток с запросом
            Stream stream = http_hotel.GetRequestStream();

            //в поток записываем байты
            stream.Write(byte1, 0, byte1.Length);
            //получаем ответ
           // try
           // {
                var httpResponse = http_hotel.GetResponse();

                //ответ в поток
                var responseStream = httpResponse.GetResponseStream();

                //записать поток в чтение
                var reader = new StreamReader(responseStream);
                //что прочли в строку

                string response = reader.ReadToEnd();

                Req p = JsonConvert.DeserializeObject<Req>(response);
                //написать проверку на ответ, должен прийти флайт реквест
                Console.WriteLine(response);
                bool post_otvet = response != null;
                return p.requestId;
            //}
            //catch (WebException rt)
            //{
            //    Console.WriteLine(rt.Message);
            //    Stream qweqwe = rt.Response.GetResponseStream();
            //    StreamReader streamReaderqweqe = new StreamReader(qweqwe);
            //    string qwe = streamReaderqweqe.ReadToEnd();
            //    Console.WriteLine(qwe);
            //    return 0;
            //}

        }

        //кол-во людей не нужно вносить только откуда куда и дату
        public string Post_BS(string zapros_post_URI, Int64 parametr_origin, Int64 parametr_destination, DateTime parametr_date, string parametr_destinationAirportCode = "t")
        {
            // создаем запрос, посман
            RootObject post_v_flicht = new RootObject();
            Route route = new Route();
            Route route_2 = new Route();

            //post_v_flicht.routes = rout
            route.origin = parametr_origin;
            route.destination = parametr_destination;
            route.destinationAirportCode = parametr_destinationAirportCode;
            route.date = parametr_date;

            route_2.origin = parametr_destination;
            route_2.destination = parametr_origin;
            route_2.destinationAirportCode = route_2.destination.ToString();
            //плюс два дня, отбытия через два дня
            route_2.date = parametr_date.AddDays(2);


            //post_v_flicht.searchProfile = parametr_searchProfile;
            post_v_flicht.routes = new List<Route>();

            post_v_flicht.routes.Add(route);
            post_v_flicht.routes.Add(route_2);

            //память для вставки в жейсон
            MemoryStream stream1 = new MemoryStream();

            //сериализовали в джейсон, но он пуст 
            DataContractJsonSerializer zapros_POST_Flicht = new DataContractJsonSerializer(typeof(RootObject));

            //заполняем жейсон
            zapros_POST_Flicht.WriteObject(stream1, post_v_flicht);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string sss = sr.ReadToEnd();

            //создаем запрос по юрл
            HttpWebRequest http_flicht = (HttpWebRequest)WebRequest.Create(zapros_post_URI);
            http_flicht.Method = "POST";
            http_flicht.ContentType = "application/json";

            ASCIIEncoding aSCII = new ASCIIEncoding();
            //152 строка изменена
            byte[] byte1 = aSCII.GetBytes(sss);

            //для чего это строка? вроде как для распределении памяти
            http_flicht.ContentLength = byte1.Length;

            //создаем поток с запросом
            Stream stream = http_flicht.GetRequestStream();

            //в поток записываем байты
            stream.Write(byte1, 0, byte1.Length);
            //получаем ответ

           // try
            //{
                var httpResponse = http_flicht.GetResponse();

                //ответ в поток
                var responseStream = httpResponse.GetResponseStream();

                //записать поток в чтение
                var reader = new StreamReader(responseStream);
                //что прочли в строку

                string response = reader.ReadToEnd();

                var p = JsonConvert.DeserializeObject<Bus_post.RootObject>(response);
                //написать проверку на ответ, должен прийти флайт реквест
                // Console.WriteLine(response);
                if (p.busResponse.data.ride_list.Count != 0)
                    return p.busResponse.data.ride_list[0].ride_segment_id;
                else return null;
            //}
            //catch (WebException rt)
            //{
            //    Console.WriteLine(rt.Message);
            //    Stream qweqwe = rt.Response.GetResponseStream();
            //    StreamReader streamReaderqweqe = new StreamReader(qweqwe);
            //    string qwe = streamReaderqweqe.ReadToEnd();
            //    Console.WriteLine(qwe);
            //    return "что";
            //}
        }

        //api/{version}/hotel/results
        //https://apitest.suntigo.com/api/1/hotel/results?RequestId=4412&Language=English&Timestamp=01.08.2018
        //особоый параметр датастемп этот параметр самый сложный в данном запросе, он должен быть до времени запроса 
        //так же были проблемы с параметром дэстинация
        public Hotel_json_results Get_hotel_results(Int64 idparametr, string time, string lang = "English")
        {
            string res = API_URI + Version + "/hotel/results?RequestId=" + Convert.ToString(idparametr) + "&Language=" + lang + "&Timestamp=" + time;
            string json_string = Poluchi_stroku_posle_zaprosa(res);
            var train_details = JsonConvert.DeserializeObject<Hotel_json_results>(json_string);
            //Console.WriteLine("отель  айтемов " + train_details.items.Count);
            return train_details;
        }

        //https://apitest.suntigo.com/api/1/hotel/details?RequestId=4492&HotelId=15&Language=English
        public RootObject__hotels Get_hotel_details(Int64 idparametr, Int64 hotelID, string lang = "English")
        {
            string res = API_URI + Version + "/hotel/details?RequestId=" + Convert.ToString(idparametr) + "&HotelId="
                + Convert.ToString(hotelID) + "&Language=" + lang;
            string json_string = Poluchi_stroku_posle_zaprosa(res);
            var hotel_details = JsonConvert.DeserializeObject<RootObject__hotels>(json_string);
            Console.WriteLine("айди ппараметр хотеля который вошел " + hotelID);
            Console.WriteLine("отель сити метода детаилса  " + hotel_details.hotelDetails.cityId);
            return hotel_details;
        }
        //https://apitest.suntigo.com/api/1/hotel/buydetails?BookHash=h-fb611252-db12-57b2-9cf1-960c5c8166df&RequestId=4496&HotelId=1004718&Language=English
        public RootObject__hotels Get_hotel_buydetails(string bookh, Int64 idparametr, Int64 hotelID, string lang = "English")
        {
            string res = API_URI + Version + "/hotel/buydetails?BookHash=" + bookh + "&RequestId=" + Convert.ToString(idparametr)
               + "&HotelId=" + Convert.ToString(hotelID) + "&Language=" + lang;
            string json_string = Poluchi_stroku_posle_zaprosa(res);
            var hotel_details = JsonConvert.DeserializeObject<RootObject__hotels>(json_string);
            Console.WriteLine("айди ппараметр хотеля который вошел купить " + hotelID);
            Console.WriteLine("бук гаш " + bookh);
            Console.WriteLine("отель рейтинг метода купи детали  " + hotel_details.hotelDetails.cityId);
            return hotel_details;
        }

        public ReferenceAirportsAllParametr[] GetReverenceAirportsAll(string lang = "English")
        {
            string res = API_URI + Version + "/reference/airports/all?Language=" + lang;
            string otvet = Poluchi_stroku_posle_zaprosa(res);
            var otvetJson = JsonConvert.DeserializeObject<ReferenceAirportsAllParametr[]>(otvet);
            return otvetJson;

        }

        //https://apitest.suntigo.com/api/1/reference/airports/find?IATACode=GWA&Language=English
        public ReferenceAirportsAllParametr[] GetReverenceAirportsFind(string iatacode, string lang = "English")
        {
            string res = API_URI + Version+ "/reference/airports/find?IATACode=" + iatacode + "&Language=" + lang;
            string otvet = Poluchi_stroku_posle_zaprosa(res);
            var otvetJson = JsonConvert.DeserializeObject<ReferenceAirportsAllParametr[]>(otvet);
            return otvetJson;
        }
        //https://apitest.suntigo.com/api/1/reference/airports/nearest?SuggestId=80&Language=English
        public ReferenceAirportsNearest[] GetReverencesAiroportsNearest(int parametrIdSuggest, string lang = "English")
        {
            string res = API_URI + Version + "/reference/airports/nearest?SuggestId=" + Convert.ToString(parametrIdSuggest) + "&Language=" + lang;
            ReferenceAirportsNearest[] otvets = GetZapros<ReferenceAirportsNearest[]>(res);
            return otvets;
        }

        public T GetZapros<T>(string uri)
        {
            string otvet = Poluchi_stroku_posle_zaprosa(uri);
            var otvetJson = JsonConvert.DeserializeObject<T>(otvet);
            return otvetJson;
        }

        /// <summary>
        /// URL нужно записать без вопросительного знака и символов за этим знаком, так как прибавляется к строке параметры
        /// </summary>
        /// <param name="url"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public string V_zapros(string url, Dictionary<object, string> prms)
        {
            url += "?{0}";
            var pp = prms.Select(kvp =>
                $"{kvp.Key}={kvp.Value}");

            var pps = string.Join("&", pp);

            //pps = HttpUtility.UrlEncode(pps);

            url = string.Format(url, pps);

            return url;
        }
        /**
        /// Метод асбтрактный который принимает, параметры и создает юрл адрес. Параметры все сцепляются и отправляется запрос.
         *  Но имя переменный(свойства) нужно вносить как строку "Name".
         *  Ответ типа из метода нужно вводить в метод. 
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="parametr"></param>
        /// <returns></returns>
        **/
        public T Get<T>(string url, params object[] parametr)
        {
            Dictionary<object, object> dic = new Dictionary<object, object>();
            int i;
            int ii;
            for (i = 0, ii = 0; i != parametr.Length; i++)
            {
                ii = i + 1;
                dic.Add(parametr[i], parametr[ii]);
                i = i + 1;
            }

            url += "?{0}";
            var pp = dic.Select(kvp =>
                $"{kvp.Key}={kvp.Value}");

            var pps = string.Join("&", pp);

            //pps = HttpUtility.UrlEncode(pps);

            url = string.Format(url, pps);

            string otvet = Poluchi_stroku_posle_zaprosa(url);
            var otvetJson = JsonConvert.DeserializeObject<T>(otvet);
            return otvetJson;
        }

        /// <summary>
        /// сравнение происходит между двумя объектами, в начале сравниваеся отели по кол-ву, далее если кол-во одинаково по цене, типу отеля, звездам, если равны далее по роутам если равны далее
        /// по кол-ву сегементов, далее каждый роут сравниваеся особенным образом, так как 1 маршрут будет из
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="iterascombinObA"></param>
        /// <param name="iterascombinObB"></param>
        /// <param name="otelA"></param>
        /// <param name="otelB"></param>
        /// <param name="routsA"></param>
        /// <param name="routsB"></param>
        /// <param name="segmentsA"></param>
        /// <param name="segmentsB"></param>
        /// <returns></returns>
        public bool ZaprosSravneniePackageResultsProfileRootObject(PackageResultsProfile.RootObject a, PackageResultsProfile.RootObject b, int iterascombinObA, int iterascombinObB, int otelA,
            int otelB, int routsA, int routsB, int segmentsA, int segmentsB)
        {
            ///Сравнение двух объектов, 
            ///проверка по кол-ву отелей, далее номер отеля совпадает (пример первый отель 1го объекта будет сравниваться только с 1ым объектом второго объекта, если 2ой то со 2ым и т.д.).
            ///проверка по цене отеля
            ///проверка по типу отеля
            ///проверка по звездам отеля
            ///сравнение цены за билет flight.
            ///Проверка по роутам. Сравнивается первый полет с первым полетом другого объекта.
            ///Для того чтобы не было лишних сравниний (пример из А в Б и из Б в А).
            /// Сравнение по сервис классу и сервис класс типу
            bool resultatEquals = a.combinations[iterascombinObA].hotels.Count == b.combinations[iterascombinObB].hotels.Count
                                    &&
                                     a.combinations[iterascombinObA].hotels[otelA].price == b.combinations[iterascombinObB].hotels[otelB].price
                                      &&
                                       a.combinations[iterascombinObA].hotels[otelA].hotelType == b.combinations[iterascombinObB].hotels[otelB].hotelType
                                        &&
                                         a.combinations[iterascombinObA].hotels[otelA].stars == b.combinations[iterascombinObB].hotels[otelB].stars
                                          &&
                                           a.combinations[iterascombinObA].flight.price == b.combinations[iterascombinObB].flight.price
                                            &&
                                             a.combinations[iterascombinObA].flight.routes.Count == b.combinations[iterascombinObB].flight.routes.Count
                                              &&
                                               a.combinations[iterascombinObA].flight.routes[routsA].segments.Count == b.combinations[iterascombinObB].flight.routes[routsA].segments.Count
                                                &&
                                                 a.combinations[iterascombinObA].flight.routes[routsA].segments[segmentsA].serviceClass == b.combinations[iterascombinObB].flight.routes[routsA].segments[segmentsA].serviceClass
                                                  &&
                                                   a.combinations[iterascombinObA].flight.routes[routsA].segments[segmentsA].serviceClassType == b.combinations[iterascombinObB].flight.routes[routsA].segments[segmentsA].serviceClassType;

            //Console.WriteLine(" шаг итерации i комбо первого объекта {0}, шаг итерации роутес {1}, шаг итерации сегментов {2} ", iterascombinObA, routsA, segmentsA);
            //Console.WriteLine(" шаг итерации i комбо второго объекта {0}, шаг итерации роутес {1} ", iterascombinObB, routsB);
            //Console.WriteLine("a.combinations[iterascombinObA].flight.routes[routsA].segments[segmentsA].serviceClass {0} == b.combinations[iterascombinObB].flight.routes[routsA].segments[segmentsA].serviceClass {1}", a.combinations[iterascombinObA].flight.routes[routsA].segments[segmentsA].serviceClass, b.combinations[iterascombinObB].flight.routes[routsA].segments[segmentsA].serviceClass);
            //Console.WriteLine("a.combinations[iterascombinObA].flight.routes[routsA].segments[segmentsA].serviceClassType {0} == b.combinations[iterascombinObB].flight.routes[routsA].segments[segmentsA].serviceClassType {1}", a.combinations[iterascombinObA].flight.routes[routsA].segments[segmentsA].serviceClassType, b.combinations[iterascombinObB].flight.routes[routsA].segments[segmentsA].serviceClassType);
            //Console.WriteLine("");
            //нижняя строка для отлова булево через отладку.
            //if (resultatEquals) return resultatEquals;
            return resultatEquals;
        }
        public bool EqualsResults(PackageResultsProfile.RootObject a, PackageResultsProfile.RootObject b)
        {
            bool resultatEquals = false;
            //если пришел пустой ответ
            if ((a.combinations.Count == 0) && (b.combinations.Count == 0))
                return false;
            //для итерации первого объекта
            for (int iterascombinObA = 0; a.combinations.Count != iterascombinObA; iterascombinObA++)
            {
                //для итерации второго объекта
                for (int iterascombinObB = 0; b.combinations.Count != iterascombinObB; iterascombinObB++)
                {
                    //для итерации отелей
                    for (int otelA = 0; a.combinations[iterascombinObA].hotels.Count != otelA; otelA++)
                    {
                        for (int otelB = 0; b.combinations[iterascombinObB].hotels.Count != otelB; otelB++)
                        {
                            //итерация рутов
                            for (int routesA = 0; a.combinations[iterascombinObA].flight.routes.Count != routesA; routesA++)
                            {
                                for (int routesB = 0; b.combinations[iterascombinObB].flight.routes.Count != routesB; routesB++)
                                {
                                    for (int segmentsA = 0; a.combinations[iterascombinObA].flight.routes[routesA].segments.Count != segmentsA; segmentsA++)
                                    {
                                        Program program = new Program();
                                        resultatEquals = program.ZaprosSravneniePackageResultsProfileRootObject(a, b, iterascombinObA, iterascombinObB, otelA, otelB, routesA, routesA, segmentsA, segmentsA);

                                        ///true, если указанные объекты равны; в противном случае — false.Если оба параметра objA и objB имеют значение NULL, метод возвращает значение true.
                                        //resultatEquals = Equals(a.combinations[iterascombinObA], b.combinations[iterascombinObB]);

                                        //string jsoncombAFlight = JsonConvert.SerializeObject(a.combinations[iterascombinObA].flight);
                                        //string jsoncombAHotel = JsonConvert.SerializeObject(a.combinations[iterascombinObA].hotels);
                                        //string jsoncombBFlight = JsonConvert.SerializeObject(b.combinations[iterascombinObB].flight);
                                        //string jsoncombBHotel = JsonConvert.SerializeObject(b.combinations[iterascombinObB].hotels);

                                        //resultatEquals = (jsoncombAFlight == jsoncombBFlight) && (jsoncombAHotel == jsoncombBHotel);

                                        if (resultatEquals)
                                            return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static void Main()
        {

         

        Console.ReadKey();

        }  
    }
}

