using System;
using System.Collections.Generic;
using Cesta_Api_Consulta.Model;
using Cesta_Api_Consulta.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cesta_Api_Consulta.Controllers
{
    [ApiController,Route("Mercado")]
    public class MercadoController : Controller
    {
        public MercadoService service;

        public MercadoController(MercadoService ms)
        {
            service = ms;
        }
        
        [HttpGet,Route("Listar")]
        public IEnumerable<Mercado> ListarMercadosProximos(Localizacao loc,int distancia)
        {
            return service.ListarMercadosProximos(loc, distancia);
        }

        /*[HttpPost]
        public Mercado CreateMercado(Mercado m)
        {
            return service.CreateMercado(m);
        }*/

    }
}