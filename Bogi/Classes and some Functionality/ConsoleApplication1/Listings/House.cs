using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class House : Listing
  {
     public House(string streetName, string houseNumber, int areaCode) : base(streetName, houseNumber, areaCode)
    {
      
    }

    public House(string streetName, string houseNumber, int areaCode,  int priceOfHouse, int sizeOfHouse, int numberOfRooms, 
                 int numberOfBathrooms, int sizeOfProperty, int sizeOfBasement, int numberOfFloors, int yearBuilt, DateTime salesDate) : base(streetName, 
                 houseNumber, areaCode, priceOfHouse, sizeOfHouse, yearBuilt, salesDate) 
    {
      NumberOfRooms = numberOfRooms;
      NumberOfBathrooms = numberOfBathrooms;
      SizeOfProperty = sizeOfProperty;
      SizeOfBasement = sizeOfBasement;
      NumberOfFloors = numberOfFloors;
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

    /*private bool _andelsbolig;

    public bool AndelsBolig
    {
      get { return _andelsbolig; }
      private set { _andelsbolig = value; }
    }
    private bool _fritidsBolig;    //Brug muligvis til checkbokse omkring andelsbolig/fritidsbolig/almindeligt hus.

    public bool FritidsBolig
    {
      get { return _fritidsBolig; }
      private set { _fritidsBolig = value; }
    }*/

    
    



  }
}
