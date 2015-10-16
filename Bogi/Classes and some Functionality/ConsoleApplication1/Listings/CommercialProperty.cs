using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Listings
{
  class CommercialProperty : Listing
  {
    public CommercialProperty(string streetName, int houseNumber, int areaCode, string city) : base(streetName, houseNumber, areaCode, city)
    {
      
    }

     public CommercialProperty(string streetName, int houseNumber, int areaCode, string city,  int priceOfHouse, int sizeOfHouse, 
                 int sizeOfStorage, int sizeOfProperty, int sizeOfBasement, int numberOfFloors, int yearBuilt) : base(streetName, 
                 houseNumber, areaCode, city, priceOfHouse, sizeOfHouse, yearBuilt) 
    {
      sizeofstorage = sizeOfStorage;
      sizeofproperty = sizeOfProperty;
      sizeofbasement = sizeOfBasement;
      numberoffloors = numberOfFloors;
    }

     private int SizeOfProperty;

     public int sizeofproperty
     {
       get { return SizeOfProperty; }
       private set { SizeOfProperty = value; }
     }

     private int SizeOfBasement;

     public int sizeofbasement
     {
       get { return SizeOfBasement; }
       private set { SizeOfBasement = value; }
     }

     private int NumberOfFloors;

     public int numberoffloors
     {
       get { return NumberOfFloors; }
       set { NumberOfFloors = value; }
     }

     private int SizeOfStorage;

     public int sizeofstorage
     {
       get { return SizeOfStorage; }
       private set { SizeOfStorage = value; }
     }

    /* private bool WarehouseBuilding;

     public bool warehousebuilding
     {
       get { return WarehouseBuilding; }
       private set { WarehouseBuilding = value; }
     }
                                                  // use for determining what kind of commercial property this is.
     private bool OfficeBuilding;

     public bool officebuilding
     {
       get { return OfficeBuilding; }
       set { OfficeBuilding = value; }
     }*/

  }
}
