using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using CSMCC16;
using System.Text;

public class Mapper
{
    public string PassengerFile = "";
    public string AirportFile = "";
    public string outputPath = "";

     //Set the format checking Regexs
        
    //Passenger ID
    private Regex PID = new Regex("[A-Z]{3}[0-9]{4}[A-Z]{2}[0-9]{1}");
       
    //Flight ID
    private Regex FID = new Regex("[A-Z]{3}[0-9]{4}[A-Z]{1}");

    //Airport Code Format
    private Regex APT = new Regex("[A-Z]{3}");

    //Departure Time
    private Regex DT = new Regex("[0-9]{10}");

    //Total Flight Time

    private Regex FT = new Regex("[0-9]{1,4}");

    //Latitide and Longtitude
    private Regex LatLong = new Regex(@"[\-]{0,1}[0-9\.]{3,13}");
    
    public TextBox log;
    public List<Tuple<string,object>> Passengers = new List<Tuple<string,object>>();
    public List<Tuple<string,string>> PassengerErrors = new List<Tuple<string,string>>();
    public List<string> ValidAirport = new List<string>();
    public int aptOKCount = 0;
    public int aptErrCount = 0;
    public string ErrorFile = "";
    public string AptLatFile = "";
    public string AptLonFile = "";
    // Set the Max Buffer to 300 so we see something happen
        public const int MAX_BUFFER = 300;
    
    public void MapAirports()

    {
        //Set the output file paths
         ErrorFile = outputPath + @"\AirportsErrorFile.txt";
         AptLatFile = outputPath + @"\Map_AptLat.csv";
         AptLonFile = outputPath + @"\Map_AptLon.csv";
          List<string> AptChunkFiles = new List<string>();
        List<string> Lines = new List<string>();
        
     
        log.AppendText(System.Environment.NewLine + "Deleting Existing Output Files");
        try
        {
            File.Delete(ErrorFile);
            File.Delete(AptLatFile);
            File.Delete(AptLonFile);
        } catch(IOException)
        {
            log.AppendText(System.Environment.NewLine + "Unable to Delete Files");
            return;
        }

        //Now open the Airports File
        log.AppendText(System.Environment.NewLine + "Opening Airport File" + AirportFile);

        //Chunk the Airports File
        log.AppendText(System.Environment.NewLine + "Chunking the Airports File");
        using (StreamReader reader = new StreamReader(AirportFile)) {
         //While we're not at the end of the file
         string line;
         double BytesRead = 0;
        int FileChunk = 0;
         while ((line = reader.ReadLine()) != null) {
            Lines.Add(line);
            BytesRead = BytesRead + Encoding.UTF8.GetByteCount(line);
            //Check to see if we're over the assigned Buffer
            if (BytesRead > MAX_BUFFER) {
                    //Create a file Split
                    string AptChunkFile = outputPath + @"\AptChunk_" + FileChunk + ".csv";
                    File.WriteAllLines(AptChunkFile,Lines);
                    AptChunkFiles.Add(AptChunkFile);
                    FileChunk++;
                    Lines.Clear();
                    BytesRead = 0;
}               
}
}

        log.AppendText(System.Environment.NewLine + aptOKCount + " Airports Added");
    }

    public void AirportMapTreading(string chunkFile)
    {
        //Run a parallel process to read the lines of the CSV
        //Calculate how many threads to run

        var Paralleloptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 };
        Parallel.ForEach(File.ReadLines(AirportFile).Select(line => line.Split(',')), Paralleloptions,
            components =>
            {
                //Check the CSV file is in the correct format.
                if (components.Length == 4)
                {
                    Boolean OK = true;
                    string ErrorText = "";
                    //Check the airport format is correct
                    if (!APT.IsMatch(components[1]))
                    {
                        OK = false;
                        ErrorText = "Invalid Airport Code " + components[1] + " ";
                        aptErrCount++;
                    }

                    //Check Latitude format is correct

                    if (!LatLong.IsMatch(components[2]))
                    {
                        OK = false;
                        ErrorText = "Invalid Latitude Format " + components[2] + " ";
                        aptErrCount++;
                    }
                    //Check Longtitude format
                    if (!LatLong.IsMatch(components[3]))
                    {
                        OK = false;
                        ErrorText = "Invalid Longtitude Format " + components[3];
                        aptErrCount++;
                    }
                    if (OK)
                    {
                        //Write the Mapping Files
                        aptOKCount++;
                        //Airport & Latitude
                        var line = string.Format("{0},{1}", components[1], components[2]);
                        new FileWriter().WriteData(line, AptLatFile);

                        //Airport & Longtitude
                        line = string.Format("{0},{1}", components[1], components[3]);
                        new FileWriter().WriteData(line, AptLonFile);

                        //Add the Valid Airport to the List
                        ValidAirport.Add(components[1]);

                    }
                    else
                    {
                        //Write the Errors to file
                        new FileWriter().WriteData(ErrorText, ErrorFile);
                    }
                }
            }
            );
    }
    public void MapPassengers() {

        log.AppendText(System.Environment.NewLine + "Opening Passenger File" + PassengerFile);
        var Paralleloptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };

        Parallel.ForEach(File.ReadLines(PassengerFile).Select(line => line.Split(',')),Paralleloptions,
            components =>
            {
                //Check the CSV file is in the correct format.
                if (components.Length == 6)
                {
                    Boolean OK = true;
                    string ErrorText = "";
                }
                    
            }
            );
}
}

   
    

