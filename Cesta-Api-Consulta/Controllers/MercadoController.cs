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
        public IEnumerable<Mercado> ListarMercadosProximos(float latitude,float longitude)
        {
            return service.ListarMercadosProximos(new Localizacao{latitude = latitude,longitude = longitude}, 10);
        }

        [HttpGet]
        public Mercado GetMercado(int id)
        {
            return service.GetMercado(id);
        }
        [HttpPost]
        public void CreateMercado(Mercado m)
        {
            service.CreateMercado(m);
        }
        
    }
}