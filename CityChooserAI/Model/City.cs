using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityChooserAI.Model
{
    public class City
    {
        public City(string[] attributes)
        {
            attr = attributes;
        }
        #region Attributes
        private string[] _attr;
        public string[] attr
        {
            get { return _attr; }
            set { _attr = value; }
        }
        private double _totalScore;
        public double totalScore
        {
            get { return _totalScore; }
            set { _totalScore = value; }
        }
        #endregion
        #region Methods
        public double CalcScore(int[] indexes)
        {
            double score = 0;
            for(int i = 0; i < indexes.Length; i++)
            {
                score += Convert.ToDouble(attr[indexes[i]]);
            }
            totalScore = Math.Round(score, 2);
            return score;
        }


        #endregion
    }
}
