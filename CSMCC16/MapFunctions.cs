using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using CSMCC16;

public class Mapper
{
    public string PassengerFile = "";
    public string AirportFile = "";
    public string outputPath = "";
    
    public TextBox log;
    public List<Tuple<string,object>> Passengers = new List<Tuple<string,object>>();
    public List<Tuple<string,string>> PassengerErrors = new List<Tuple<string,string>>();
    public List<string> ValidAirport = new List<string>();

    private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

    public void Map()
    {
        //Set the output file paths
        string ErrorFile = outputPath + @"\AirportsErrorFile.txt";
        string AptLatFile = outputPath + @"\AptLat.csv";
        string AptLonFile = outputPath + @"\AptLon.csv";
        int aptOKCount = 0;
        int aptErrCount = 0;


        //Create the StreamWriters to write the three files
        
        //Set the format checking Regexs
        //Passenger ID
        Regex PID = new Regex("[A-Z]{3}[0-9]{4}[A-Z]{2}[0-9]{1}");
        Regex APT = new Regex("[A-Z]{3}");
        Regex LatLong = new Regex(@"[\-]{0,1}[0-9\.]{3,13}");


        log.AppendText(System.Environment.NewLine + "Opening Airport File Deleting Existing Files");
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

        
        log.AppendText(System.Environment.NewLine + "Opening Airport File" + AirportFile);

        Parallel.ForEach(File.ReadLines(AirportFile).Select(line => line.Split(',')),
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
                        //Put a lock on the file for this thread
                        _readWriteLock.EnterWriteLock();
                        try
                        {
                            //Wrtie Error
                            using (StreamWriter writer = new StreamWriter(ErrorFile))
                            {
                                var line = ErrorText;
                                writer.WriteLine(line);
                                writer.Close();
                            }
                        }
                        finally
                        {
                            // Release lock
                            _readWriteLock.ExitWriteLock();
                        }
                    }

                    //Check Latitude is correct

                    if (!LatLong.IsMatch(components[2]))
                    {
                        OK = false;
                        ErrorText = "Invalid Latitude Format " + components[2] + " ";
                        aptErrCount++;
                        //Put a lock on the file for this thread
                        _readWriteLock.EnterWriteLock();
                        try
                        {
                            //Wrtie Error
                            using (StreamWriter writer = new StreamWriter(ErrorFile))
                            {
                                var line = ErrorText;
                                writer.WriteLine(line);
                                writer.Close();
                            }
                        }
                        finally
                        {
                            // Release lock
                            _readWriteLock.ExitWriteLock();
                        }
                    }
                    //Check Longtitude format
                    if (!LatLong.IsMatch(components[3]))
                    {
                        OK = false;
                        ErrorText = "Invalid Longtitude Format " + components[3];
                        aptErrCount++;
                        //Put a lock on the file for this thread
                        _readWriteLock.EnterWriteLock();
                        try
                        {
                            //Wrtie Error
                            using (StreamWriter writer = new StreamWriter(ErrorFile))
                            {
                                var line = ErrorText;
                                writer.WriteLine(line);
                                writer.Close();
                            }
                        }
                        finally
                        {
                            // Release lock
                            _readWriteLock.ExitWriteLock();
                        }
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
                        

                    }
                }
                
                
            }
            );

        log.AppendText(System.Environment.NewLine + aptOKCount + " Airports Added");
        log.AppendText(System.Environment.NewLine + "Opening Passenger File" + PassengerFile);
    
        
           
        
    }
}

   
    

