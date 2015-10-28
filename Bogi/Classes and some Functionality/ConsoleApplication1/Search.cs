using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  static class Search
  {

    public static Dictionary<string, Listing> SearchForProperty(string streetName, string houseNumber, int areaCode, int numberOfRoomsFrom, int numberOfRoomsTo, int sizeOfHouseFrom, int sizeOfHouseTo, string salesDateFrom, string salesDateTo, double radius, ref Dictionary<string, Listing> Dict)
    {
      Dictionary<string, Listing> dictOut = new Dictionary<string, Listing>();
      Listing search = new Listing(streetName, houseNumber, areaCode);
      Funktionality.getCoordinates(search);

      dictOut = Dict.Where(l => (Funktionality.convertToDistance(search, l.Value) * 1000) < radius && l.Value.Size > sizeOfHouseFrom && l.Value.Size < sizeOfHouseTo).ToDictionary(l => l.Key, l => l.Value);

      return dictOut;
    }
  }






}
