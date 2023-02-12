// See https://aka.ms/new-console-template for more information


using Dummy_DBVariable;
using LiteDB;

static void AddData(string key, string value)
{
    //using (var liteDb = new LiteDatabase(Path.GetFullPath("Rufo.db"))) 
    using (var liteDb = new LiteDatabase("Rufo.db"))
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
    using (var liteDb = new LiteDatabase(Path.GetFullPath("Rufo.db")))
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


//AddData("LORI", "111");
//AddData("LORI", "121");
//AddData("LORI", "131");
//AddData("LORI", "141");
printVariable("Rufo");



