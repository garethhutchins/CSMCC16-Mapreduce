using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMCC16
{
    class ReduceFlightDistance
    {
        public string outputpath;
        public string logwindow;
        public string FlightStart;
        public string FlightEnd;
        public string FlightPassengers;
        private Dictionary<string, double> FlightDistance = new Dictionary<string, double>();
        public void Reduce()
        {
            //Now reduce the Flight Distance Calculation
            //Create a Dictionary for each flight and start and end lat long
            Dictionary<string, Tuple<double, double>> FlightOri = new Dictionary<string, Tuple<double, double>>();
            Dictionary<string, Tuple<double, double>> FlightDest = new Dictionary<string, Tuple<double, double>>();
            //Load the Flight Start
            using (StreamReader reader = new StreamReader(FlightStart))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    //Check to see if the key is already there
                    if (!FlightOri.ContainsKey(Components[0]))
                    {
                        //Add the lat and long for the start airport
                        FlightOri.Add(Components[0], Tuple.Create(Convert.ToDouble(Components[1]), Convert.ToDouble(Components[2])));
                    }
                }
            }
            //Load the Flight End
            using (StreamReader reader = new StreamReader(FlightEnd))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    //Check to see if the key is already there
                    if (!FlightDest.ContainsKey(Components[0]))
                    {
                        //Add the lat and long for the start airport
                        FlightDest.Add(Components[0], Tuple.Create(Convert.ToDouble(Components[1]), Convert.ToDouble(Components[2])));
                    }
                }
            }
            //Now go through each entry in the start to set the disance keys and calculate Distance
            foreach (var apt in FlightOri)
            {
                //Get the Lat Long Start
                Tuple<double, double> S = apt.Value;
                //Now get the end
                Tuple<double, double> E = FlightDest[apt.Key];
                //Calculate the Distance
                double Dist = Distance(S, E);
                //Add the key, we know these will be unique from last step
                FlightDistance.Add(apt.Key, Dist);
            }
        }
        private double ToRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th of a degree
            return (angleIn10thofaDegree * Math.PI) / 1800;
        }
        private double Distance(Tuple<double, double> Origin, Tuple<double, double> Destination)
        {
            //Tuple 1 latitude Tuple 2 long
            //Get latitude radians
            var lat = ToRadians((Destination.Item1 - Origin.Item1));
            //long
            var lng = ToRadians((Destination.Item2 - Origin.Item2));
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
              Math.Cos(ToRadians(Origin.Item1)) * Math.Cos(ToRadians(Destination.Item1)) *
              Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            //Times by miles
            return 3960 * h2;
        }
    }

}

