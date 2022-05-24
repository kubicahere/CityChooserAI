using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityChooserAI.Model
{
    internal static class Attributes
    {
        private static string[] _attributes = { "Housing", "Cost of Living", "Startups", "Venture Capital", "Travel Connectivity", "Commute", "Business Freedom",
            "Safety", "Healthcare", "Education", "Environmental Quality", "Economy", "Taxation", "Internet Access", "Leisure & Culture", "Tolerance", "Outdoors" };
        public static string[] attributes
        {
            get
            {
                return _attributes;
            }
            set
            {
                _attributes = value;
            }
        }
    }
}
