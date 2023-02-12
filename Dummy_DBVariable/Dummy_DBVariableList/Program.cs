// See https://aka.ms/new-console-template for more information
using Dummy_DBVariableList;
using LiteDB;

static void AddData(string key, string value)
{
    //using (var liteDb = new LiteDatabase(Path.GetFullPath("Rufo.db"))) 
    using (var liteDb = new LiteDatabase("RufoList.db"))
    {
        if (liteDb.CollectionExists("DBVariable"))
        {
            //Update
            var foundOne = liteDb.GetCollection<DBVariable>().FindOne(x => x.Key == key);

            if (foundOne != null)
            {
                foundOne.AddValue(value);
                liteDb.GetCollection<DBVariable>().Update(foundOne);
            }
            else
            {
                liteDb.GetCollection<DBVariable>().Insert(new DBVariable(key, value));
            }
        }
        else
        {
            //Add
            liteDb.GetCollection<DBVariable>().Insert(new DBVariable(key, value));
        }
    }
}

static void printVariable(string key)
{
    using (var liteDb = new LiteDatabase(Path.GetFullPath("RufoList.db")))
    {
        if (liteDb.CollectionExists("DBVariable"))
        {
            var foundOne = liteDb.GetCollection<DBVariable>().FindOne(x => x.Key == key);
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
            var foundOne = liteDb.GetCollection<DBVariable>().FindOne(x => x.Key == key);
            foundOne.SetAsHidden();
            liteDb.GetCollection<DBVariable>().Update(foundOne);
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
            var foundOne = liteDb.GetCollection<DBVariable>().FindOne(x => x.Key == key);
            string lastValue = foundOne.GetLastValue();            
            return lastValue;
        }
        else
        {
            return "";   
        }
    }
}
/*
AddData("Rufo", "311");
AddData("Rufo", "321");
AddData("Rufo", "331");
AddData("Rufo", "341");
AddData("Rufo", "351");
AddData("Rufo", "361");


AddData("Lori", "211");
AddData("Lori", "221");
AddData("Lori", "231");
AddData("Lori", "241");


AddData("Lori2", "211");
AddData("Lori2", "222");
AddData("Lori2", "233");
AddData("Lori2", "244");
AddData("Lori2", "255");
AddData("Lori2", "26");
*/

//printVariable("Lori2");
Console.WriteLine(getLastValue("Rufo"));
