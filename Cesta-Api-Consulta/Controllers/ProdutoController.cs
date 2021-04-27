using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Cesta_Api_Consulta.Controllers.Interface;
using Cesta_Api_Consulta.Model;
using Cesta_Api_Consulta.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cesta_Api_Consulta.Controllers
{
    [ApiController, Route("/Produto")]
    public class ProdutoController : Controller, IProdutoController
    {
        public ProdutoService service;
        public ProdutoController(ProdutoService ps)
        {
            service = ps;
        }
        [HttpGet,Route("Preco")] 
        public IEnumerable<Produto> ProcurarProdutoPorPreco(double preco,Localizacao loc,int distancia)
        {
            return service.ProcurarProdutoPorPreco(preco,loc,distancia);
        }
        [HttpGet,Route("Distancia")]
        public IEnumerable<Produto> ProcurarProdutoPorDistancia(Localizacao loc,int distancia)
        {
            return service.ProcurarProdutoPorDistancia(loc,distancia);
        }
    }
}