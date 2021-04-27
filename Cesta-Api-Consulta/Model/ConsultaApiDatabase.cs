using Cesta_Api_Consulta.Model;
using CestaModels;
using CestaModels.Model;
using Microsoft.EntityFrameworkCore;
namespace Cesta_Api_Consulta.Model

{
    public class ConsultaApiDatabase : DbContext
    {
        public ConsultaApiDatabase(DbContextOptions options) : base(options){}

        public DbSet<Market> Mercado { get; set; }
        
        public DbSet<Product> Produto { get; set; }
    }
}