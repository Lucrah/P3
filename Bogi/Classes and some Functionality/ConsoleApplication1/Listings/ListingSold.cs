using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class ListingSold : Listing
  {
    public ListingSold(string streetName, string houseNumber, int numberOfRooms, int areaCode, int priceOfHouse, int sizeOfHouse, 
      int yearBuilt, string salesDate, int sqrPrice, string salesType, string propertyType) : base(streetName, houseNumber, numberOfRooms, areaCode, priceOfHouse, sizeOfHouse, sqrPrice, propertyType)
    {   
      SalesDate = salesDate;
      SalesType = salesType;
      YearBuilt = yearBuilt;
    }

    private string _salesType;

    public string SalesType
    {
      get { return _salesType; }
      set { _salesType = value; }
    }


    private string _salesDate;

    public string SalesDate
    {
      get { return _salesDate; }
      set { _salesDate = value; }
    }

    private int _yearBuilt;

    public int YearBuilt
    {
      get { return _yearBuilt; }
      set { _yearBuilt = value; }
    }
  }
}
