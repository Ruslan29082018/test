using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Net;


namespace Tests2
{
    class Hotels
    {
        Program totKlac = new Program();
        //https://apitest.suntigo.com/api/1/hotel/search
        public Int64 Post_Hotel(DateTime checkInParametrs, DateTime checkOutParametrs, Int64 destinationParametrs, int adultsParametrs = 1)
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
            HttpWebRequest http_hotel = (HttpWebRequest)WebRequest.Create("https://apitest.suntigo.com/api/1/hotel/search");
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
            try
            {
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
            }
            catch (WebException rt)
            {
                Console.WriteLine(rt.Message);
                Stream qweqwe = rt.Response.GetResponseStream();
                StreamReader streamReaderqweqe = new StreamReader(qweqwe);
                string qwe = streamReaderqweqe.ReadToEnd();
                Console.WriteLine(qwe);
                return 0;
            }
        }  
    }
}