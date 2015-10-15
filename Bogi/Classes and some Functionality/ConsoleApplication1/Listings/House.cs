using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class House : Listing
  {
    public House(string streetName, int houseNumber, int areaCode, string city,  int priceOfHouse, int sizeOfHouse, int numberOfRooms, 
                 int numberOfBathrooms, int sizeOfProperty, int sizeOfBasement, int numberOfFloors, int yearBuilt) : base(streetName, 
                 houseNumber, areaCode, city, priceOfHouse, sizeOfHouse, yearBuilt) 
    {
      numberofrooms = numberOfRooms;
      numberofbathrooms = numberOfBathrooms;
      sizeofproperty = sizeOfProperty;
      sizeofbasement = sizeOfBasement;
      numberoffloors = numberOfFloors;
    }

    private int NumberOfRooms;

    public int numberofrooms
    {
      get { return NumberOfRooms; }
      private set { NumberOfRooms = value; }
    }

    private int NumberOfBathrooms;

    public int numberofbathrooms
    {
      get { return NumberOfBathrooms; }
      private set { NumberOfBathrooms = value; }
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

    private int YearBuilt;

    public int yearbuilt
    {
      get { return YearBuilt; }
      set { YearBuilt = value; }
    }

  }
}
