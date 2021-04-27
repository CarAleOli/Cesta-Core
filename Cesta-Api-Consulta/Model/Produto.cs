namespace Cesta_Api_Consulta.Model
{
    public class Produto
    {
        public string nome { get; set; }

        public string valor { get; set; }

        public Mercado mercado_associado { get; set; }

        public string descricao { get; set; }
    }
}