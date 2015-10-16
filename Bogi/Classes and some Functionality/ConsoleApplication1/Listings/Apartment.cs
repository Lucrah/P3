using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class Apartment : Listing
  {
    public Apartment(string streetName, int houseNumber, int areaCode, string city) : base(streetName, houseNumber, areaCode, city)
    {
      
    }

    public Apartment(string streetName, int houseNumber, int areaCode, string city,  int priceOfHouse, int sizeOfHouse, int numberOfRooms, 
                 int numberOfBathrooms, int floorNumber, int yearBuilt) : base(streetName, houseNumber, areaCode, city, priceOfHouse, sizeOfHouse, yearBuilt) 
    {
      numberofrooms = numberOfRooms;
      numberofbathrooms = numberOfBathrooms;
      floornumber = floorNumber;
      
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

    private int FloorNumber;

    public int floornumber
    {
      get { return FloorNumber; }
      private set { FloorNumber = value; }
    }

  }
}
