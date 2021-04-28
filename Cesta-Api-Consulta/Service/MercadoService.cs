using System;
using System.Collections.Generic;
using System.Linq;
using Cesta_Api_Consulta.Model;
using CestaModels;
using Geolocation;
using Microsoft.EntityFrameworkCore;

namespace Cesta_Api_Consulta.Service
{
    public class MercadoService 
    {
        public ConsultaApiDatabase Database;

        public MercadoService(ConsultaApiDatabase db)
        {
            Database = db;
        }

        public IEnumerable<Mercado> ListarMercadosProximos(Localizacao loc, int distancia)
        {
            return Database.Mercado.ToArray().Where(market => GeoCalculator.GetDistance(
                new Coordinate(loc.latitude, loc.longitude),
                new Coordinate(market.latitude, market.longitude),
                4, DistanceUnit.Kilometers) <= distancia).Select(market => new Mercado
                {
                    nome = market.name,
                    latitudeMercado = market.latitude,
                    longitudeMercado = market.longitude,
                    horaAbertura = market.openingHour,
                    horaFechamento = market.closingHour,
                    descricao = market.description
                });
        }
        
        public void CreateMercado(Mercado mercado)
        {
            Market m = new Market()
            {
                
                description = mercado.descricao,
                latitude = mercado.latitudeMercado,
                longitude = mercado.longitudeMercado,
                name = mercado.nome,
                closingHour = mercado.horaFechamento,
                openingHour = mercado.horaAbertura
            };
            Database.Mercado.Add(m);
            Database.SaveChanges();
        }

        public Mercado GetMercado(int id)
        {
            Market m = Database.Mercado.FirstOrDefault(x => x.id == id);
            
            return new Mercado
            {
                descricao = m.description,
                nome = m.name,
                horaAbertura = m.openingHour,
                horaFechamento = m.closingHour,
                latitudeMercado = m.latitude,
                longitudeMercado = m.longitude
            } ;
        }
    }
}