using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;


namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
      customCulture.NumberFormat.NumberDecimalSeparator = ".";

      System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
      ConsoleKeyInfo cki;
      Dictionary<int, ListingSold> dictSold = new Dictionary<int, ListingSold>();
      Dictionary<int, ListingForSale> dictForSale = new Dictionary<int, ListingForSale>();
      Funktionality.ImportPath();
      do
      {
        Console.Clear();
        Console.WriteLine("You now have some choices:");
        Console.WriteLine("Press 1 for importing data.");
        Console.WriteLine("Press 2 for fetching geocodes.");
        cki = Console.ReadKey(true);

        switch (cki.Key)
        {
          case ConsoleKey.D1:
            Console.Clear();
            Console.WriteLine("Press 1 for ImportSold.");
            Console.WriteLine("Press 2 for ImportForSale.");
            cki = Console.ReadKey(true);
            switch (cki.Key)
            {
              case ConsoleKey.D1:
                {
                  Funktionality.importSold(dictSold);
                  Console.WriteLine("done importing " + dictSold.Count + " listings. \nPress enter to start saving to file.");
                  Console.ReadKey();

                  double count = 0;

                  foreach (var property in dictSold)
                  {
                    count++;
                    Funktionality.SaveUpdateSold(property.Value);

                    Console.Clear();
                    Console.WriteLine("Saving to file....");
                    Console.WriteLine((count / dictSold.Count).ToString("P"));

                  }
                  Console.WriteLine("Save to file complete.");
                }
                break;
              case ConsoleKey.D2:
                {
                  Funktionality.importForSale(dictForSale);
                  Console.WriteLine("done importing " + dictForSale.Count + " listings. \nPress enter to start saving to file.");
                  Console.ReadKey();

                  double count = 0;

                  foreach (var property in dictForSale)
                  {
                    count++;
                    Funktionality.SaveUpdateForSale(property.Value);

                    Console.Clear();
                    Console.WriteLine("Saving to file....");
                    Console.WriteLine((count / dictForSale.Count).ToString("P"));

                  }
                  Console.WriteLine("Save to file complete.");
                }
                break;
              default:
                {
                  Console.WriteLine("Try again....");
                  Console.ReadKey();
                }
                break;
            }
            break;
          case ConsoleKey.D2:
            {
              Funktionality.InitializeLatLng();
            }
            break;
          default:
            {
              Console.WriteLine("Try again....");
              Console.ReadKey();
            }
            
            break;
        }
      } while (cki.Key != ConsoleKey.Escape);


      
      

  

      
      Console.ReadKey();
    }
  }
}
