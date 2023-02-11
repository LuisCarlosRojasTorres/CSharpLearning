using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy_DBVariable
{
    public class DBVariable
    {
        public string Key { get; set; }

        public DateTime[] Dates { get; set; }
        public string[] Values { get; set; }
        public bool[] Hidden { get; set; }

        public DBVariable(string key, string value, bool hidden = false) 
        {
            this.Key = key;
            DateTime now= DateTime.Now;
            
            this.Dates= new DateTime[1];
            this.Values= new string[1];
            this.Hidden = new bool[1];

            this.Dates[0] = now;
            this.Values[0] = value;
            this.Hidden[0] = hidden;
        }

        public void AddValue( string value, bool hidden = false)
        {
            int size = this.Dates.Length;

            DateTime now = DateTime.Now;

            DateTime[] dummyDates = new DateTime[size+1];
            String[] dummyValues = new string[size+1];
            bool[] dummyHidden = new bool[size+1];

            dummyDates.CopyTo(this.Dates, 0);
            dummyDates[size - 1] = now;

            dummyValues.CopyTo(this.Values, 0);
            dummyValues[size - 1] = value;

            dummyHidden.CopyTo(this.Hidden, 0);
            dummyHidden[size - 1] = hidden;

            this.Dates= dummyDates;
            this.Values= dummyValues;
            this.Hidden= dummyHidden;
        }

        public void SetAsHidden() 
        {
            for(int i = 0; i < this.Hidden.Length; i++) 
            {
                this.Hidden[i] = true;
            }
        }

        public override string ToString()
        {
            string ans = "KEY: " + Key + "\n";

            for (int i = 0; i < Dates.Length; i++) {
                ans += " - " + Dates[i].ToString() + " , " + Values[i] + " , " + Hidden[i].ToString(); 
            }

            return ans;
        }
    }
}
