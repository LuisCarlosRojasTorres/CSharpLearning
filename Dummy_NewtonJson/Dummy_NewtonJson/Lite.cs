using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Dummy_NewtonJson
{
    public static class Lite
    {
        public static void Add(string key, string value)
        {
            using (LiteDatabase db = new LiteDatabase("Lite.db"))
            {
                db.GetCollection("zeit").Insert(new BsonDocument() { { "_id", key }, { "Value", value } });
                db.Commit();
            } 
        }
    }
}
