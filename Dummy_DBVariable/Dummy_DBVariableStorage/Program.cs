// See https://aka.ms/new-console-template for more information
using LiteDB;
using Dummy_DBVariableStorage;

static void AddData(string key, string value)
{
    //using (var liteDb = new LiteDatabase(Path.GetFullPath("Rufo.db"))) 
    using (var liteDb = new LiteDatabase("RufoStorage.db"))
    {
        if (liteDb.CollectionExists("DBVariableStorage"))
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
    using (var liteDb = new LiteDatabase(Path.GetFullPath("RufoStorage.db")))
    {
        if (liteDb.CollectionExists("DBVariableStorage"))
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
        if (liteDb.CollectionExists("DBVariableStorage"))
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
        if (liteDb.CollectionExists("DBVariableStorage"))
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

/*
 - Assuming 100 different alarms
    - numberOfTotalData: could be 6000 (day), 180 000 (month), 2200000(year), 6 600 000 (3years)
    - randomValue: a random int between 1-10000
 */

Random rnd = new Random();
int randomValue = 0;
//int numOfTotalData = 6000; // for 1 day
int numOfTotalData = 180000; // for 1 month
//int numOfTotalData = 2200000; // for 1 year
//int numOfTotalData = 6600000; // for 3 year
int numOfTypesOfRegisters = 500;
int numOfDataPerRegister = numOfTotalData / numOfTypesOfRegisters;

Console.WriteLine($"Num Of Total data: {numOfTotalData}");
Console.WriteLine($"Num Of Types of Registers: {numOfTypesOfRegisters}");
Console.WriteLine($"Num Of Data Per Registers: {numOfDataPerRegister}");

for (int i = 0; i < numOfTypesOfRegisters ; i++)
{ 
    string key = "Alarm"+i.ToString();

    Console.WriteLine($" -  key: {key} , percentage: {(double) i*100/ numOfTypesOfRegisters}");

    
    for (int j = 0; j < numOfDataPerRegister; j++)
    {

        randomValue = rnd.Next(1, 10000);
        AddData(key, randomValue.ToString());
    }
}


