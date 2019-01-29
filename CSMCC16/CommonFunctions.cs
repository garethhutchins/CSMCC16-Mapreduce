using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

public class Mapper
{
    public string PassengerFile = "";
    public TextBox log;
    public object x = new List<KeyValuePair<string, object>>();
    
    private KeyValuePair<string, object> p = new KeyValuePair<string, object>();
   private class PassengerData
    {
        string passengerID;
        string flightID;
        string srcApt;
        string dstApt;
        DateTime dptTime;
        DateTime flghtDur;
    }
    private class AirportData
    {
        string aptName;
        string aptCode;
        int lat;
        int lon;
    }
    private class ErrorPassenger
    {
        string InputCSV;
        string Error;
    }
    private class ErrorAirpot
    {
        string InputCSV;
        string Error;
    }
    public void Map()
    {
        log.AppendText(System.Environment.NewLine + "Opening Passenger File" + PassengerFile);
        //Create passenger Array
        PassengerData[] passengers = new PassengerData[0];
        Parallel.ForEach(File.ReadLines(PassengerFile).Select(line => line.Split(',')),
            components =>
            {
                Boolean OK = true;
                string ErrorText = "";
               
            }
            );
           
        
    }
}

   
    

