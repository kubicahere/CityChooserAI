using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CityChooserAI.Model
{
    static class AI
    {
        public static string[] firstLine;
        #region Methods
        public static int SearchIndex(string searched, string[] row)
        {
            return Array.IndexOf(row, searched);
        }
        public static List<City> ReadData()
        {
            List<City> listOfCities = new List<City>();
            try
            {
                using (var reader = new StreamReader(@"QualityOfLifeDataFrame.csv"))
                {
                    firstLine = reader.ReadLine().Split(",");
                    while(!reader.EndOfStream)
                    {
                        string singleLine = reader.ReadLine();
                        string[] values = singleLine.Split(",");
                        listOfCities.Add(new City(values));
                    }
                }
                return listOfCities;
            }
            catch(UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message);
                return listOfCities;
            }
        }
        public static List<City> clearList(string selectedContinent, List<City> cityList)
        {
            int continentIndex = SearchIndex(selectedContinent, firstLine);
            //TODO USUWANIE MIAST Z KONTYNENTEM ROZNYM OD WYBRANEGO 
            foreach(City ct in cityList.ToList())
            {
                //if (Convert.ToInt32(ct.attr[continentIndex]))
            }
            return cityList;
        }


        #endregion
    }
}
