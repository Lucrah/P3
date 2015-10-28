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
      Console.WriteLine("done importing");
      Console.ReadKey();

      foreach (var item in dict)
      {
<<<<<<< HEAD
                Console.WriteLine(item.Value.AddressForURL);
                Funktionality.getCoordinates(item.Value);
                Console.WriteLine(item.Value.Lat);
                Console.WriteLine(item.Value.Lng);
        
        
=======
        Funktionality.getCoordinates(item.Value);
      }
      Console.WriteLine("done getting coordinates");

      dictOut = Search.SearchForProperty("Rendsburggade", "28", 9000, 1, 3, 35, 60, "10-05-2010", "10-05-2015", 10000, ref dict);
      Console.WriteLine(dictOut.Count());
      Console.WriteLine("done searching");
      foreach (var item in dictOut)
      {
        Console.WriteLine(item.Value.AddressForURL);
>>>>>>> origin/master
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
