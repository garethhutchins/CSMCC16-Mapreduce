using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class Mapper
{
    public string PassengerFile = "";
    public string AirportFile = "";
    public TextBox log;
    public List<Tuple<string,object>> Passengers = new List<Tuple<string,object>>();
    public List<Tuple<string,string>> PassengerErrors = new List<Tuple<string,string>>();
    public List<string> ValidAirport = new List<string>();
   
    public void Map()
    {
        //Set the format checking Regexs
        //Passenger ID
        Regex PID = new Regex("[A-Z]{3}[0-9]{4}[A-Z]{2}[0-9]{1}");
        Regex APT = new Regex("[A-Z]{3}");
        Regex LatLong = new Regex(@"[\-]{0,1}[0-9\.]{3,13}");

        log.AppendText(System.Environment.NewLine + "Opening Airport File" + AirportFile);

        Parallel.ForEach(File.ReadLines(AirportFile).Select(line => line.split(',')),
            components =>
            {
                Boolean OK = true;
                string ErrorText = "";
                //Check the airport format is correct
                if (!APT.IsMatch(components[1])) {
                    OK = false;
                    ErrorText = "Invalid Airport Code " + components[1] + " ";
                 }
                //Check Latitude is correct

                if(!LatLong.IsMatch(components[2])) {
                    OK = false;
                    ErrorText = "Invalid Latitude Format " + components[2] + " ";
}
                //Check Longtitude format
                 if(!LatLong.IsMatch(components[3])) {
                    OK = false;
                    ErrorText = "Invalid Longtitude Format " + components[3];
}
                 if (OK) {
                    //Write the Mapping Files
}                        
                 else {
                    //Write to the Error File
}                     
           
}
            );
        
        log.AppendText(System.Environment.NewLine + "Opening Passenger File" + PassengerFile);
    
        Parallel.ForEach(File.ReadLines(PassengerFile).Select(line => line.Split(',')),
            components =>
            {
                Boolean OK = true;
                string ErrorText = "";
                //Get the first column
                
                //check the format is OK
                
                if (!PID.IsMatch(components[0])) {
                    OK = false;
                    PassengerErrors.Add(new Tuple<string, string>("Invalid Passgenger ID"),components[0]);
                }
                else {
                    Passengers.Add(new Tuple<string, object>("PassangerID",components[0]));
                }
                
              
            }
            );
           
        
    }
}

   
    

