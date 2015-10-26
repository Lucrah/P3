using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
  class Funktionality
  {
    #region
    public static void getCoordinates(Listing listing)
    {
      System.Threading.Thread.Sleep(1000);
      double[] geoCode = new double[2] { 0, 0 };

      string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + listing.AddressForURL + "&sensor=false";

      var result = new System.Net.WebClient().DownloadString(address);
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(result);
      XmlNodeList parentNode = doc.GetElementsByTagName("location");
      foreach (XmlNode childrenNode in parentNode)
      {
        geoCode[0] = double.Parse(childrenNode.SelectSingleNode("lat").InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
        geoCode[1] = double.Parse(childrenNode.SelectSingleNode("lng").InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
      }
      listing.GetGeoCode(geoCode);
    }


    public static double convertToDistance(Listing a, Listing b)
    {
      double theDistance = (Math.Sin(DegreesToRadians(a.Lat)) *
            Math.Sin(DegreesToRadians(b.Lat)) +
            Math.Cos(DegreesToRadians(a.Lat)) *
            Math.Cos(DegreesToRadians(b.Lat)) *
            Math.Cos(DegreesToRadians(a.Lng - b.Lng)));

      return Convert.ToDouble((RadiansToDegrees(Math.Acos(theDistance)))) * 69.09 * 1.6093;
    }

    static public double RadiansToDegrees(double angle)
    {
      return angle * (180.0 / Math.PI);
    }

    static public double DegreesToRadians(double angle)
    {
      return Math.PI * angle / 180.0;
    }
    #endregion


  }
}
