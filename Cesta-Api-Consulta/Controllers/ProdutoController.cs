using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Cesta_Api_Consulta.Model;
using Cesta_Api_Consulta.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cesta_Api_Consulta.Controllers
{
    [ApiController, Route("/Produto")]
    public class ProdutoController : Controller
    {
        public ProdutoService service;
        public ProdutoController(ProdutoService ps)
        {
            service = ps;
        }
        [HttpGet,Route("Preco")] 
        public IEnumerable<Produto> ProcurarProdutoPorPreco(float latitude,float longitude)
        {
            return service.ProcurarProdutoPorPreco(new Localizacao{latitude = latitude,longitude = longitude});
        }
        [HttpGet,Route("Distancia")]
        public IEnumerable<Produto> ProcurarProdutoPorDistancia(float latitude,float longitude)
        {
            return service.ProcurarProdutoPorDistancia(new Localizacao{latitude=latitude,longitude=longitude},10);
        }

        [HttpGet, Route("get")]
        public Produto GetProduto(int id)
        {
            return service.GetProduto(id);
        }

        [HttpPost, Route("Set")]
        public void SetProduto(Produto p)
        {
            service.createProduto(p);
        }
    }
}