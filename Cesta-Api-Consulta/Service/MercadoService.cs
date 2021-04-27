using System;
using System.Collections.Generic;
using System.Linq;
using Cesta_Api_Consulta.Model;
using Cesta_Api_Consulta.Service.Interface;
using Geolocation;
using Microsoft.EntityFrameworkCore;

namespace Cesta_Api_Consulta.Service
{
    public class MercadoService : IMercadoService
    {
        public ConsultaApiDatabase Database;

        public MercadoService(ConsultaApiDatabase db)
        {
            Database = db;
        }

        public IEnumerable<Mercado> ListarMercadosProximos(Localizacao loc, int distancia)
        {
            return Database.Mercado.Where(market => GeoCalculator.GetDistance(
                new Coordinate(loc.latitude, loc.longitude),
                new Coordinate(market.latitude, market.longitude),
                1, DistanceUnit.Kilometers) <= distancia).Select(market => new Mercado
                {
                    nome = market.name,
                    latitudeMercado = market.latitude,
                    longitudeMercado = market.longitude,
                    horaAbertura = market.openingHour,
                    horaFechamento = market.closingHour,
                    descricao = market.description
                });
        }
        /*
        public Mercado CreateMercado(Mercado mercado)
        {
            ;
        }*/
    }
}