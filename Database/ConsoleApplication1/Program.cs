using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Database
{
    class Program
    {
        private Database Dat;
        static void Main()
        {
            Database Dat = new Database();
            Console.WriteLine("Starting Database..");
            Dat.StartDatabase();
            Console.WriteLine("Database created!");
            //string sql = "INSERT OR REPLACE INTO properties (Address, Type, Latitude, Longitude, Size, Rooms, Bathrooms, Basement, Floors, Sold, YearBuilt) values
            Console.Read();
        }
    }
}
