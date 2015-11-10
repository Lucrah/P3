using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class ListingForSale : Listing
  {
    public ListingForSale(string streetName, string houseNumber, int numberOfRooms, int areaCode, int priceOfHouse, int sizeOfHouse, int sqrPrice, string propertyType, int demurrage) : 
      base(streetName, houseNumber, numberOfRooms, areaCode, priceOfHouse, sizeOfHouse, sqrPrice, propertyType)
    {
      Demurrage = demurrage;
      YearBuilt = 0;
    }

    private int _Demurrage;

    public int Demurrage
    {
      get { return _Demurrage; }
      set { _Demurrage = value; }
    }

    private int _yearBuilt;

    public int YearBuilt
    {
      get { return _yearBuilt; }
      set { _yearBuilt = value; }
    }

  }
}
