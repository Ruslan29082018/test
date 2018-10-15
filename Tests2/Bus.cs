using System;
using System.Collections.Generic;
using System.Text;

namespace Tests2
{
    public class Bus_post
    {
        public class StationStart
        {
            public int station_id { get; set; }
            public string station_title { get; set; }
            public int city_id { get; set; }
            public string city_title { get; set; }
            public string region_title { get; set; }
            public string district_title { get; set; }
            public int country_id { get; set; }
            public string country_title { get; set; }
            public string country_iso { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class StationEnd
        {
            public int station_id { get; set; }
            public string station_title { get; set; }
            public int city_id { get; set; }
            public string city_title { get; set; }
            public string region_title { get; set; }
            public string district_title { get; set; }
            public int country_id { get; set; }
            public string country_title { get; set; }
            public string country_iso { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class Bus
        {
            public string buss { get; set; }
        }

        public class RideList
        {
            public string ride_segment_id { get; set; }
            public int vendor_id { get; set; }
            public int is_relevant { get; set; }
            public string route_name { get; set; }
            public int place_cnt { get; set; }
            public string buy_place_cnt_max { get; set; }
            public int currency_source_id { get; set; }
            public int price_source_tariff { get; set; }
            public int currency_agent_id { get; set; }
            public int price_unitiki { get; set; }
            public int price_agent_fee { get; set; }
            public int price_agent_max { get; set; }
            public string datetime_start { get; set; }
            public string datetime_end { get; set; }
            public int distance { get; set; }
            public string can_be_annulated { get; set; }
            public StationStart station_start { get; set; }
            public StationEnd station_end { get; set; }
            public Bus bus { get; set; }
            public string carrier_title { get; set; }
        }

        public class StationStart2
        {
            public int station_id { get; set; }
            public string station_title { get; set; }
            public int city_id { get; set; }
            public string city_title { get; set; }
            public string region_title { get; set; }
            public string district_title { get; set; }
            public int country_id { get; set; }
            public string country_title { get; set; }
            public string country_iso { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class StationEnd2
        {
            public int station_id { get; set; }
            public string station_title { get; set; }
            public int city_id { get; set; }
            public string city_title { get; set; }
            public string region_title { get; set; }
            public string district_title { get; set; }
            public int country_id { get; set; }
            public string country_title { get; set; }
            public string country_iso { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class Bus2
        {
        }

        public class RideListSimilar
        {
            public string ride_segment_id { get; set; }
            public int vendor_id { get; set; }
            public int is_relevant { get; set; }
            public string route_name { get; set; }
            public int place_cnt { get; set; }
            public string buy_place_cnt_max { get; set; }
            public int currency_source_id { get; set; }
            public int price_source_tariff { get; set; }
            public int currency_agent_id { get; set; }
            public int price_unitiki { get; set; }
            public int price_agent_fee { get; set; }
            public int price_agent_max { get; set; }
            public string datetime_start { get; set; }
            public string datetime_end { get; set; }
            public int distance { get; set; }
            public string can_be_annulated { get; set; }
            public StationStart2 station_start { get; set; }
            public StationEnd2 station_end { get; set; }
            public Bus2 bus { get; set; }
            public string carrier_title { get; set; }
        }

        public class Data
        {
            public List<RideList> ride_list { get; set; }
            public List<RideListSimilar> ride_list_similar { get; set; }
        }

        public class BusResponse
        {
            public Data data { get; set; }
        }

        public class RootObject
        {
            public BusResponse busResponse { get; set; }
        }

        public class RideSegmentId
        {
            public string rideSegmentId { get; set; }
        }

        public class CardIdentityList
        {
            public string card_identity_id { get; set; }
            public string title { get; set; }
        }

        public class DatafreeTickets
        {
            public List<int> card_identity_list { get; set; }
        }

        public class RootObject_freeTickets
        {
            public DatafreeTickets data { get; set; }
        }
        public class CardIdentityList_d
        {
            public string card_identity_id { get; set; }
            public string title { get; set; }
        }

        public class Data_d
        {
            public List<CardIdentityList> card_identity_list { get; set; }
        }

        public class RootObject_d
        {
            public Data_d data { get; set; }
        }
        public class CitizenshipList
        {
            public string citizenship_id { get; set; }
            public string title { get; set; }
            public string iso { get; set; }
            public string iso3166 { get; set; }
        }

        public class Data_citi
        {
            public List<CitizenshipList> citizenship_list { get; set; }
        }

        public class RootObject_citizenship
        {
            public Data_citi data { get; set; }
        }
        public class TemporaryBook
        {
            public string freePlaceId { get; set; }
            public string rideSegmentId { get; set; }
            public string cardIdentityId { get; set; }
            public string citizenshipId { get; set; }
            public string seriesNumber { get; set; }
            public string name { get; set; }
            public string birthday { get; set; }
            public string gender { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
        }

        public class DatetimeBuy
        {
        }

        public class DatetimeCancel
        {
        }

        public class TicketRefund
        {
        }

        public class Phone
        {
        }

        public class DatetimeBuy2
        {
        }

        public class DatetimeCancel2
        {
        }

        public class Distance
        {
        }

        public class StationStart_TemporaryBook
        {
            public string station_id { get; set; }
            public string station_title { get; set; }
            public string city_id { get; set; }
            public string city_title { get; set; }
            public string region_title { get; set; }
            public string district_title { get; set; }
            public string country_id { get; set; }
            public string country_title { get; set; }
            public string country_iso { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class StationEnd_TemporaryBook
        {
            public string station_id { get; set; }
            public string station_title { get; set; }
            public string city_id { get; set; }
            public string city_title { get; set; }
            public string region_title { get; set; }
            public string district_title { get; set; }
            public string country_id { get; set; }
            public string country_title { get; set; }
            public string country_iso { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class Organization
        {
            public string organization_id { get; set; }
            public string title_full { get; set; }
            public string title_small { get; set; }
            public string ogrn { get; set; }
            public string phone { get; set; }
        }



        public class UserId
        {
        }

        public class TicketList
        {
            public int ticket_id { get; set; }
            public int operation_id { get; set; }
            public string operation_hash { get; set; }
            public int position { get; set; }
            public int status { get; set; }
            public TicketRefund ticket_refund { get; set; }
            public string series_number { get; set; }
            public string name { get; set; }
            public string birthday { get; set; }
            public int gender { get; set; }
            public Phone phone { get; set; }
            public string email { get; set; }
            public int currency_source_id { get; set; }
            public int price_source_tariff { get; set; }
            public int currency_agent_id { get; set; }
            public int price_unitiki { get; set; }
            public int price_agent_fee { get; set; }
            public int price_agent { get; set; }
            public int price_agent_max { get; set; }
            public int card_identity_id { get; set; }
            public string card_identity_title { get; set; }
            public int citizenship_id { get; set; }
            public string citizenship_title { get; set; }
            public DatetimeBuy2 datetime_buy { get; set; }
            public DatetimeCancel2 datetime_cancel { get; set; }
            public string datetime_start { get; set; }
            public string datetime_end { get; set; }
            public string route_name { get; set; }
            public Distance distance { get; set; }
            public StationStart_TemporaryBook station_start { get; set; }
            public StationEnd_TemporaryBook station_end { get; set; }
            public Organization organization { get; set; }
            public Bus bus { get; set; }
            public UserId user_id { get; set; }
        }

        public class Operation
        {
            public string operation_id { get; set; }
            public string hash { get; set; }
            public string partner_id { get; set; }
            public string agent_id { get; set; }
            public int status { get; set; }
            public string datetime_order { get; set; }
            public DatetimeBuy datetime_buy { get; set; }
            public DatetimeCancel datetime_cancel { get; set; }
            public int time_left_to_cancel { get; set; }
            public List<TicketList> ticket_list { get; set; }
        }

        public class Data_TemporaryBook
        {
            public Operation operation { get; set; }
        }

        public class ttttttt
        {
            public Data_TemporaryBook data { get; set; }
        }
        public class Data_free
        {
            public List<int> position_list { get; set; }
        }

        public class RootObject_free
        {
            public Data_free data { get; set; }
        }

        public class ReturnTicket
        {
            public class RootObject
            {
                public string operationId { get; set; }
                public string ticketId { get; set; }
            }
        }
        public class ReturnTicketOtvet
        {
            public class DatetimeReturn
            {
            }

            public class DatetimeCancel
            {
            }

            public class TicketRefund
            {
            }

            public class Phone
            {
            }

            public class DatetimeReturn2
            {
            }

            public class DatetimeCancel2
            {
            }

            public class Distance
            {
            }

            public class StationStart
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class StationEnd
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class Organization
            {
                public string organization_id { get; set; }
                public string title_full { get; set; }
                public string title_small { get; set; }
                public string ogrn { get; set; }
                public string phone { get; set; }
            }

            public class Bus
            {
            }

            public class UserId
            {
            }

            public class TicketList
            {
                public int ticket_id { get; set; }
                public int operation_id { get; set; }
                public string operation_hash { get; set; }
                public int position { get; set; }
                public int status { get; set; }
                public TicketRefund ticket_refund { get; set; }
                public string series_number { get; set; }
                public string name { get; set; }
                public string birthday { get; set; }
                public int gender { get; set; }
                public Phone phone { get; set; }
                public string email { get; set; }
                public int currency_source_id { get; set; }
                public int price_source_tariff { get; set; }
                public int currency_agent_id { get; set; }
                public int price_unitiki { get; set; }
                public int price_agent_fee { get; set; }
                public int price_agent { get; set; }
                public int price_agent_max { get; set; }
                public int card_identity_id { get; set; }
                public string card_identity_title { get; set; }
                public int citizenship_id { get; set; }
                public string citizenship_title { get; set; }
                public DatetimeReturn2 datetime_Return { get; set; }
                public DatetimeCancel2 datetime_cancel { get; set; }
                public string datetime_start { get; set; }
                public string datetime_end { get; set; }
                public string route_name { get; set; }
                public Distance distance { get; set; }
                public StationStart station_start { get; set; }
                public StationEnd station_end { get; set; }
                public Organization organization { get; set; }
                public Bus bus { get; set; }
                public UserId user_id { get; set; }
            }

            public class Operation
            {
                public string operation_id { get; set; }
                public string hash { get; set; }
                public string partner_id { get; set; }
                public string agent_id { get; set; }
                public int status { get; set; }
                public string datetime_order { get; set; }
                public DatetimeReturn datetime_Return { get; set; }
                public DatetimeCancel datetime_cancel { get; set; }
                public int time_left_to_cancel { get; set; }
                public List<TicketList> ticket_list { get; set; }
            }

            public class Data
            {
                public Operation operation { get; set; }
            }

            public class RootObject
            {
                public Data data { get; set; }
            }
        }

        public class TemporaryBook_name
        {

            public class StationStart
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class StationEnd
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class Organization
            {
                public string organization_id { get; set; }
                public string title_full { get; set; }
                public string title_small { get; set; }
                public string ogrn { get; set; }
                public string phone { get; set; }
            }

            public class TicketList
            {
                public int ticket_id { get; set; }
                public int operation_id { get; set; }
                public string operation_hash { get; set; }
                public int position { get; set; }
                public int status { get; set; }
                public object ticket_refund { get; set; }
                public string series_number { get; set; }
                public string name { get; set; }
                public string birthday { get; set; }
                public int gender { get; set; }
                public string phone { get; set; }
                public string email { get; set; }
                public int currency_source_id { get; set; }
                public int price_source_tariff { get; set; }
                public int currency_agent_id { get; set; }
                public int price_unitiki { get; set; }
                public int price_agent_fee { get; set; }
                public int price_agent { get; set; }
                public int price_agent_max { get; set; }
                public int card_identity_id { get; set; }
                public string card_identity_title { get; set; }
                public int citizenship_id { get; set; }
                public string citizenship_title { get; set; }
                public object datetime_buy { get; set; }
                public object datetime_cancel { get; set; }
                public string datetime_start { get; set; }
                public string datetime_end { get; set; }
                public string route_name { get; set; }
                public object distance { get; set; }
                public StationStart station_start { get; set; }
                public StationEnd station_end { get; set; }
                public Organization organization { get; set; }
                public object bus { get; set; }
                public object user_id { get; set; }
            }

            public class Operation
            {
                public string operation_id { get; set; }
                public string hash { get; set; }
                public string partner_id { get; set; }
                public string agent_id { get; set; }
                public int status { get; set; }
                public string datetime_order { get; set; }
                public object datetime_buy { get; set; }
                public object datetime_cancel { get; set; }
                public int time_left_to_cancel { get; set; }
                public List<TicketList> ticket_list { get; set; }
            }

            public class Data
            {
                public Operation operation { get; set; }
            }

            public class RootObject
            {
                public Data data { get; set; }
            }
        }
        public class CheckOperation
        {
            public class DatetimeBuy
            {
            }

            public class DatetimeCancel
            {
            }

            public class TicketRefund
            {
            }

            public class Phone
            {
            }

            public class DatetimeBuy2
            {
            }

            public class DatetimeCancel2
            {
            }

            public class Distance
            {
            }

            public class StationStart
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class StationEnd
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class Organization
            {
                public string organization_id { get; set; }
                public string title_full { get; set; }
                public string title_small { get; set; }
                public string ogrn { get; set; }
                public string phone { get; set; }
            }

            public class Bus
            {
            }

            public class UserId
            {
            }

            public class TicketList
            {
                public int ticket_id { get; set; }
                public int operation_id { get; set; }
                public string operation_hash { get; set; }
                public int position { get; set; }
                public int status { get; set; }
                public TicketRefund ticket_refund { get; set; }
                public string series_number { get; set; }
                public string name { get; set; }
                public string birthday { get; set; }
                public int gender { get; set; }
                public Phone phone { get; set; }
                public string email { get; set; }
                public int currency_source_id { get; set; }
                public int price_source_tariff { get; set; }
                public int currency_agent_id { get; set; }
                public int price_unitiki { get; set; }
                public int price_agent_fee { get; set; }
                public int price_agent { get; set; }
                public int price_agent_max { get; set; }
                public int card_identity_id { get; set; }
                public string card_identity_title { get; set; }
                public int citizenship_id { get; set; }
                public string citizenship_title { get; set; }
                public DatetimeBuy2 datetime_buy { get; set; }
                public DatetimeCancel2 datetime_cancel { get; set; }
                public string datetime_start { get; set; }
                public string datetime_end { get; set; }
                public string route_name { get; set; }
                public Distance distance { get; set; }
                public StationStart station_start { get; set; }
                public StationEnd station_end { get; set; }
                public Organization organization { get; set; }
                public Bus bus { get; set; }
                public UserId user_id { get; set; }
            }

            public class Operation
            {
                public string operation_id { get; set; }
                public string hash { get; set; }
                public string partner_id { get; set; }
                public string agent_id { get; set; }
                public int status { get; set; }
                public string datetime_order { get; set; }
                public DatetimeBuy datetime_buy { get; set; }
                public DatetimeCancel datetime_cancel { get; set; }
                public int time_left_to_cancel { get; set; }
                public List<TicketList> ticket_list { get; set; }
            }

            public class Data
            {
                public Operation operation { get; set; }
            }

            public class RootObject
            {
                public Data data { get; set; }
            }
        }
        public class CheckOperation_zapros
        {
            public class RootObject
            {
                public string operationId { get; set; }
            }
        }

        public class GetOperation
        {
            public class DatetimeBuy
            {
            }

            public class DatetimeCancel
            {
            }

            public class TicketRefund
            {
            }

            public class Phone
            {
            }

            public class DatetimeBuy2
            {
            }

            public class DatetimeCancel2
            {
            }

            public class Distance
            {
            }

            public class StationStart
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class StationEnd
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class Organization
            {
                public string organization_id { get; set; }
                public string title_full { get; set; }
                public string title_small { get; set; }
                public string ogrn { get; set; }
                public string phone { get; set; }
            }

            public class Bus
            {
            }

            public class UserId
            {
            }

            public class TicketList
            {
                public int ticket_id { get; set; }
                public int operation_id { get; set; }
                public string operation_hash { get; set; }
                public int position { get; set; }
                public int status { get; set; }
                public TicketRefund ticket_refund { get; set; }
                public string series_number { get; set; }
                public string name { get; set; }
                public string birthday { get; set; }
                public int gender { get; set; }
                public Phone phone { get; set; }
                public string email { get; set; }
                public int currency_source_id { get; set; }
                public int price_source_tariff { get; set; }
                public int currency_agent_id { get; set; }
                public int price_unitiki { get; set; }
                public int price_agent_fee { get; set; }
                public int price_agent { get; set; }
                public int price_agent_max { get; set; }
                public int card_identity_id { get; set; }
                public string card_identity_title { get; set; }
                public int citizenship_id { get; set; }
                public string citizenship_title { get; set; }
                public DatetimeBuy2 datetime_buy { get; set; }
                public DatetimeCancel2 datetime_cancel { get; set; }
                public string datetime_start { get; set; }
                public string datetime_end { get; set; }
                public string route_name { get; set; }
                public Distance distance { get; set; }
                public StationStart station_start { get; set; }
                public StationEnd station_end { get; set; }
                public Organization organization { get; set; }
                public Bus bus { get; set; }
                public UserId user_id { get; set; }
            }

            public class Operation
            {
                public string operation_id { get; set; }
                public string hash { get; set; }
                public string partner_id { get; set; }
                public string agent_id { get; set; }
                public int status { get; set; }
                public string datetime_order { get; set; }
                public DatetimeBuy datetime_buy { get; set; }
                public DatetimeCancel datetime_cancel { get; set; }
                public int time_left_to_cancel { get; set; }
                public List<TicketList> ticket_list { get; set; }
            }

            public class Data
            {
                public Operation operation { get; set; }
            }

            public class RootObject
            {
                public Data data { get; set; }
            }
        }
        public class BuyTicketZapros
        {

            public class RootObject
            {
                public string operationId { get; set; }
                public string ticketId { get; set; }
                public string ticketPrice { get; set; }
            }
        }
        public class BuyTicketOtvet
        {
            public class DatetimeBuy
            {
            }

            public class DatetimeCancel
            {
            }

            public class TicketRefund
            {
            }

            public class Phone
            {
            }

            public class DatetimeBuy2
            {
            }

            public class DatetimeCancel2
            {
            }

            public class Distance
            {
            }

            public class StationStart
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class StationEnd
            {
                public string station_id { get; set; }
                public string station_title { get; set; }
                public string city_id { get; set; }
                public string city_title { get; set; }
                public string region_title { get; set; }
                public string district_title { get; set; }
                public string country_id { get; set; }
                public string country_title { get; set; }
                public string country_iso { get; set; }
                public string lat { get; set; }
                public string lng { get; set; }
            }

            public class Organization
            {
                public string organization_id { get; set; }
                public string title_full { get; set; }
                public string title_small { get; set; }
                public string ogrn { get; set; }
                public string phone { get; set; }
            }

            public class Bus
            {
            }

            public class UserId
            {
            }

            public class TicketList
            {
                public int ticket_id { get; set; }
                public int operation_id { get; set; }
                public string operation_hash { get; set; }
                public int position { get; set; }
                public int status { get; set; }
                public TicketRefund ticket_refund { get; set; }
                public string series_number { get; set; }
                public string name { get; set; }
                public string birthday { get; set; }
                public int gender { get; set; }
                public Phone phone { get; set; }
                public string email { get; set; }
                public int currency_source_id { get; set; }
                public int price_source_tariff { get; set; }
                public int currency_agent_id { get; set; }
                public int price_unitiki { get; set; }
                public int price_agent_fee { get; set; }
                public int price_agent { get; set; }
                public int price_agent_max { get; set; }
                public int card_identity_id { get; set; }
                public string card_identity_title { get; set; }
                public int citizenship_id { get; set; }
                public string citizenship_title { get; set; }
                public DatetimeBuy2 datetime_buy { get; set; }
                public DatetimeCancel2 datetime_cancel { get; set; }
                public string datetime_start { get; set; }
                public string datetime_end { get; set; }
                public string route_name { get; set; }
                public Distance distance { get; set; }
                public StationStart station_start { get; set; }
                public StationEnd station_end { get; set; }
                public Organization organization { get; set; }
                public Bus bus { get; set; }
                public UserId user_id { get; set; }
            }

            public class Operation
            {
                public string operation_id { get; set; }
                public string hash { get; set; }
                public string partner_id { get; set; }
                public string agent_id { get; set; }
                public int status { get; set; }
                public string datetime_order { get; set; }
                public DatetimeBuy datetime_buy { get; set; }
                public DatetimeCancel datetime_cancel { get; set; }
                public int time_left_to_cancel { get; set; }
                public List<TicketList> ticket_list { get; set; }
            }

            public class Data
            {
                public Operation operation { get; set; }
            }

            public class RootObject
            {
                public Data data { get; set; }
            }
        }


    }
}
