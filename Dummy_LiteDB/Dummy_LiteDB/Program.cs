// See https://aka.ms/new-console-template for more information
using LiteDB;
using Dummy_LiteDB;
using System.Globalization;

static LiteDatabase CreateDB()
{
    LiteDatabase db = new LiteDatabase("Lite.db");
    return db;
}

static void Add(ref LiteDatabase db, string nome, int idade)
{
    db.GetCollection<Pessoa>().Insert(new Pessoa(nome, idade));
    db.Commit();
    Get(ref db, nome);
}

static void Get(ref LiteDatabase db, string nome)
{
    if (db.CollectionExists("Pessoa")) 
    {
        var foundOne = db.GetCollection<Pessoa>().FindOne(x => x.Nome == nome);
        if (foundOne != null)
        {
            Console.WriteLine($" > GET, Id: {foundOne.Id} , Nome: {foundOne.Nome} , Idade: {foundOne.Idade} , DateTime: {foundOne.Fecha}");
        }
        else 
        {
            Console.WriteLine($" > GET ERROR: {nome} not Found, ");
        }
        
    }
}

static void UpdateIdade (ref LiteDatabase db, string nome, int idade)
{
    if (db.CollectionExists("Pessoa"))
    {
        var foundOne = db.GetCollection<Pessoa>().FindOne(x => x.Nome == nome);
        if (foundOne != null)
        {
            foundOne.Idade = idade;
            db.GetCollection<Pessoa>().Update(foundOne);
            Console.WriteLine($" > UPDATE, Id: {foundOne.Id} , Nome: {foundOne.Nome} , Idade: {foundOne.Idade} , DateTime: {foundOne.Fecha}");
        }
        else 
        {
            Console.WriteLine($" > UPDATE ERROR: {nome} not Found, using Add instead");
            Add(ref db, nome, idade);
        }
        
    }
}

static void Delete(ref LiteDatabase db, string nome)
{
    if (db.CollectionExists("Pessoa"))
    {
        var foundOne = db.GetCollection<Pessoa>().FindOne(x => x.Nome == nome);
        if (foundOne != null)
        {
            Console.WriteLine($" > DELETED, Id: {foundOne.Id} , Nome: {foundOne.Nome} , Idade: {foundOne.Idade} , DateTime: {foundOne.Fecha}");
            db.GetCollection<Pessoa>().Delete(foundOne.Id);
        }
        else
        {
            Console.WriteLine($" > DELETE ERROR: {nome} not Found");            
        }
    }
}

LiteDatabase db = CreateDB();
//Add(ref db, "Luis Rojas", 34);
//Add(ref db, "Jessy Morier", 32);
//Add(ref db, "Rufo", 10);

Get(ref db, "Luis Rojas");
Get(ref db, "Jessy Morier");
Get(ref db, "Rufo");

UpdateIdade(ref db, "Rufo", 10);
UpdateIdade(ref db, "Le Raf", 8);


//Delete(ref db, "Luis Rojas");
//Delete(ref db, "Jessy Morier");









