// See https://aka.ms/new-console-template for more information


using Dummy_DBVariable;
using LiteDB;

static void AddData(string key, string value)
{
    using (var liteDb = new LiteDatabase(Path.GetFullPath("Rufo.db"))) 
    {
        if (liteDb.CollectionExists(key))
        {
            //Update
            var foundOne = liteDb.GetCollection<DBVariable>(key).FindOne(x => x.Key == key);
            foundOne.AddValue(value);

            
        }
        else 
        {
            var foundOne = liteDb.GetCollection<DBVariable>(key);
            var variable = new DBVariable(key, value);
            foundOne.Insert(variable);
        }
    }
    
}



