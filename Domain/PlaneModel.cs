using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PlaneModel
    {
        public string Name { get; set; }
        public double AvgSpeed { get; set; }
        public double AvgFuelConsumption { get; set; }
        public int PassengerCapacity { get; set; }
    }
}
