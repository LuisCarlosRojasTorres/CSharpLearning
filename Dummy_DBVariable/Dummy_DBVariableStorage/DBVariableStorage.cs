using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy_DBVariableStorage
{
    internal class DBVariableStorage
    {
        public int Id { get; set; }
        public string Key { get; set; }

        public List<string>? Dates { get; set; }
        public List<string>? Values { get; set; }
        public List<bool>? Hidden { get; set; }

        public DBVariableStorage()
        {
            this.Key = "dummyKey";

            Random rnd = new Random();
            int year = rnd.Next(1, 9999);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, 28);

            int hour = rnd.Next(1, 24);
            int minute = rnd.Next(1, 60);
            int second = rnd.Next(1, 60);

            this.Dates = new List<string> { (new DateTime(year, month, day, hour, minute, second)).ToString() };
            this.Values = new List<string> { "dummyValue" };
            this.Hidden = new List<bool> { false };
        }

        public DBVariableStorage(string key, List<string> dates, List<string> values, List<bool> hidden)
        {
            this.Key = key;

            this.Dates = dates;
            this.Values = values;
            this.Hidden = hidden;
        }

        public DBVariableStorage(string key, string value, bool hidden = false)
        {
            this.Key = key;

            Random rnd = new Random();
            int year = rnd.Next(1, 9999);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, 28);

            int hour = rnd.Next(1, 24);
            int minute = rnd.Next(1, 60);
            int second = rnd.Next(1, 60);

            this.Dates = new List<string> { (new DateTime(year, month, day, hour, minute, second)).ToString() };
            this.Values = new List<string> { value };
            this.Hidden = new List<bool> { hidden };
        }

        public void AddValue(string value, bool hidden = false)
        {
            Random rnd = new Random();
            int year = rnd.Next(1, 9999);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, 28);

            int hour = rnd.Next(1, 24);
            int minute = rnd.Next(1, 60);
            int second = rnd.Next(1, 60);

            this.Dates = new List<string> { (new DateTime(year, month, day, hour, minute, second)).ToString() };
            this.Values.Add(value);
            this.Hidden.Add(hidden);
        }

        public void SetAsHidden()
        {
            for (int i = 0; i < this.Hidden.Count; i++)
            {
                this.Hidden[i] = true;
            }
        }

        public string GetLastValue()
        {
            if (this.Values != null)
            {
                return this.Values[this.Values.Count() - 1];
            }
            else
            {
                return "null reference!";
            }

        }

        public override string ToString()
        {
            string ans = "KEY: " + Key + "\n";

            for (int i = 0; i < Dates.Count; i++)
            {
                ans += " - " + Dates[i] + " , " + Values[i] + " , " + Hidden[i].ToString() + "\n";
            }

            return ans;
        }
    }
}
