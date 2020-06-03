using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace App
{
    public class AirConnectionFinder
    {
        readonly AirConnectionService airConnectionService = new AirConnectionService();
        public List<AirConnection> GetListOfMatchingConnections(Airport departureAirport, Airport arrivalAirport)
        {
            var listOfMatchingConnections = new List<AirConnection>();
            var listOfExistingAirConnections = airConnectionService.GetListOfExsistingAirConnections();
            foreach (AirConnection airConnection in listOfExistingAirConnections)
            {
                if (airConnection.ListOfAirports.Exists(x => x.Name == departureAirport.Name) &&
                    airConnection.ListOfAirports.Exists(x => x.Name == arrivalAirport.Name) &&
                    airConnection.ListOfAirports.IndexOf(departureAirport) < airConnection.ListOfAirports.IndexOf(arrivalAirport)) //no nie wiem, czy to zadziała, bo podaję do porównania inną (ale identyczną) instancję obiektu Airport, a LAMBDA TU NIE ZADZIAŁA
                {
                    listOfMatchingConnections.Add(airConnection);
                    //dodaje połączenie do listy pasujących połączeń, gdy posiada ono departureA. i arrivalA ORAZ arrivalA jest dalszą pozycją na liście, niż departureA
                }
            }
            return listOfMatchingConnections;
        }
        public int GetFastestAirConnectionId(List<AirConnection> listOfMatchingConnections)
        {
            int fastestConnectionId = 0;
            //TBD
            return fastestConnectionId;
        }
    }
}
