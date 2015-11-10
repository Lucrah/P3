using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class ListingForSale : Listing
  {
    public ListingForSale(string streetName, string houseNumber, int numberOfRooms, int areaCode, int priceOfHouse, int sizeOfHouse, int yearBuilt, int sqrPrice, string propertyType, int demurrage) : 
      base(streetName, houseNumber, numberOfRooms, areaCode, priceOfHouse, sizeOfHouse, yearBuilt, sqrPrice, propertyType)
    {
      Demurrage = demurrage;
    }

    private int _Demurrage;

    public int Demurrage
    {
      get { return _Demurrage; }
      set { _Demurrage = value; }
    }

  }
}
