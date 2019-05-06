using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMCC16
{
    class ReduceFlightInformation
    {
        
        public string FlightPassengerFile = "";
        public string FlightDepArptFile = "";
        public string FlightDestFile = "";
        public string FlightDepTimeFile = "";
        public string FlightTimeFile = "";
        public void Reduce()
        {
            //Flight Passenger is the master record that will be read last
            //Load the Departure Times
            Dictionary<string, DateTime> DepTime = new Dictionary<string, DateTime>();
            //Flight Times
            Dictionary<string, DateTime> FlightTime = new Dictionary<string, DateTime>();

            //Arrival Time
            Dictionary<string, DateTime> ArrTime = new Dictionary<string, DateTime>();

            //Departure Airport
            Dictionary<string, DateTime> DepApt = new Dictionary<string, DateTime>();

            //Arrival Airport
            Dictionary<string, DateTime> ArvApt = new Dictionary<string, DateTime>();

            //Now to a Tuple for each Flight Record
            List <Tuple<string, string, string, string, DateTime, DateTime, DateTime>> Flights = new List<Tuple<string, string, string, string, DateTime, DateTime, DateTime>>();


        }
    }
}
