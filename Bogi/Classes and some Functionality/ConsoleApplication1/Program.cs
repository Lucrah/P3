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
      Listing listing1 = new House("H C Andersen Vej", 3, 9000, "Aalborg", 2098000, 124, 4, 2, 709, 0, 1, 1966);
      Listing listing2 = new Apartment("Gammel Strandvej", 5, 9000, "Aalborg", 785000, 43, 1, 1, 4, 1939);

      List<Listing> dict = new List<Listing>();
      dict.Add(listing1);
      dict.Add(listing2);

      foreach (Listing listing in dict)
      {
        Funktionality.getCoordinates(listing);
      }

      Console.WriteLine("listing 1:");
      Console.WriteLine(listing1.coordinates.lat);
      Console.WriteLine(listing1.coordinates.lng);
      Console.WriteLine("listing 2:");
      Console.WriteLine(listing2.coordinates.lat);
      Console.WriteLine(listing2.coordinates.lng);
      Console.ReadKey();
      double lol = Funktionality.convertToDistance(listing1, listing2);
      Console.WriteLine(lol);
      Console.ReadKey();
    }
  }
}
