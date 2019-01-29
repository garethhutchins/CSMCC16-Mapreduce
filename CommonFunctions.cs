using System;

public class Mapper
{
   
    public PassengerData() {
        string passengerID;
        string flightID;
        string srcApt;
        string dstApt;
        DateTime dptTime;
        DateTime flghtDur;
        }

    public AirportData()
    {
        string aptName;
        string aptCode;
        int lat;
        int lon;
    }
    public ErrorPassenger()
    {
        string InputCSV;
        string Error;
    }
    public ErrorAirpot()
    {
        string InputCSV;
        string Error;
    }
    public string InputPassenger;
    public string InputAirport;

}
