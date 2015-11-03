using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3.Helpers;

namespace P3.Listings
{
  class Listings
  {
    static Dictionary<string, Listing> listingsDB = new Dictionary<string, Listing>();
    public Listings()
    {
      
    }

    public void importListings()
    {
      //importering fra DB
      // >>>>Lav funktion der finder ud af hvilken type ejendom det er og opretter instants af den rigtige klasse<<<<
            //kald samme funktion i searchForProperty
      //Tilføj til listen  (listingsDB.Add();) // eller find ud af hvordan man henter/smider data i databasen
      //Hent coordinater til alle listings.
      //Kun kør getCoords hvis de ikke haves ---- if coordinates x/y == 0, then lookup. (Funktionality.getCoordinates(listing);)
      
    } 

         
    //skal måske flyttes til functionality
    public Dictionary<string, Listing> searchForProperty(double distance, string streetName, int houseNumber, int areaCode, string city, Dictionary<string, Listing> listingDB)
    {
      string address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city;
      Dictionary<string, Listing> result = new Dictionary<string, Listing>();
      if (!listingDB.ContainsKey(address))
      {
        //new Listing something ... funktion som defineret i importListings();
        Listing something = new Listing(streetName, houseNumber, areaCode, city);
        Funktionality.getCoordinates(something);
        //tilføj til DB
      }

      foreach (KeyValuePair<string, Listing> listing in listingDB)
      {
        if (distance >= Funktionality.ConvertToDistance(listing.Value, listingDB[address]))
        {
          result.Add(listing.Key, listing.Value);
        }
      }

      return result;
    }



  }
}
