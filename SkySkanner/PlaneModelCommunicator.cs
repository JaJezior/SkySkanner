using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Domain;

namespace SkySkanner
{
    public class PlaneModelCommunicator
    {
        Communicator communicator = new Communicator();
        public PlaneModel GetPlaneModelData()
        {
            PlaneModel planeModel = new PlaneModel();
            planeModel.Name = communicator.AskUserForString("MODEL SAMOLOTU");
            planeModel.AvgSpeed = communicator.AskUserForDouble("ŚREDNIA PRĘDKOŚĆ REJSOWA (w km/h)");
            planeModel.AvgFuelConsumption = communicator.AskUserForDouble("ŚREDNIE ZUŻYCIE PALIWA (w T/h)");
            planeModel.PassengerCapacity = communicator.AskUserForInt("LICZBA MIEJSC DLA PASAŻERÓW");
            
            return planeModel;
        }
    }
}
