using System;
using System.Collections.Generic;
using System.IO;
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
        public string OuputPath = "";
        public string LogWindow = "";
        public void Reduce()
        {
            //Flight Passenger is the master record that will be read last
            //Load the Departure Times
            LogWindow = LogWindow + System.Environment.NewLine + "Reducing Flight Information";
            string ErrorText = "";
            Dictionary<string, DateTime> DepTime = new Dictionary<string, DateTime>();
            using (StreamReader Reader = new StreamReader(FlightDepTimeFile))
            {
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    //Check to see if the key is already there
                    if (!DepTime.ContainsKey(Components[0]))
                    {
                        //Add the Flight to the Departure time dictionary
                        DepTime.Add(Components[0], Convert.ToDateTime(Components[1]));
                    }
                }
            }
            //Flight Times
            Dictionary<string, Int16> FlightTime = new Dictionary<string, Int16>();
            using (StreamReader Reader = new StreamReader(FlightTimeFile))
            {
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    //Check to see if the key is already there
                    if (!FlightTime.ContainsKey(Components[0]))
                    {
                        //Add the Flight to the Departure time dictionary
                        FlightTime.Add(Components[0], Convert.ToInt16(Components[1]));
                    }
                }
            }
            //Arrival Time
            Dictionary<string, DateTime> ArrTime = new Dictionary<string, DateTime>();
            //Loop through all values in the departure time and add the flight time
            foreach (var flght in DepTime)
            {
                //Get the flight time
                DateTime Dep = flght.Value;
                //get the Flight Time
                double FTime = FlightTime[flght.Key];
                DateTime ATime = Dep.AddMinutes(FTime);
                ArrTime.Add(flght.Key, ATime);
            }

            //Departure Airport
            Dictionary<string, string> DepApt = new Dictionary<string, string>();
            using (StreamReader Reader = new StreamReader(FlightDepArptFile))
            {
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    //Check to see if the key is already there
                    if (!DepApt.ContainsKey(Components[0]))
                    {
                        //Add the Flight to the Departure time dictionary
                        DepApt.Add(Components[0], Components[1]);
                    }
                }
            }
            //Arrival Airport
            Dictionary<string, string> ArvApt = new Dictionary<string, string>();
            using (StreamReader Reader = new StreamReader(FlightDestFile))
            {
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    //Check to see if the key is already there
                    if (!ArvApt.ContainsKey(Components[0]))
                    {
                        //Add the Flight to the Departure time dictionary
                        ArvApt.Add(Components[0], Components[1]);
                    }
                }
            }
            //Set the Output File
            string ReducedFile = OuputPath + @"\Reducers\FlightInformation.csv";
            // Check the Directory Exists
            if (!Directory.Exists(OuputPath + @"\Reducers"))
            {
                try
                {
                    Directory.CreateDirectory(OuputPath + @"\Reducers");
                }
                catch (IOException)
                {
                    ErrorText = "Unable to Create Directory " + OuputPath + @"\Reducers";
                    LogWindow = System.Environment.NewLine + "Unable to Create Directory " + OuputPath + @"\Reducers";
                    return;
                }
                catch (UnauthorizedAccessException)
                {
                    ErrorText = "Unable to Create Directory " + OuputPath + @"\Reducers";
                    LogWindow = System.Environment.NewLine + "Unable to Create Directory " + OuputPath + @"\Reducers";
                    return;
                }
            }
            //See if the file exists
            if (File.Exists(ReducedFile))
            {
                //try to delete it
                try
                {
                    File.Delete(ReducedFile);
                }
                catch (IOException)
                {
                    ErrorText = "Unable to Delete File " + ReducedFile;
                    LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete File " + ReducedFile;
                    return;
                }
                catch (UnauthorizedAccessException)
                {
                    ErrorText = "Unable to Delete File " + ReducedFile;
                    LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete File " + ReducedFile;
                    return;
                }
            }
            //Create the Results Form
            AllFlightInformation AFI = new AllFlightInformation();
            using (StreamReader Reader = new StreamReader(FlightPassengerFile))
            {
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //build the components
                    string Flight = Components[0];
                    string Passenger = Components[1];
                    //Save it to file
                    using (StreamWriter Writer = new StreamWriter(ReducedFile, true))
                    {
                        Writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}", Components[0], Components[1], DepApt[Flight], ArvApt[Flight], DepTime[Flight].ToString("HH:mm:ss"), ArrTime[Flight].ToString("HH:mm:ss"), TimeSpan.FromMinutes(FlightTime[Flight]).ToString());
                    }
                    //Add the result to the table
                    AFI.dataGridView1.Rows.Add(Components[0], Components[1], DepApt[Flight], ArvApt[Flight], DepTime[Flight].ToString("HH:mm:ss"), ArrTime[Flight].ToString("HH:mm:ss"), TimeSpan.FromMinutes(FlightTime[Flight]).ToString());
                }
            }
            //Do Garbage Cleanup
            DepApt = null;
            ArvApt = null;
            DepTime = null;
            ArrTime = null;
            FlightTime = null;
            GC.Collect();
            AFI.ShowDialog();

            //Save the Error Text file if it's not blank
            //Delete the File if it's alredy there
            if (File.Exists(OuputPath + @"\ReduceAllFlightInformationError.txt"))
            {
                try
                {
                    File.Delete(OuputPath + @"\ReduceAllFlightInformationError.txt");
                }
                catch (UnauthorizedAccessException)
                {
                    LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete " + OuputPath + @"\ReduceAllFlightInformationError.txt";
                    return;
                }
                catch (IOException)
                {
                    LogWindow = LogWindow + System.Environment.NewLine + "Unable to Delete " + OuputPath + @"\ReduceAllFlightInformationError.txt";
                    return;
                }
                
            }
            if (ErrorText != "")
            {
                using (StreamWriter Writer = new StreamWriter(OuputPath + @"\ReduceAllFlightInformationError.txt"))
                {
                    Writer.Write(ErrorText);
                }
                
            }
        }
    }
}
