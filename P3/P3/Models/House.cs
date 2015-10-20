using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
  class House : Listing
  {
     public House(string streetName, int houseNumber, int areaCode, string city) : base(streetName, houseNumber, areaCode, city)
    {
      
    }

    public House(string streetName, int houseNumber, int areaCode, string city,  int priceOfHouse, int sizeOfHouse, int numberOfRooms, 
                 int numberOfBathrooms, int sizeOfProperty, int sizeOfBasement, int numberOfFloors, int yearBuilt) : base(streetName, 
                 houseNumber, areaCode, city, priceOfHouse, sizeOfHouse, yearBuilt) 
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
      private set { _numberOfRooms = value; RaisePropertyChanged(); }
    } 

    private int _numberOfBathrooms;

    public int NumberOfBathrooms
    {
      get { return _numberOfBathrooms; }
      private set { _numberOfBathrooms = value; RaisePropertyChanged(); }
    }

    private int _sizeOfProperty;

    public int SizeOfProperty
    {
      get { return _sizeOfProperty; }
      private set { _sizeOfProperty = value; RaisePropertyChanged(); }
    }

    private int _sizeOfBasement;

    public int SizeOfBasement
    {
      get { return _sizeOfBasement; }
      private set { _sizeOfBasement = value; RaisePropertyChanged(); }
    }

    private int _numberOfFloors;

    public int NumberOfFloors
    {
      get { return _numberOfFloors; }
      set { _numberOfFloors = value; RaisePropertyChanged(); }
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
