using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
  static class Search
  {

    public static void SearchForProperty(string streetName, string houseNumber, int areaCode, int numberOfRoomsFrom, int numberOfRoomsTo, int sizeOfHouseFrom, int sizeOfHouseTo, string salesDateFrom, string salesDateTo, double radius)
    {
      
      Listing search = new Listing(streetName, houseNumber, areaCode);
      Funktionality.getCoordinates(search);

      // http://www.plumislandmedia.net/mysql/haversine-mysql-nearest-loc/ Haversine SQL formula

  
    
    }
  }






}
