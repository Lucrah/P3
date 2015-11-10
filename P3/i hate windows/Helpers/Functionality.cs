﻿using System;
using System.Xml;
using P3.Models;

namespace P3.Helpers
{
  class Funktionality
  {
      //should this not be coupled directly onto listing.cs to keep it as close to data as possible
      //Or maybe even put it in BaseINPCModel, so that any listing, as long as it has an adress it can get coords 4 u

      #region wtf is this region why no name
      public static void getCoordinates(Listing listing) 
    {
      System.Threading.Thread.Sleep(1000);
      double[] geoCode = new double[2] { 0.0, 0.0 };

      string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + listing.AddressForUrl + "&sensor=false";

      var result = new System.Net.WebClient().DownloadString(address);
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(result);
      XmlNodeList parentNode = doc.GetElementsByTagName("location");
      foreach (XmlNode childrenNode in parentNode)
      {
        listing.Lat = Convert.ToDouble(childrenNode.SelectSingleNode("lat").InnerText);
        listing.Lng = Convert.ToDouble(childrenNode.SelectSingleNode("lng").InnerText);
      }
    }


    public static double convertToDistance(Listing a, Listing b)
    {
      //Haversine formula for calculating distance between lat/long points
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