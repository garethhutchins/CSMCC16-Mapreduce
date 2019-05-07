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
        private string ErrorText = "";
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
            //Garbage Collect
            FlightOri = null;
            FlightDest = null;
            //Now sort the flights by Distance Descending
            var SortedDic = FlightDistance.OrderByDescending(d => d.Value).ToList();
            GC.Collect();
           //Now add the flight distances to file
           //Check the directory exists
           if (!Directory.Exists(outputpath + @"\Reducers"))
            {
                Directory.CreateDirectory(outputpath + @"\Reducers");
            }
           //See if the File Exists
           if (File.Exists(outputpath + @"\Reducers\FlightDistance.csv"))
            {
                //Try to delete it
                try
                {
                    File.Delete(outputpath + @"\Reducers\FlightDistance.csv");
                }
                catch (IOException) {
                    logwindow = Environment.NewLine + "Unable to Delete FlightDistance.csv";
                    return;
                }
                catch (UnauthorizedAccessException)
                {
                    logwindow = Environment.NewLine + "Unable to Delete FlightDistance.csv";
                    return;
                }
            }
            //Now save the contents to file
            //And the Results form
            DistanceResults DR = new DistanceResults();
            using (StreamWriter Writer = new StreamWriter(outputpath + @"\Reducers\FlightDistance.csv"))
            {
                foreach (var Flight in SortedDic)
                {
                    Writer.WriteLine("{0},{1}", Flight.Key, Flight.Value);
                    DR.FlightsChart.Series[0].Points.AddXY(Flight.Key, Flight.Value);
                    DR.FlightsTable.Rows.Add(Flight.Key, Flight.Value);
                }
            }
            //Now Calculate the Passenger that's travelled the greatest distance
            Dictionary<string, double> PassengerDistance = new Dictionary<string, double>();
            //Load the file
            using (StreamReader Reader = new StreamReader(FlightPassengers))
            {
                string line;
                double Distance = 0;
                while ((line = Reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    //Get the Distance from the flight
                    if (FlightDistance.ContainsKey(Components[1]))
                    {
                        //Get the Distance
                        Distance = FlightDistance[Components[1]];
                    }
                    else
                    {
                        //Log the Error
                        ErrorText = ErrorText + "Unable to Find Flight " + Components[0] + System.Environment.NewLine;
                    }
                    //Check to see if the key is already there
                    if (!PassengerDistance.ContainsKey(Components[0]))
                    {
                        //Add the passenger and Distance
                        PassengerDistance.Add(Components[0], Distance);
                    }
                    else
                    {
                        //Get the old value and add the new value
                        double OldDistance = PassengerDistance[Components[0]];
                        Distance = Distance + OldDistance;
                        PassengerDistance[Components[0]] = Distance;
                    }
                }
            }
            //Do Garbage Collection on the Flight Distance
            FlightDistance = null;
            GC.Collect();
            //Sort the Passenger Distance
            var SortedPassengers = PassengerDistance.OrderByDescending(d => d.Value).ToList();
            //Now save the results to file
            //See if the File Exists
            if (File.Exists(outputpath + @"\Reducers\PassengerDistance.csv"))
            {
                //Try to delete it
                try
                {
                    File.Delete(outputpath + @"\Reducers\PassengerDistance.csv");
                }
                catch (IOException)
                {
                    logwindow = Environment.NewLine + "Unable to Delete PassengerDistance.csv";
                    return;
                }
                catch (UnauthorizedAccessException)
                {
                    logwindow = Environment.NewLine + "Unable to Delete PassengerDistance.csv";
                    return;
                }
            }
            //Now save the contents to file
            using (StreamWriter Writer = new StreamWriter(outputpath + @"\Reducers\PassengerDistance.csv"))
            {
                foreach (var Passenger in SortedPassengers)
                {
                    Writer.WriteLine("{0},{1}", Passenger.Key, Passenger.Value);
                    DR.PassengerChart.Series[0].Points.AddXY(Passenger.Key, Passenger.Value);
                    DR.PassengerTable.Rows.Add(Passenger.Key, Passenger.Value);
                }
            }

            
            //Write the Error Text
            if (File.Exists(outputpath + @"\PassengerDistanceErrors.txt"))
            {
                //Try to delete it
                try
                {
                    File.Delete(outputpath + @"\PassengerDistanceErrors.txt");
                }
                catch (IOException)
                {
                    logwindow = Environment.NewLine + "Unable to Delete PassengerDistanceErrors.txt";
                    return;
                }
                catch (UnauthorizedAccessException)
                {
                    logwindow = Environment.NewLine + "Unable to Delete PassengerDistanceErrors.txt";
                    return;
                }
            }
            //Now save the contents to file
            using (StreamWriter Writer = new StreamWriter(outputpath + @"\PassengerDistanceErrors.txt"))
            {
                Writer.Write(ErrorText);
            }

            //Set the Axis of the charts
            DR.FlightsChart.ChartAreas[0].AxisX.Interval = 1;
            DR.PassengerChart.ChartAreas[0].AxisX.Interval = 1;
            //Show the Results Form
            DR.ShowDialog();
            //Do Garbage Collection
            SortedDic = null;
            SortedPassengers = null;
            GC.Collect();
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

