using CSMCC16;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ReduceFlightsPassengers
    {
        public string SortingFile = "";
        public string OutputPath = "";
        public string LogWindow;
        public void  Reduce()
        {
        LogWindow = LogWindow + System.Environment.NewLine + "Reducing Flight Information";
        //Create a Dictionary For the Flights
        Dictionary<string, int> FlightsPassengers = new Dictionary<string, int>();
        //Loop through all of the rows in the file
        using (StreamReader reader = new StreamReader(SortingFile))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] Components = line.Split(',');
                //Add the value to the dictionary
                //Check to see if the key is already there
                if (!FlightsPassengers.ContainsKey(Components[0]))
                {
                    //Add it
                    FlightsPassengers.Add(Components[0], Convert.ToInt16(Components[1]));
                }
                else
                {
                    //If the key is already there get the Value and add 1
                    int count = 0;
                    count = FlightsPassengers[Components[0]];
                    count = count + 1;
                    //Now save the new Value back
                    FlightsPassengers[Components[0]] = count;
                }
            }
        }
        //Now Sort according to flights with largest number
        var SortedDic = FlightsPassengers.OrderByDescending(d => d.Value).ToList();
        //Garbage Collect the old Dictionry
        FlightsPassengers = null;
        GC.Collect();

        //Now save the results to file and display them
        //Create the Directory
        if (!Directory.Exists(OutputPath + @"\Reducers"))
        {
            //If not, create it
            Directory.CreateDirectory(OutputPath + @"\Reducers");
        }
        //See if the file Exists
        string outputFile = OutputPath + @"\Reducers\PassengersPerFlight.csv";
        // Delete the File if it's there
        if (File.Exists(outputFile))
        {
            try
            {
                File.Delete(outputFile);
            }
            catch (IOException)
            {
                LogWindow = LogWindow + System.Environment.NewLine + "Unable to Save File " + outputFile; ;
                return;
            }
            catch (UnauthorizedAccessException)
            {
                LogWindow = LogWindow + System.Environment.NewLine + "Unable to Save File " + outputFile; ;
                return;
            }
        }
        //Now save the File and pass the results to the Results Window
        FlightsPassengersResults FPR = new FlightsPassengersResults();

        using (StreamWriter Writer = new StreamWriter(outputFile))
        {
            foreach (var flt in SortedDic)
            {
                //Add to the chart
                FPR.chart1.Series[0].Points.AddXY(flt.Key, flt.Value);
                //Add to the table
                FPR.dataGridView1.Rows.Add(flt.Key, flt.Value);
                Writer.WriteLine("{0},{1}", flt.Key, flt.Value);
            }
        }
        //Set the chart Interval
        FPR.chart1.ChartAreas[0].AxisX.Interval = 1;
        FPR.chart1.Update();
        //Show the Form
        FPR.ShowDialog();
        LogWindow = LogWindow + System.Environment.NewLine + "Reduced Passengers Per Flight";
    }
    }

