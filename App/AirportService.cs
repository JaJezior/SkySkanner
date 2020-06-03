using System;
using System.Linq;
using Domain;

namespace App
{
    public class AirportService
    {
        public void AddNewAirport(Airport airport)
        {
            using (var context = new SkySkannerContext())
            {
                context.Airports.Add(airport);
                context.SaveChanges();
            }
        }
        public Airport GetAirportByName(string airportName)
        {
            var airport = new Airport();
            using (var context = new SkySkannerContext())
            {
                airport = context.Airports.FirstOrDefault(x => x.Name == airportName);
            }
            return airport; //może dać nulla!
        }

    } 
}
