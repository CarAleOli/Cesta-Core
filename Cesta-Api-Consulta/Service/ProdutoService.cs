using System;
using System.Collections.Generic;
using System.Linq;
using Cesta_Api_Consulta.Model;
using CestaModels;
using CestaModels.Model;
using Geolocation;
using Microsoft.EntityFrameworkCore;

namespace Cesta_Api_Consulta.Service
{
    public class ProdutoService 
    {
        public ConsultaApiDatabase Database;
        public MercadoService mercadoService;
        public  ProdutoService(ConsultaApiDatabase database,MercadoService ms)
        {
            Database = database;
            mercadoService = ms;
        }
        

        public  IEnumerable<Produto> ProcurarProdutoPorPreco(Localizacao loc)
        {
            return Database.Produto.ToArray().Where(product =>
                product.market!=null && 
                GeoCalculator.GetDistance(
        new Coordinate(loc.latitude, loc.longitude),
        new Coordinate(product.market.latitude, product.market.longitude),
                1, DistanceUnit.Kilometers) <= 10).Select(product => new Produto
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
            return Database.Produto.ToArray().Select(product => new Produto
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

        public Produto GetProduto(int id)
        {
            var product = Database.Produto.FirstOrDefault(product => product.id == id);
            return new Produto
            {
                descricao = product.description,
                nome = product.name,
                mercado_associado = new Mercado
                {
                    nome = product.market.name,
                    descricao = product.market.description,
                    horaAbertura = product.market.openingHour,
                    horaFechamento = product.market.closingHour
                },
                valor = product.price
            };

        }
        
        public Product createProduto(Produto p)
        {
            var market = 
            Database.Produto.Add(new Product
            {
                description = p.descricao,
                market =new Market
                {
                    name = p.mercado_associado.nome ,
                    description = p.mercado_associado.descricao,
                    openingHour = p.mercado_associado.horaAbertura,
                    closingHour = p.mercado_associado.horaFechamento,
                    latitude= p.mercado_associado.latitudeMercado,
                    longitude = p.mercado_associado.longitudeMercado
                },
                name = p.nome,
                price = p.valor
                
            });
            Database.SaveChanges();
            return market;
        }
    }
}       