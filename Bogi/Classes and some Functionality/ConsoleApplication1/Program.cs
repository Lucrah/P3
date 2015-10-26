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
      Funktionality.ImportPath();
      Funktionality.importSold(dict);
      Console.ReadKey();

      foreach (var item in dict)
      {
        Funktionality.getCoordinates(item.Value);
        Console.WriteLine(item.Value.Lat);
        Console.WriteLine(item.Value.Lng);
        Console.WriteLine(item.Value.AddressForURL);
        
      }
      //Listing listing1 = new House("Rendsburggade", 28, 9000);
      //Listing listing2 = new Apartment("Selma Lagerløfs vej", 300, 9220);

      //List<Listing> dict = new List<Listing>();
      //dict.Add(listing1);
      //dict.Add(listing2);

      //foreach (Listing listing in dict)
      //{
      //  Funktionality.getCoordinates(listing);
      //}

      //Console.WriteLine("listing 1:");
      //Console.WriteLine(listing1.Lat);
      //Console.WriteLine(listing1.Lng);
      //Console.WriteLine("listing 2:");
      //Console.WriteLine(listing2.Lat);
      //Console.WriteLine(listing2.Lng);
      //Console.ReadKey();
      //double lol = Funktionality.convertToDistance(listing1, listing2);
      //Console.WriteLine(lol);
      Console.ReadKey();
    }
  }
}
