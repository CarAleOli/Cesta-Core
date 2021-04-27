using System;
using System.Collections.Generic;
using Cesta_Api_Consulta.Model;
using Microsoft.EntityFrameworkCore;

namespace Cesta_Api_Consulta.Service.Interface
{
    public interface IProdutoService
    {
        public IEnumerable<Produto> ProcurarProdutoPorPreco(double preco,Localizacao loc,int distancia);

        public IEnumerable<Produto> ProcurarProdutoPorDistancia(Localizacao loc,int distancia);
        
    }
}