namespace CestaModels.Model
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public string price { get; set; }

        public Market market { get; set; }

        public string description { get; set; }
    }
}