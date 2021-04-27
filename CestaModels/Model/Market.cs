namespace Cesta_Api_Core.Model
{
    public class Market
    {
        public int id { get; set; }

        public string name { get; set; }
        
        public string latitude { get; set; }

        public string longitude { get; set; }
        
        #warning  eu nao sei se precisamos disso, preciso fazer um review pra ter ctz
        public string cnpj { get; set; }
    }
}