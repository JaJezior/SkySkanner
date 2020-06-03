using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App;
using Domain;

namespace SkySkanner
{
    public class AirConnectionCommunicator
    {
        Communicator communicator = new Communicator();
        PlaneModelService planeModelService = new PlaneModelService();
        AirportService airportService = new AirportService();
        AirConnectionService airConnectionService = new AirConnectionService();

        //---------------------------
        //----------C R U D----------
        //---------------------------

        public void CreateAirConnection()
        {
            AirConnection airConnection = new AirConnection
            {
                PlaneModel = GetPlaneModelForAirConnection(new PlaneModel()),
                ListOfAirports = GetListOfAirportsForAirConnection()
            };

            airConnectionService.AddNewAirConnection(airConnection);
        }
        public AirConnection GetAirConnection()
        {
            PrintListOfExistingAirConnections();
            AirConnection airConnection = null;
            while (airConnection == null)
            {
                int choosenId = communicator.AskUserForInt("Id połączenia, które chcesz modyfikować");
                airConnection = airConnectionService.GetAirConnectionById(choosenId);
                if (airConnection == null)
                {
                    communicator.PrintWrongInputMessage();
                }
            }
            return airConnection;
        }
        public AirConnection UpdateAirConnection()
        {
            AirConnection editedAirConnection = GetAirConnection();

            editedAirConnection.PlaneModel = GetPlaneModelForAirConnection(editedAirConnection.PlaneModel);
            //TBD dopisać edytowanie poszczególnych lotnisk
            return editedAirConnection;
        }
        public void DeleteAirConnection()
        {
            var airConnection = GetAirConnection();
            airConnectionService.DeleteAirConnectionById(airConnection.Id);
        }

        //---------------------------
        //----------PRIVATE----------
        //---------------------------
        private void PrintListOfExistingAirConnections()
        {
            List<AirConnection> airConnectionList = airConnectionService.GetListOfExsistingAirConnections();

            Console.WriteLine("Lista ID istniejących połączeń lotniczych:");
            foreach (AirConnection airConnection in airConnectionList)
            {
                Console.WriteLine($"Id: {airConnection.Id}, lotniska na trasie:");
                foreach (Airport airport in airConnection.ListOfAirports)
                {
                    Console.WriteLine(airport.Name);
                }
            }
        }

        private List<Airport> GetListOfAirportsForAirConnection()
        {
            var listOfAirports = new List<Airport>();
            while(true)
            {
                Console.WriteLine($"Liczba lotnisk na trasie przelotu wynosi {listOfAirports.Count()}");
                AddSingleAirportToList(listOfAirports);
                Console.WriteLine("Czy chcesz kontynuować dodawanie lotnisk do trasy przelotu? [Y/N]");
                string finishThisListSwitch = Console.ReadLine();
                if (finishThisListSwitch == "N")
                {
                    Console.WriteLine("Trasa przelotu przebiega przez:");
                    foreach(Airport airport in listOfAirports)
                    {
                        Console.WriteLine($"Lotnisko {airport.Name}");
                    }
                    break;
                }
            }
            return listOfAirports;
        }

        private void AddSingleAirportToList(List<Airport> listOfAirports)
        {
            bool isAirportCorrect = false;
            while (isAirportCorrect == false)
            {
                var airport = airportService.GetAirportByName
                    (
                    communicator.AskUserForString("NAZWA LOTNISKA")
                    );
                if (airport != null)
                {
                    isAirportCorrect = true;
                    listOfAirports.Add(airport);
                    Console.WriteLine($"Dodano lotnisko {airport.Name} do trasy przelotu");
                }
                else
                {
                    communicator.PrintWrongInputMessage();
                }
            }
        }

        private PlaneModel GetPlaneModelForAirConnection(PlaneModel planeModel)
        {
            while (true)
            {
                var userInput = communicator.AskUserForString(
                                    $"model samolotu, który ma obsługiwać to połączenie (obecnie {planeModel.Name})");

                if (userInput == "") break;

                planeModel = planeModelService.GetPlaneModelByName(userInput);

                if (planeModel == null) communicator.PrintWrongInputMessage();

                if (planeModel != null) break;
            }
            return planeModel;
        }
    }
}
