using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace SkySkanner
{
    public class AirportCommunicator
    {
        readonly Communicator communicator = new Communicator();
        public Airport GetAirportDataFromUser()
        {
            var airport = new Airport
            {
                Name = communicator.AskUserForString("NAZWA LOTNISKA"),
                Longitude = GetAirportLongitude(),
                Latitude = GetAirportLatitude()
            };
            return airport;
        }
        public double GetAirportLatitude()
        {
            string airportLatitudeSide = null;
            bool isLatSideCorrect = false;
            while (isLatSideCorrect == false)
            {
                airportLatitudeSide = communicator.AskUserForString(
                            "KIERUNEK SZEROKOŚCI GEOGRAFICZNEJ LOTNISKA " +
                            "(wpisz N dla północnej lub S dla południowej)");

                if (airportLatitudeSide == "N" || airportLatitudeSide == "S")
                { isLatSideCorrect = true; }

                else { communicator.PrintWrongInputMessage(); }
            }
            var airportLatitude = communicator.AskUserForDouble("SZEROKOŚĆ GEOGRAFICZNA LOTNISKA");
            if (airportLatitudeSide == "S")
            { airportLatitude *= -1; }

            return airportLatitude;
        }
        public double GetAirportLongitude()
        {
            string airportLongitudeSide = null;
            bool isLongSideCorrect = false;
            while (isLongSideCorrect == false)
            {
                airportLongitudeSide = communicator.AskUserForString(
                         "KIERUNEK DŁUGOŚCI GEOGRAFICZNEJ LOTNISKA " +
                         "(wpisz E dla wschodniej lub W dla zachodniej)");

                if (airportLongitudeSide == "E" || airportLongitudeSide == "W")
                { isLongSideCorrect = true; }

                else { communicator.PrintWrongInputMessage(); }
            }

            var airportLongitude = communicator.AskUserForDouble("DŁUGOŚĆ GEOGRAFICZNA LOTNISKA");
            if (airportLongitudeSide == "E")
            { airportLongitude *= -1; }

            return airportLongitude;
        }
    }
}
