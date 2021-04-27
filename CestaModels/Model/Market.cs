using System;

namespace CestaModels
{
    public class Market
    {
        public int id { get; set; }

        public string name { get; set; }
        
        public double latitude { get; set; }

        public double longitude { get; set; }

        public DateTime openingHour { get; set; }
        
        public DateTime closingHour { get; set; }
        
        public string description { get; set; }

    }
}