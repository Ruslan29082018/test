using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tests2.Api.Reverence.Get
{
        [AttributeUsage("используем атрибут")]
    public class ReferenceAirportsAllParametr : Attribute
    {
        public string iataCode { get; set; }
        public string name { get; set; }
    }
    public class ReferenceAirportsNearest
    {
        public string iataCode { get; set; }
        public string name { get; set; }
        public string distance { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string countryCode { get; set; }
    }
    public class ReferenceAirlinesAll
    {
        public string code { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
    }
    public class ReferenceAirlinesFind
    {
        public string code { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
    }
    public class ReferenceMealsAll
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    public class ReferenceCitiesAll
    {
        public int id { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
    }
    public class ReferenceCountriesAll
    {
        public string code { get; set; }
        public string name { get; set; }
    }
}