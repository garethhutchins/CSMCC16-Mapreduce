using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMCC16
{
    class ReduceFlightsAirport
    {
        public string SortingFile = "";
        public string OutputPath = "";
        public string LogWindow;

        public void Reduce()
        {
            //Create a Dictionary of Airport Codes and Number of Flights
            Dictionary<string, int> FlightsAirport = new Dictionary<string, int>();
            //Now read the file and add each value to the dictionary.
            //All error checking was done before this step
            using (StreamReader reader = new StreamReader(SortingFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Components = line.Split(',');
                    //Add the value to the dictionary
                    FlightsAirport.Add(Components[0], Convert.ToInt16(Components[1]));
                }
            }
            //Now all the values have been added change the order of the dictionary
            var SortedDic = FlightsAirport.OrderByDescending(d => d.Value).ToList();
            //Save the results to file
            //Create the Directory
            if (!Directory.Exists(OutputPath + @"\Reducers"))
            {
                //If not, create it
                Directory.CreateDirectory(OutputPath + @"\Reducers");
            }
            //See if the file Exists
            string outputFile = OutputPath + @"\Reducers\FlightsPerAirport.csv";
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
            }
            //Now save the File and pass the results to the Results Window
            FlightsAirportResults FAR = new FlightsAirportResults();
            
            using (StreamWriter Writer = new StreamWriter(outputFile))
            {
                foreach (var apt in SortedDic)
                {
                    //Add to the chart
                    FAR.FlghtApt.Series[0].Points.AddXY(apt.Key, apt.Value);
                    //Add to the table
                    FAR.dataGridView1.Rows.Add(apt.Key, apt.Value);
                    Writer.WriteLine("{0},{1}", apt.Key, apt.Value);
                }
            }
            //Set the chart Interval
            FAR.FlghtApt.ChartAreas[0].AxisX.Interval = 1;
            //Show the Form
            FAR.Show();
        }
    }
}
