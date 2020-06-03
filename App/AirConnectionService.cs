using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace App
{
    public class AirConnectionService
    {
        public void AddNewAirConnection (AirConnection airConnection)
        {
            using (var context = new SkySkannerContext())
            {
                context.AirConnections.Add(airConnection);
                context.SaveChanges();
            }
        }
        public AirConnection GetAirConnectionById(int id)
        {
            AirConnection airConnection;
            using (var context = new SkySkannerContext())
            {
                airConnection = context.AirConnections.FirstOrDefault(x => x.Id == id);
            }
            return airConnection;
        }
        public List<AirConnection> GetListOfExsistingAirConnections()
        {
            List<AirConnection> listOfAirConnections;
            using (var context = new SkySkannerContext())
            {
                listOfAirConnections = context.AirConnections.ToList();
            }
            return listOfAirConnections;
        }
        public void DeleteAirConnectionById(int id)
        {
            using (var context = new SkySkannerContext())
            {
                //Podawane jest po Id, a nie jako obiekt, bo jest to robione w osobnym połączeniu (usingu)
                //i DB może się po drodze zmienić.
                var airConnection = context.AirConnections.First((x => x.Id == id));
                context.AirConnections.Remove(airConnection);
                context.SaveChanges();
            }
        }
    }
}
