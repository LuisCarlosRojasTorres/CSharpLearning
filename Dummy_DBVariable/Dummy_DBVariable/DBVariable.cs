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

        public List<string>? Dates { get; set; }
        public List<string>? Values { get; set; }
        public List<bool>? Hidden { get; set; }

        public DBVariable()
        {
            this.Key = "dummyKey";

            this.Dates = new List<string> { DateTime.Now.ToString() };
            this.Values = new List<string> { "dummyValue" };
            this.Hidden = new List<bool> { false };
        }

        public DBVariable(string key, List<string> dates, List<string> values, List<bool> hidden) 
        {
            this.Key = key;

            this.Dates = dates;
            this.Values = values;
            this.Hidden = hidden;            
        }

        public DBVariable(string key, string value, bool hidden = false)
        {
            this.Key = key;

            this.Dates = new List<string> { DateTime.Now.ToString() };
            this.Values = new List<string> { value };
            this.Hidden = new List<bool> { hidden };
        }

        public void AddValue( string value, bool hidden = false)
        {            
            this.Dates.Add(DateTime.Now.ToString());
            this.Values.Add(value);
            this.Hidden.Add(hidden);            
        }

        public void SetAsHidden() 
        {
            for(int i = 0; i < this.Hidden.Count; i++) 
            {
                this.Hidden[i] = true;
            }
        }

        public override string ToString()
        {
            string ans = "KEY: " + Key + "\n";

            for (int i = 0; i < Dates.Count; i++) {
                ans += " - " + Dates[i] + " , " + Values[i] + " , " + Hidden[i].ToString() + "\n"; 
            }

            return ans;
        }
    }
}
