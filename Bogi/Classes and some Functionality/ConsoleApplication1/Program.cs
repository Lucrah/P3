using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      Dictionary<string, Listing> dict = new Dictionary<string, Listing>();
      Dictionary<string, Listing> dictOut = new Dictionary<string, Listing>();
      Funktionality.ImportPath();
      Funktionality.importSold(dict);
      Console.WriteLine("done importing " + dict.Count + " listings. \nPress enter to start saving to file.");
      Console.ReadKey();

      foreach (var item in dict)
      {

                Console.WriteLine("Address: " + item.Value.Address);
                Funktionality.getCoordinates(item.Value);
                Console.WriteLine("Lat: " + item.Value.Lat);
                Console.WriteLine("Lng: " + item.Value.Lng);
                Funktionality.SaveUpdate(item.Value);
        
        

        
      }
      Console.WriteLine("Save to file complete.");

      //dictOut = Search.SearchForProperty("Rendsburggade", "28", 9000, 1, 3, 35, 60, "10-05-2010", "10-05-2015", 10000, ref dict);
      //Console.WriteLine(dictOut.Count());
      //Console.WriteLine("done searching");
      //foreach (var item in dictOut)
      //{
      //  Console.WriteLine(item.Value.AddressForURL);
      //
      //}

      
      Console.ReadKey();
    }
  }
}
