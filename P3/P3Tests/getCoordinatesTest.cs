using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3.Models;
using P3.Views;
using P3.Helpers;
using Caliburn.Micro;
using System.Xml;





namespace P3Tests
{
  [TestClass]
  public class getCoordinatesTest
  {
    static IWindowManager windowManager;
    Funktionality fncy = new Funktionality(windowManager);


    [TestMethod]
    public void TestgetCoordinates()
    {
      Listing TestListing = new Listing("Jomfru Ane Gade", "28", 9000);
      string StreetNameTest = string.Empty;
      string HouseNumberTest = string.Empty;
      int AreaCodeTest = 0;
      string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + TestListing.AddressForUrl + "&sensor=false";

      var result = new System.Net.WebClient().DownloadString(address);
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(result);

      XmlNodeList AddressComponents = doc.GetElementsByTagName("address_component");
      //  XmlNodeList houseNumberNode = doc.GetElementsByTagName("./address_component[type = 'street_number']");
      //XmlNodeList areaCodeNode = doc.GetElementsByTagName("./address_component[type = 'postal_code']");
      foreach (XmlNode childNode in AddressComponents)
      {
        if (childNode.SelectSingleNode("type").InnerText == "route")
        {
          StreetNameTest = childNode.SelectSingleNode("long_name").InnerText;
        }
        else if (childNode.SelectSingleNode("type").InnerText == "street_number")
        {
          HouseNumberTest = childNode.SelectSingleNode("long_name").InnerText;
        }
        else if (childNode.SelectSingleNode("type").InnerText == "postal_code")
        {
          AreaCodeTest = int.Parse(childNode.SelectSingleNode("long_name").InnerText);
        }
      }
      Assert.AreEqual(TestListing.StreetName, StreetNameTest);
      Assert.AreEqual(TestListing.HouseNumber, HouseNumberTest);
      Assert.AreEqual(TestListing.AreaCode, AreaCodeTest);

    }
  }
}
