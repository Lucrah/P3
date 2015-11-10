﻿namespace P3.Models
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
      SizeOfStorage = sizeOfStorage;
      SizeOfProperty = sizeOfProperty;
      SizeOfBasement = sizeOfBasement; 
      NumberOfFloors = numberOfFloors;
    }

     private int _sizeOfProperty;

     public int SizeOfProperty
     {
       get { return _sizeOfProperty; }
         private set { _sizeOfProperty = value; NotifyOfPropertyChange(); }
     }

     private int _sizeOfBasement;

     public int SizeOfBasement
     {
       get { return _sizeOfBasement; }
         private set { _sizeOfBasement = value; NotifyOfPropertyChange(); }
     }

     private int _numberOfFloors;

     public int NumberOfFloors
     {
       get { return _numberOfFloors; }
         set { _numberOfFloors = value; NotifyOfPropertyChange(); }
     }

     private int _sizeOfStorage;

     public int SizeOfStorage
     {
       get { return _sizeOfStorage; }
         private set { _sizeOfStorage = value; NotifyOfPropertyChange(); }
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