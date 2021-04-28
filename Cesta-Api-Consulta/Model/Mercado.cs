using System;

namespace Cesta_Api_Consulta.Model
{
    public class Mercado
    {
        public string nome { get; set; }
        
        public double latitudeMercado { get; set; }
        
        public double longitudeMercado { get; set; }
        
        public DateTime horaAbertura { get; set; }

        public DateTime horaFechamento { get; set; }
        
        public string descricao { get; set; }
    }
}