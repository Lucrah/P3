using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace MahAppsTesting.Helpers
{
    class Import
    {
        private string savefile;

        private void ImportPath()
        {
            string rel_path = Directory.GetCurrentDirectory();
            string dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            savefile = rel_path.Remove(rel_path.Length - 1) + @"Data\";
        }
        private void importForSale()
        {
            var reader = new StreamReader(File.OpenRead(savefile + "til salg 20th Oct 00_33.csv"), Encoding.Default);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                int year = Convert.ToInt32(values[0]);
                int sizehouse = Convert.ToInt32(Regex.Replace(values[1], "[^0-9.]", ""));
                string uncleanSqrPrice = values[2];
                int cleansqrprice = Convert.ToInt32(uncleanSqrPrice.Replace(".", ""));
                string adresse = values[3];
                string streetName = String.Empty;
                string houseNumber = String.Empty;
                Match regexMatch = Regex.Match(adresse, "\\d");
                if (regexMatch.Success)
                {
                    int digitStartIndex = regexMatch.Index;
                    streetName = adresse.Substring(0, digitStartIndex);
                    houseNumber = adresse.Substring(digitStartIndex);
                }
                string uncleanPrice = values[4];
                int cleanPrice = Convert.ToInt32(uncleanPrice.Replace(".", ""));
                int sizeProperty = Convert.ToInt32(Regex.Replace(values[5], "[^0-9.]", ""));
                int rooms = Convert.ToInt32(values[5]);
                int areaCode = Convert.ToInt32(values[6]);
            }

        }
        private void importSold()
        {
            var reader = new StreamReader(File.OpenRead(savefile + "Solgte.csv"), Encoding.Default);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                int room = Convert.ToInt32(values[0]);
                string salesType = values[1];
                int sizeHouse = Convert.ToInt32(values[2]);
                string uncleanSqrPrice = values[3];
                int cleansqrprice = Convert.ToInt32(uncleanSqrPrice.Replace(".", ""));
                int yearBuilt = Convert.ToInt32(values[4]);
                string uncleanPrice = values[5];
                int cleanPrice = Convert.ToInt32(uncleanPrice.Replace(".", ""));
                string adresse = values[6];
                string streetName = String.Empty;
                string houseNumber = String.Empty;
                Match regexMatch = Regex.Match(adresse, "\\d");
                if (regexMatch.Success)
                {
                    int digitStartIndex = regexMatch.Index;
                    streetName = adresse.Substring(0, digitStartIndex);
                    houseNumber = adresse.Substring(digitStartIndex);
                }
                string propertyType = values[7];
                int areaCode = Convert.ToInt32(values[8]);


            }
        }


    }
}
