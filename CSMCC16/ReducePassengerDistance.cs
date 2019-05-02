using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  public class ReducePassengerDistance
   {
    public string x = "";
    private double ToRadians(double angleIn10thofaDegree)
    {
        // Angle in 10th of a degree
        return (angleIn10thofaDegree * Math.PI) / 1800;
    }
    private double Distance(Tuple<double, double> Origin, Tuple<double, double> Destination)
    {
        //Tuple 1 latitude Tuple 2 long
        //Get latitude radians
        var lat = ToRadians((Destination.Item1 - Origin.Item1));
        //long
        var lng = ToRadians((Destination.Item2 - Origin.Item2));
        var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
          Math.Cos(ToRadians(Origin.Item1)) * Math.Cos(ToRadians(Destination.Item1)) *
          Math.Sin(lng / 2) * Math.Sin(lng / 2);
        var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
        //Times by miles
        return 3960 * h2;
    }

}

