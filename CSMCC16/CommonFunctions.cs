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
    public TextBox log;
    public List<Tuple<string,object>> Passengers = new List<Tuple<string,object>>();
    public List<Tuple<string,string>> PassengerErrors = new List<Tuple<string,string>>();
   
    public void Map()
    {
        log.AppendText(System.Environment.NewLine + "Opening Passenger File" + PassengerFile);
        //Set the format checking Regexs
        //Passenger ID
        Regex PID = new Regex("[A-Z]{3}[0-9]{4}[A-Z]{2}[0-9]{1}");
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

   
    

