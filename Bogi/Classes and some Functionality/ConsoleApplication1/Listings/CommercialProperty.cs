using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Listings
{
  class CommercialProperty : Listing
  {
    public CommercialProperty(string streetName, string houseNumber, int areaCode) : base(streetName, houseNumber, areaCode)
    {
      
    }

     public CommercialProperty(int id, string streetName, string houseNumber,int numberOfRooms, int areaCode,  int priceOfHouse, int sizeOfHouse,
                 int sizeOfStorage, int sizeOfProperty, int sizeOfBasement, int numberOfFloors, int yearBuilt, string salesDate, int sqrPrice)
        : base(id, streetName, houseNumber, numberOfRooms, areaCode, priceOfHouse, sizeOfHouse, yearBuilt, salesDate, sqrPrice) 
    {
      SizeOfStorage = sizeOfStorage;
      SizeOfProperty = sizeOfProperty;
      SizeOfBasement = sizeOfBasement;
      NumberOfFloors = numberOfFloors;
    }

     private int _sizeOfProperty;

     public int SizeOfProperty
     {
       get { return _sizeOfProperty; }
       private set { _sizeOfProperty = value; }
     }

     private int _sizeOfBasement;

     public int SizeOfBasement
     {
       get { return _sizeOfBasement; }
       private set { _sizeOfBasement = value; }
     }

     private int _numberOfFloors;

     public int NumberOfFloors
     {
       get { return _numberOfFloors; }
       set { _numberOfFloors = value; }
     }

     private int _sizeOfStorage;

     public int SizeOfStorage
     {
       get { return _sizeOfStorage; }
       private set { _sizeOfStorage = value; }
     }

    /* private bool _warehouseBuilding;

     public bool WarehouseBuilding
     {
       get { return _warehouseBuilding; }
       private set { _warehouseBuilding = value; }
     }
                                                  // use for determining what kind of commercial property this is.
     private bool _officeBuilding;

     public bool OfficeBuilding
     {
       get { return _officeBuilding; }
       set { _officeBuilding = value; }
     }*/

  }
}
