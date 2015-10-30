using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class Apartment : Listing
  {
    public Apartment(string streetName, string houseNumber, int areaCode) : base(streetName, houseNumber, areaCode)
    {
      
    }

    public Apartment(int id ,string streetName, string houseNumber, int areaCode,  int priceOfHouse, int sizeOfHouse, int numberOfRooms, 
                 int numberOfBathrooms, int floorNumber, int yearBuilt, string salesDate, int sqrPrice) : base(id, streetName, houseNumber, numberOfRooms, areaCode, priceOfHouse, sizeOfHouse, yearBuilt, salesDate,sqrPrice) 
    {
      NumberOfRooms = numberOfRooms;
      NumberOfBathrooms = numberOfBathrooms;
      FloorNumber = floorNumber;
      
    }

    private int _numberOfRooms;

    public int NumberOfRooms
    {
      get { return _numberOfRooms; }
      private set { _numberOfRooms = value; }
    }

    private int _numberOfBathrooms;

    public int NumberOfBathrooms
    {
      get { return _numberOfBathrooms; }
      private set { _numberOfBathrooms = value; }
    }

    private int _floorNumber;

    public int FloorNumber
    {
      get { return _floorNumber; }
      private set { _floorNumber = value; }
    }

  }
}
