using System;
using System.Collections.Generic;
using Cesta_Api_Consulta.Model;

namespace Cesta_Api_Consulta.Service.Interface
{
    public interface IMercadoService
    {
        public IEnumerable<Mercado> ListarMercadosProximos(Localizacao loc,int distancia);

    }
}