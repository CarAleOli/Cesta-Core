namespace Cesta_Api.Model
{
    public class Produto
    {
        public int id_produto { get; set; }

        public string nome { get; set; }

        public string valor { get; set; }

        public Mercado mercado_associado { get; set; }

        public string descricao { get; set; }
    }
}