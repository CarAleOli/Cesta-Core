using System.Collections;
using System.Collections.Generic;
using Cesta_Api.Model;
using Cesta_Api_Core.Controllers.Interface;
using Cesta_Api_Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cesta_Api_Core.Controllers
{
    [ApiController,Route("/Produto")]
    public class ProdutoController : Controller , IProdutoController
    {
        [HttpGet, Route("Mercados")]
        public IEnumerable<Mercado> ProcurarMercadosComProduto()
        {
            return ProdutoService.ProcurarMercadosComProduto();
        }

    }
}