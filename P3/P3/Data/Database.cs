using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace P3
{
    public class Database
    {
        public string[] properties = new string[16] { "StreetName", "HouseNumber", "AreaCode", "City", "Type", "Latitude", "Longitude", "Price", "Size", "Rooms", "Bathrooms", "SizeOfProperty", "Basement", "Floors", "Sold", "YearBuilt" };
        public SQLiteConnection m_dbConnection;
        private List<string> _info;

        public void StartDatabase()
        {
            InitDatabase();
        }

        private void InitDatabase()
        {
            string file = AppDomain.CurrentDomain + "P3 RealEstate" + ".sqlite";
            if (!File.Exists(file))
                SQLiteConnection.CreateFile("P3 RealEstate" + ".sqlite");

            m_dbConnection = new SQLiteConnection("Data Source=" + "P3 RealEstate" + ".sqlite;Version=3;");
            m_dbConnection.Open();

            CreateTables();
        }

        private void CreateTables()
        {
            Execute("CREATE TABLE IF NOT EXISTS PropertiesTable (StreetName VARCHAR(30), HouseNumber VARCHAR(5), AreaCode CHAR(4), City VARCHAR(30), Type VARCHAR(50), Latitude VARCHAR(50), Longitude VARCHAR(50), Price VARCHAR(50), Size VARCHAR(50), Rooms VARCHAR(10), Bathrooms VARCHAR(10), SizeOfProperty VARCHAR(10), Basement VARCHAR(5), Floors VARCHAR(5), Sold CHAR(1), YearBuilt CHAR(4))");
        }

        public void Execute(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        // A method for retrieving information from the database file and seperating it acording to a string array
        private void Read(string sql, ref List<string> resultData, params string[] elements)
        {
            resultData.Clear();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string s = "";
                foreach (string el in elements)
                {
                    s += reader[el] + ",";
                }
                resultData.Add(s);
            }
        }

        /*public void LoadPropertiesFromDatabase()
        {
            List<string> _info = new List<string>();
            string sql = "SELECT * FROM properties";
            Read(sql, ref _info, properties);
            foreach (var item in _info)
            {
                string[] split = item.Split(new char[] { ',' });
                if(split[5] == "House")
                {
                    Dict.Add(new House(split[0], split[1], int.Parse(split[2]), int.Parse(split[3]), split[4], int.Parse(split[8]), int.Parse(split[9]), int.Parse(split[10]), int.Parse(split[11]), int.Parse(split[12]), int.Parse(split[13]), int.Parse(split[14]), int.Parse(split[16]));
                }
                if(split[5] == "Apartment")
                {
                    Dict.Add(new Apartment(split[0], split[1], int.Parse(split[2]), int.Parse(split[3]), split[4], int.Parse(split[8]), int.Parse(split[9]), int.Parse(split[10]), int.Parse(split[11]), int.Parse(split[14]), int.Parse(split[16]));
                }
            }
         }*/
            
            
            

        public string ListToString(List<string> inputList)
        {
            string returnString = string.Join(":", inputList.ToArray());
            return (returnString);
        }

        public List<string> StringToList(string inputString)
        {
            List<string> outputList = inputString.Split(':').ToList();
            return (outputList);
        }
    }
}
