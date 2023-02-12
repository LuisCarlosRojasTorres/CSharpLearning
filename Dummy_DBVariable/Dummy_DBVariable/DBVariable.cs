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
        public int Id { get; set; }
        public string Key { get; set; }

        public string[]? Dates { get; set; }
        public string[]? Values { get; set; }
        public bool[]? Hidden { get; set; }

        public DBVariable()
        {
            this.Key = "dummyKey";

            this.Dates = new string[1] { DateTime.Now.ToString() };
            this.Values = new string[1] { "dummyValue" };
            this.Hidden = new bool[1] { false };
        }

        public DBVariable(string key, string[] dates, string[] values, bool[] hidden) 
        {
            this.Key = key;

            this.Dates = dates;
            this.Values = values;
            this.Hidden = hidden;            
        }

        public DBVariable(string key, string value, bool hidden = false)
        {
            this.Key = key;

            Dates = new string[1] { DateTime.Now.ToString() };
            
            Values = new string[1] { value };
            Hidden = new bool[1] { hidden };
        }

        public void AddValue( string value, bool hidden = false)
        {
            int size = this.Dates.Length;

            string now = DateTime.Now.ToString();

            string[] dummyDates = new string[size+1];
            string[] dummyValues = new string[size+1];
            bool[] dummyHidden = new bool[size+1];

            this.Dates.CopyTo(dummyDates, 0);
            dummyDates[size - 1] = now;

            this.Values.CopyTo(dummyValues, 0);            
            dummyValues[size - 1] = value;

            this.Hidden.CopyTo(dummyHidden, 0);            
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
                ans += " - " + Dates[i] + " , " + Values[i] + " , " + Hidden[i].ToString() + "\n"; 
            }

            return ans;
        }
    }
}
