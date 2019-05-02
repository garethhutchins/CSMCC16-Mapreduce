using CSMCC16;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SortFunctions
{
    public string outputpath;
    public string FlightsAirportFile = "";
    public string FlightsPassengersFile = "";
    public string LogWindow = "";
    public string FlightStartLocFile = "";
    public string FlightEndLocFile = "";
    //See what the sort type is
    public void Sort(string SortType, string[] MapOutput)
    {
        switch (SortType) {
            case "FlightsAirport":
                //Calculate the Number of Flights from each airport
                FlightsAirport(MapOutput);
                break;
            case "FlightPassengers":
                //Calculate the number of Passengers on each flight
                FlightsPassengers(MapOutput);
                break;
            case "FlightDistance":
                //Calculate the Flight Distance and total for passengers
                FlightsDistance(MapOutput);
                break;

        }
    }
    private void FlightsDistance(string[] MapOutput)
    {
        string ErrorFile = outputpath + @"\FlightsDistanceErrorFile.txt";
        //Load lat and longs into memory we know buffer is ok from previous step
        Dictionary<string, double> AptLat = new Dictionary<string, double>();
        Dictionary<string, double> AptLon = new Dictionary<string, double>();
        //Start by populating the Latitude Dictionary
        using (StreamReader reader = new StreamReader(MapOutput[0]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                AptLat.Add(Components[0], Convert.ToDouble(Components[1]));
            }
        }

        //Now the Longitude Dictionary
        using (StreamReader reader = new StreamReader(MapOutput[1]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                AptLon.Add(Components[0], Convert.ToDouble(Components[1]));
            }
        }
        
        //Get Starting Lat and long for each flight
        Dictionary<string, Tuple<double, double>> FlightStart = new Dictionary<string, Tuple<double, double>>();
        using (StreamReader reader = new StreamReader(MapOutput[2]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                //Get the Lat  for that airport
                //Check to see if it's in the valid list of airports
                if (AptLat.ContainsKey(Components[1]))
                {
                    double lat = AptLat[Components[1]];
                    double lon = AptLon[Components[1]];
                    Tuple<double, double> LatLon = new Tuple<double, double>(lat, lon);
                    if (!FlightStart.ContainsKey(Components[0]))
                    {
                        FlightStart.Add(Components[0], LatLon);
                    }
                    
                }
                
            }
        }
        //Write this to file
        //Now save the outputs to a Combiner file
        FlightStartLocFile = outputpath + @"\Sorters\FlightStartLoc.csv";

        //Create the Directory
        if (!Directory.Exists(outputpath + @"\Sorters"))
        {
            //If not, create it
            Directory.CreateDirectory(outputpath + @"\Sorters");
        }
        //Delete the file if it's already there
        if (File.Exists(FlightStartLocFile))
        {
            try
            {
                File.Delete(FlightStartLocFile);

            }
            catch (IOException)
            {
                LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete File " + FlightStartLocFile;
                return;
            }
        }
        //Now add the records
        using (StreamWriter file = new StreamWriter(FlightStartLocFile))
        {
            foreach (var tup in FlightStart)
            {
                file.WriteLine("{0},{1},{2}", tup.Key, tup.Value.Item1, tup.Value.Item2);
                
            }
        }
        //Destroy Flight Start Object
        FlightStart = null;
        //Do Garbage Collection
        GC.Collect();
        GC.WaitForPendingFinalizers();

        //Get Ending Lat and Long for each flight
        Dictionary<string, Tuple<double, double>> FlightEnd = new Dictionary<string, Tuple<double, double>>();
        using (StreamReader reader = new StreamReader(MapOutput[3]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                //Get the Lat  for that airport
                //Check to see if it's in the valid list of airports
                if (AptLon.ContainsKey(Components[1]))
                {
                    double lat = AptLat[Components[1]];
                    double lon = AptLon[Components[1]];
                    Tuple<double, double> LatLon = new Tuple<double, double>(lat, lon);
                    if (!FlightEnd.ContainsKey(Components[0]))
                    {
                        FlightEnd.Add(Components[0], LatLon);
                    }
                }

            }
        }
        //Write this to file
        //Now save the outputs to a Combiner file
        FlightEndLocFile = outputpath + @"\Sorters\FlightEndLoc.csv";

        //Delete the file if it's already there
        if (File.Exists(FlightEndLocFile))
        {
            try
            {
                File.Delete(FlightEndLocFile);

            }
            catch (IOException)
            {
                LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete File " + FlightEndLocFile;
                return;
            }
        }
        //Now add the records
        using (StreamWriter file = new StreamWriter(FlightEndLocFile))
        {
            foreach (var tup in FlightEnd)
            {
                file.WriteLine("{0},{1},{2}", tup.Key, tup.Value.Item1, tup.Value.Item2);

            }
        }
        //Destroy Flight End Object
        FlightEnd = null;
        //Do Garbage Collection
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    private void FlightsPassengers(string[] MapOutput)
    {
        string ErrorFile = outputpath + @"\PassengerFlightsErrorFile.txt";
        //First load all of the unique airport codes into a dictionay
        //create a list of tuples to assign the value, the reducer will then do the calculations later.
        List<Tuple<string, int>> FlightPassengerCount = new List<Tuple<string, int>>();
        //Load the Flight code file which is input 0
        using (StreamReader reader = new StreamReader(MapOutput[0]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                //Add the unique airport code with a flight count of 0
                FlightPassengerCount.Add(Tuple.Create(Components[0], 1));
            }
        }
        //Now write the outputs
        //Now save the outputs to a Combiner file
        FlightsPassengersFile = outputpath + @"\Sorters\FlightsPassengers.csv";

        //Create the Directory
        if (!Directory.Exists(outputpath + @"\Sorters"))
        {
            //If not, create it
            Directory.CreateDirectory(outputpath + @"\Sorters");
        }
        //Delete the file if it's already there
        if (File.Exists(FlightsPassengersFile))
        {
            try
            {
                File.Delete(FlightsPassengersFile);

            }
            catch (IOException)
            {
                LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete File " + FlightsPassengersFile;
                return;
            }
        }
        //Now add the records
        using (StreamWriter file = new StreamWriter(FlightsPassengersFile))
        {
            foreach (var tup in FlightPassengerCount)
            {
                file.WriteLine("{0},{1}", tup.Item1, tup.Item2.ToString());
            }
        }
        

    }
    private void FlightsAirport(string[] MapOutput)
    {
       
        String ErrorFile = outputpath + @"\FlightsAirportErrorFile.txt";
        //First load all of the unique airport codes into a dictionay
        //We'll use a dictionary tuple as each code will be unique
        Dictionary<string, int> AirportFlightCount = new Dictionary<string, int>();
        //Load the Airport code file which is input 0
        using (StreamReader reader = new StreamReader(MapOutput[0])) {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                //Add the unique airport code with a flight count of 0
                AirportFlightCount.Add(Components[0], 0);
            }
        }

        //Now all of the airport codes have been added, we will query the flight logs and sum the flights for each airport
        int FlightCount = 0;
        int ErrorCount = 0;
        //Load the Flights from airport file
        using (StreamReader reader = new StreamReader(MapOutput[1]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                //Find the airport code in the Dictionary
                int Count = 0;
                //Check to see if it's a valid value

                if (AirportFlightCount.TryGetValue(Components[0], out Count))
                {
                    //Add one to that value
                    Count = Count +1;
                    AirportFlightCount[Components[0]] = Count;
                    FlightCount++;
                }
                else
                {
                    //Add the error to the file
                    String ErrorText = "Invalid Airport Code found during combining " + Components[0];
                    new FileWriter().WriteData(ErrorText, ErrorFile);
                    ErrorCount++;
                }
                
            }
        }
        //Now save the outputs to a Combiner file
        FlightsAirportFile = outputpath + @"\Sorters\FlightsAirport.csv";

        //Create the Directory
        if (!Directory.Exists(outputpath + @"\Sorters"))
        {
            //If not, create it
            Directory.CreateDirectory(outputpath + @"\Sorters");
        }
        //Delete the file if it's already there
        if (File.Exists(FlightsAirportFile))
        {
            try
            {
                File.Delete(FlightsAirportFile);

            }
            catch (IOException)
            {
                LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete File " + FlightsAirportFile;
                return;
            }
        }
       
        using (StreamWriter file = new StreamWriter(FlightsAirportFile))
        {
            foreach (var Apt in AirportFlightCount)
            {
                file.WriteLine("{0},{1}", Apt.Key, Apt.Value.ToString());
            }
        }
        //Update the log Window

        LogWindow = LogWindow + System.Environment.NewLine + FlightCount.ToString() + " Flights Added";
        LogWindow = LogWindow + System.Environment.NewLine + ErrorCount.ToString() + " Sorting Errors";
        LogWindow = LogWindow + System.Environment.NewLine + "Sorter File Saved " + FlightsAirportFile;

    }


}

