// See https://aka.ms/new-console-template for more information
using LiteDB;
using Dummy_DBVariableStorage

static void AddData(string key, string value)
{
    //using (var liteDb = new LiteDatabase(Path.GetFullPath("Rufo.db"))) 
    using (var liteDb = new LiteDatabase("RufoList.db"))
    {
        if (liteDb.CollectionExists("DBVariable"))
        {
            //Update
            var foundOne = liteDb.GetCollection<DBVariableStorage>().FindOne(x => x.Key == key);

            if (foundOne != null)
            {
                foundOne.AddValue(value);
                liteDb.GetCollection<DBVariableStorage>().Update(foundOne);
            }
            else
            {
                liteDb.GetCollection<DBVariableStorage>().Insert(new DBVariableStorage(key, value));
            }
        }
        else
        {
            //Add
            liteDb.GetCollection<DBVariableStorage>().Insert(new DBVariableStorage(key, value));
        }
    }
}

static void printVariable(string key)
{
    using (var liteDb = new LiteDatabase(Path.GetFullPath("RufoList.db")))
    {
        if (liteDb.CollectionExists("DBVariable"))
        {
            var foundOne = liteDb.GetCollection<DBVariableStorage>().FindOne(x => x.Key == key);
            Console.WriteLine(foundOne);
        }
        else
        {
            Console.WriteLine("Se llevaron todo, todillo");
        }
    }
}

static void setAsHidden(string key)
{
    using (var liteDb = new LiteDatabase(Path.GetFullPath("RufoList.db")))
    {
        if (liteDb.CollectionExists("DBVariable"))
        {
            var foundOne = liteDb.GetCollection<DBVariableStorage>().FindOne(x => x.Key == key);
            foundOne.SetAsHidden();
            liteDb.GetCollection<DBVariableStorage>().Update(foundOne);
            Console.WriteLine(foundOne);

        }
        else
        {
            Console.WriteLine("Se llevaron todo, todillo");
        }
    }
}

static string getLastValue(string key)
{
    using (var liteDb = new LiteDatabase(Path.GetFullPath("RufoList.db")))
    {
        if (liteDb.CollectionExists("DBVariable"))
        {
            var foundOne = liteDb.GetCollection<DBVariableStorage>().FindOne(x => x.Key == key);
            string lastValue = foundOne.GetLastValue();
            return lastValue;
        }
        else
        {
            return "";
        }
    }
}

