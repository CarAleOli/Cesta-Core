using System.Collections;
using System.Collections.Generic;
using Cesta_Api_Consulta.Model;

namespace Cesta_Api_Consulta.Controllers.Interface
{
    public interface IMercadoController
    {
        public IEnumerable<Mercado> ListarMercadosProximos(Localizacao loc,int distancia);
        
        
    }
}