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
            Console.Read();
        }
    }
}
