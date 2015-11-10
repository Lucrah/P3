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
      Dictionary<int, ListingSold> dictSold = new Dictionary<int, ListingSold>();
      Funktionality.ImportPath();
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

  

      
      Console.ReadKey();
    }
  }
}
