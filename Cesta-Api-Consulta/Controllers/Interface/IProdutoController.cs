using System;
using System.Collections;
using System.Collections.Generic;
using Cesta_Api_Consulta.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cesta_Api_Consulta.Controllers.Interface
{
    public interface IProdutoController
    {
        public IEnumerable<Produto> ProcurarProdutoPorPreco(double preco,Localizacao loc,int distancia);

        public IEnumerable<Produto> ProcurarProdutoPorDistancia(Localizacao loc,int distancia);

    }
}