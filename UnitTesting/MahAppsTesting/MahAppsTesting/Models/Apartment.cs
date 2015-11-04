using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahAppsTesting
{
  class Apartment : Listing
  {
    public Apartment(string streetName, int houseNumber, int areaCode, string city) : base(streetName, houseNumber, areaCode, city)
    {
      
    }

    public Apartment(string streetName, int houseNumber, int areaCode, string city,  int priceOfHouse, int sizeOfHouse, int numberOfRooms, 
                 int numberOfBathrooms, int floorNumber, int yearBuilt) : base(streetName, houseNumber, areaCode, city, priceOfHouse, sizeOfHouse, yearBuilt) 
    {
      NumberOfRooms = numberOfRooms;
      NumberOfBathrooms = numberOfBathrooms;
      FloorNumber = floorNumber;
       
    }

    private int _numberOfRooms;

    public int NumberOfRooms
    {
      get { return _numberOfRooms; }
        private set { _numberOfRooms = value; NotifyOfPropertyChange(); }
    }

    private int _numberOfBathrooms;

    public int NumberOfBathrooms
    {
      get { return _numberOfBathrooms; }
        private set { _numberOfBathrooms = value; NotifyOfPropertyChange(); }
    }

    private int _floorNumber;

    public int FloorNumber
    {
      get { return _floorNumber; }
        private set { _floorNumber = value; NotifyOfPropertyChange(); }
    }

  }
}
