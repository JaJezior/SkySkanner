using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AirConnection
    {
        public int Id { get; set; }
        public PlaneModel PlaneModel { get; set; }
        public List<Airport> ListOfAirports { get; set; }
    }
}
