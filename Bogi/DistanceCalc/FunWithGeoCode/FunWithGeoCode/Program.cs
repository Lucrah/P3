using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FunWithGeoCode
{
  class Program
  {
    static void Main(string[] args)
    {



      double[] AddressOne = new double[2];
      double[] AddressTwo = new double[2];
      string[] lol = new string[2];
      lol[0] = "Selma+Lagerløfs+vej+300,+9220+Aalborg+Øst";
      lol[1] = "Rendsburggade+28,+9000+Aalborg";
      AddressOne = getDistance(lol[0]);
      AddressTwo = getDistance(lol[1]);

      double something = convertToDistance(AddressOne, AddressTwo);

      Console.WriteLine(something);
      Console.ReadLine();
    }

      public static double[] getDistance(string address1)
      {
          System.Threading.Thread.Sleep(1000);
          double[] geoCode = new double[2] { 0.0, 0.0 };
        
        string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + address1 + "&sensor=false";

        var result = new System.Net.WebClient().DownloadString(address);
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(result);
        XmlNodeList parentNode = doc.GetElementsByTagName("location");
        foreach (XmlNode childrenNode in parentNode)
        {
        geoCode[0] = Convert.ToDouble(childrenNode.SelectSingleNode("lat").InnerText);
        geoCode[1] = Convert.ToDouble(childrenNode.SelectSingleNode("lng").InnerText);
        }

        return geoCode;
       
      }

    protected static string fileGetContents(string fileName)
    {
        string sContents = string.Empty;
        string me = string.Empty;
        try
        {
            if (fileName.ToLower().IndexOf("http:") > -1)
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] response = wc.DownloadData(fileName);
                sContents = System.Text.Encoding.ASCII.GetString(response);

            }
            else
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                sContents = sr.ReadToEnd();
                sr.Close();
            }
        }
        catch { sContents = "unable to connect to server "; }
        return sContents;
    }
    
    static double convertToDistance(double[] a, double[] b)
    {

      Console.WriteLine("address 1 lat  " + a[0]);
      Console.WriteLine("address 1 lng  " + a[1]);
      Console.WriteLine("address 2 lat  " + b[0]);
      Console.WriteLine("address 2 lng  " + b[1]);

      double theDistance = (Math.Sin(DegreesToRadians(a[0])) *
            Math.Sin(DegreesToRadians(b[0])) +
            Math.Cos(DegreesToRadians(a[0])) *
            Math.Cos(DegreesToRadians(b[0])) *
            Math.Cos(DegreesToRadians(a[1] - b[1])));

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
    }
  }

