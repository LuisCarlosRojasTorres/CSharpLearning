// See https://aka.ms/new-console-template for more information


using Dummy_DBVariable;
using LiteDB;

static void AddData(string key, string value)
{
    //using (var liteDb = new LiteDatabase(Path.GetFullPath("Rufo.db"))) 
    using (var liteDb = new LiteDatabase("RufoArray.db"))
    {
        if (liteDb.CollectionExists("DBVariable2"))
        {
            //Update
            var foundOne = liteDb.GetCollection<DBVariable2>().FindOne(x => x.Key == key);

            if (foundOne != null)
            {
                foundOne.AddValue(value);
                liteDb.GetCollection<DBVariable2>().Update(foundOne);
            }
            else 
            {
                liteDb.GetCollection<DBVariable2>().Insert(new DBVariable2(key, value));
            }            
        }
        else 
        {
            //Add
            liteDb.GetCollection<DBVariable2>().Insert(new DBVariable2(key, value));            
        }
    }    
}

static void printVariable(string key)
{
    using (var liteDb = new LiteDatabase(Path.GetFullPath("RufoArray.db")))
    {
        if (liteDb.CollectionExists("DBVariable2"))
        {
            var foundOne = liteDb.GetCollection<DBVariable2>().FindOne(x => x.Key == key);
            Console.WriteLine(foundOne);
        }
        else 
        {
            Console.WriteLine("Se llevaron todo, todillo");
        }
    }

}


//AddData("Rufo", "311");
//AddData("Rufo", "321");
//AddData("Rufo", "331");
//AddData("Rufo", "341");

//AddData("LORI2", "211");
//AddData("LORI2", "221");
//AddData("LORI2", "231");
//AddData("LORI2", "241");
printVariable("Rufo");



