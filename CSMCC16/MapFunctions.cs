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
    public List<Tuple<string, object>> Passengers = new List<Tuple<string, object>>();
    public List<Tuple<string, string>> PassengerErrors = new List<Tuple<string, string>>();
    public List<string> ValidAirport = new List<string>();
    public int aptOKCount = 0;
    public int aptErrCount = 0;
    public string AptErrorFile = "";
    public string PassengerErrorFile = "";
    public string AptLatFile = "";
    public string AptLonFile = "";
    //Flight Mapping
    public string FlightAirportFile = "";
    public string FlightPassengerFile = "";
    public string FlighOriFile = "";
    public string FlightDestFile = "";
    public string FlightDepFile = "";
    public string FlightTimeFile = "";
    public List<string> PassengerChunkFiles = new List<string>();
    public List<string> AptChunkFiles = new List<string>();
    public List<string> Lines = new List<string>();

    // Set the Max Buffer to 300 so we see something happen
    public const int MAX_BUFFER = 300;
    public void MapPassengers()
    {
        //Add to the log    
        log.AppendText(System.Environment.NewLine + "Opening Passenger File" + PassengerFile);

        //Set the output file paths
        PassengerErrorFile = outputPath + @"\PassengerErrorFile.txt";

        //See if the Mappers directory exists
        if (!Directory.Exists(outputPath + @"\Mappers"))
        {
            //If not, create it
            Directory.CreateDirectory(outputPath + @"\Mappers");
        }

    }
    public void MapAirports()

    {
        //Set the output file paths
        AptErrorFile = outputPath + @"\AirportsErrorFile.txt";
        AptLatFile = outputPath + @"\Mappers\AptLat.csv";
        AptLonFile = outputPath + @"\Mappers\AptLon.csv";
        //See if the Mappers directory exists
        if (!Directory.Exists(outputPath + @"\Mappers"))
        {
            //If not, create it
            Directory.CreateDirectory(outputPath + @"\Mappers");
        }

        //Delete any Exisiting Files    
        log.AppendText(System.Environment.NewLine + "Deleting Existing Output Files");
        //See if the files exist.
        if (File.Exists(AptErrorFile))
        {
            try
            {
                File.Delete(AptErrorFile);
                File.Delete(AptLatFile);
                File.Delete(AptLonFile);
            }
            catch (IOException)
            {
                log.AppendText(System.Environment.NewLine + "Unable to Delete Files");
                return;
            }
        }
       

        //Now open the Airports File
        log.AppendText(System.Environment.NewLine + "Opening Airport File" + AirportFile);
        //Now chunk the Airports file
        ChunkAirports();

        //Now convert the airports into the required value pairs
        //Run a parallel process to read the lines of the CSV files, one file per thread
        //Calculate how many threads to run devide by two as the reading of the file will also be multi threaded.

        var Paralleloptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount / 2 };
        Parallel.ForEach(AptChunkFiles, Paralleloptions, aptChunk =>
            {
                AirportMapThreading(aptChunk);
        }
            );
        
        //Set the Log file
        log.AppendText(System.Environment.NewLine + aptOKCount + " Airports Added");

        //Now delete the Temporary Chunking files
        int DelCount = 0;
        foreach (string aptchunk in AptChunkFiles)
        {
            try
            {
                File.Delete(aptchunk);
                log.AppendText(System.Environment.NewLine + "Deleted File " + aptchunk);
                //Add that counter to the list
                DelCount++;
            }
            catch (IOException)
            {
                log.AppendText(System.Environment.NewLine + "Unable to Delete File " +aptchunk);
                return;
            }
        }
        log.AppendText(System.Environment.NewLine + DelCount.ToString() + " Temporary Buffer Files Deleted");
    }



    private void ChunkAirports()
    {
        //Chunk the Airports File for multiple threads to work on later
        log.AppendText(System.Environment.NewLine + "Chunking the Airports File");
        using (StreamReader reader = new StreamReader(AirportFile))
        {
            //While we're not at the end of the file
            string line;
            double BytesRead = 0;
            int FileChunk = 0;
            while ((line = reader.ReadLine()) != null)
            {
                Lines.Add(line);
                BytesRead = BytesRead + Encoding.UTF8.GetByteCount(line);
                //Check to see if we're over the assigned Buffer
                if (BytesRead > MAX_BUFFER)
                {
                    //Create a file Split
                    //If we're over the assigned memory buffer then dump the memory to a numbered chunk file
                    string AptChunkFile = outputPath + @"\Mappers\AptChunk_" + FileChunk + ".csv";
                    File.WriteAllLines(AptChunkFile, Lines);
                    //Add the chunk file to the lists
                    AptChunkFiles.Add(AptChunkFile);
                    //Increase chunk count
                    FileChunk++;
                    //Clear the memory
                    Lines.Clear();
                    BytesRead = 0;
                }
            }
            //Update the log
            log.AppendText(System.Environment.NewLine + "Airport file split into " + FileChunk.ToString() + " chunks");
        }
    }

    public void AirportMapThreading(string aptChunk)
        {
            //Run a parallel process to read the lines of the CSV
            //Calculate how many threads to run

            var Paralleloptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount / 2 };
            Parallel.ForEach(File.ReadLines(aptChunk).Select(line => line.Split(',')), Paralleloptions,
                components =>
                {
                    Boolean OK = true;
                    string ErrorText = "";
                    //Check the CSV file is in the correct format.
                    if (components.Length == 4)
                    {
                        
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
                        new FileWriter().WriteData(ErrorText, AptErrorFile);
                        }
                    }
                else
                    {
                        //Invalid line format
                        //Write the Errors to file
                        ErrorText = "Invlaid Line Entry";
                        new FileWriter().WriteData(ErrorText, AptErrorFile);
                    }
                }
                );
        }

    public void PassengerMapThreading(string psnChunk)
    {
        var Paralleloptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount / 2 };
        Boolean OK = true;
        string ErrorText = "";

        Parallel.ForEach(File.ReadLines(PassengerFile).Select(line => line.Split(',')), Paralleloptions,
            components =>
            {
                    //Check the CSV file is in the correct format.
                    if (components.Length == 6)
                {
                    
                }
                else
                {
                    //Loop through all of the component to specify the error
                    string tError = "";
                    foreach(string s in components)
                    {
                        //Show what you can from the error line
                        tError = tError + s + " ";
                    }
                    log.AppendText(System.Environment.NewLine + "Invalid Passenger File Line" + PassengerFile);
                }

            }
            );
    }
   
}


   
    

