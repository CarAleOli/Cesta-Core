using System;
using System.Collections.Generic;
using System.Linq;
using Cesta_Api_Consulta.Model;
using Cesta_Api_Consulta.Service.Interface;
using CestaModels;
using CestaModels.Model;
using Geolocation;
using Microsoft.EntityFrameworkCore;

namespace Cesta_Api_Consulta.Service
{
    public class ProdutoService : IProdutoService
    {
        public ConsultaApiDatabase Database;

        public  ProdutoService(ConsultaApiDatabase database)
        {
            Database = database;
        }
        

        public  IEnumerable<Produto> ProcurarProdutoPorPreco(double preco,Localizacao loc,int distancia)
        {
            //GeoCalculator.GetDistance(user, market, 1, DistanceUnit.Kilometers);
            return Database.Produto.Where(product =>
                GeoCalculator.GetDistance(
        new Coordinate(loc.latitude, loc.longitude),
        new Coordinate(product.market.latitude, product.market.longitude),
                1, DistanceUnit.Kilometers) <= distancia).Select(product => new Produto
                            {
                                nome = product.name,
                                descricao = product.description,
                                mercado_associado = new Mercado
                                {
                                    nome = product.market.name,
                                    descricao = product.market.description,
                                    horaAbertura = product.market.openingHour,
                                    horaFechamento = product.market.closingHour
                                },
                                valor = product.price

                            }).OrderBy(produto =>produto.valor);
    }

        public IEnumerable<Produto> ProcurarProdutoPorDistancia(Localizacao loc, int distancia)
        {
            return Database.Produto.Where(product =>
                GeoCalculator.GetDistance(
                    new Coordinate(loc.latitude, loc.longitude),
                    new Coordinate(product.market.latitude, product.market.longitude),
                    1, DistanceUnit.Kilometers) <= distancia).Select(product => new Produto
            {
                nome = product.name,
                descricao = product.description,
                mercado_associado = new Mercado
                {
                    nome = product.market.name,
                    descricao = product.market.description,
                    horaAbertura = product.market.openingHour,
                    horaFechamento = product.market.closingHour
                },
                valor = product.price
            });
        }
    }
}       