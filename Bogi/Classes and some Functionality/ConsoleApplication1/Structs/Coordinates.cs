using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  public struct Coordinates
  {
      //I made it immutable, and implemented iequatable and stuff so we can compare stuff
    private readonly double latitude;
    private readonly double longtitude;

    public double Latitude { get { return latitude; } }
    public double Longtitude { get { return longtitude; } }

    public Coordinates(double latitude, double longtitude)
    {
        this.latitude = latitude;
        this.longtitude = longtitude;
    }

    //Ser ordentligt ud når vi
    public override string ToString()
    {
        return string.Format("{0},{1}", Latitude, Longtitude);
    }


  }
}
