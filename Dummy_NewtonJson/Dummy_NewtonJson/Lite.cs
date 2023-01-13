using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Newtonsoft.Json.Linq;

namespace Dummy_NewtonJson
{
    public static class Lite
    {
        public static void Set(string key, string value, string nameOfCollection = "rufo")
        {
            using (LiteDatabase db = new LiteDatabase("Lite.db"))
            {
                var foundValue = db.GetCollection(nameOfCollection).FindOne(x => x["_id"] == key);

                if (foundValue == null)
                {
                    Console.WriteLine($" > [_id] New Value Added: {key}");
                    db.GetCollection(nameOfCollection).Insert(new BsonDocument() { { "_id", key }, { "Value", value } });
                }
                else 
                {
                    Console.WriteLine($" > [_id] Value Updated: {key}");
                    foundValue["Value"] = value;
                    db.GetCollection(nameOfCollection).Update(foundValue);
                }                
            }
        }
        
        public static void Set(Dictionary<string,string> newValues, string nameOfCollection = "rufo")
        {
            if (newValues != null) 
            {
                foreach (var item in newValues)
                {
                    Set(item.Key, item.Value);
                }
            }            
        }

        public static string Get(string key, string nameOfCollection = "rufo")
        {
            using (LiteDatabase db = new LiteDatabase("Lite.db"))
            {
                var foundValue = db.GetCollection(nameOfCollection).FindOne(x => x["_id"] == key);

                if (foundValue != null)
                {
                    Console.WriteLine($" > GET: key = {foundValue["_id"]} , Value = {foundValue["Value"]}");                    
                    return foundValue["Value"];
                }

                Console.WriteLine($" > {key} not found!");
                return foundValue;
            }
        }

        public static void Delete(string key, string nameOfCollection = "rufo")
        {
            using (LiteDatabase db = new LiteDatabase("Lite.db"))
            {
                var foundValue = db.GetCollection(nameOfCollection).FindOne(x => x["_id"] == key);

                if (foundValue != null)
                {
                    Console.WriteLine($" > DELETE: key = {foundValue["_id"]} , Value = {foundValue["Value"]}");
                    db.GetCollection(nameOfCollection).Delete(foundValue["_id"]);
                }                
            }
        }

        public static List<string> GetKeys(string nameOfCollection = "rufo")
        {
            using (LiteDatabase db = new LiteDatabase("Lite.db"))
            {
                var listOfKeys = db.GetCollection("rufo").FindAll().Select(x => x["_id"].AsString).ToList();
                return listOfKeys;
            }            
        }

    }
}
