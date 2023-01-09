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
}

static void Get(ref LiteDatabase db, string nome)
{
    if (db.CollectionExists("Pessoa")) 
    {
        var foundOne = db.GetCollection<Pessoa>().FindOne(x => x.Nome == nome);
        Console.WriteLine($" > GET, Id: {foundOne.Id} , Nome: {foundOne.Nome} , Idade: {foundOne.Idade}");
    }
}

static void UpdateIdade (ref LiteDatabase db, string nome, int idade)
{
    if (db.CollectionExists("Pessoa"))
    {
        var foundOne = db.GetCollection<Pessoa>().FindOne(x => x.Nome == nome);
        foundOne.Idade = idade;
        db.GetCollection<Pessoa>().Update(foundOne);
        Console.WriteLine($" > UPDATE, Id: {foundOne.Id} , Nome: {foundOne.Nome} , Idade: {foundOne.Idade}");
    }
}

static void Delete(ref LiteDatabase db, string nome)
{
    if (db.CollectionExists("Pessoa"))
    {
        var foundOne = db.GetCollection<Pessoa>().FindOne(x => x.Nome == nome);
        Console.WriteLine($" > DELETED, Id: {foundOne.Id} , Nome: {foundOne.Nome} , Idade: {foundOne.Idade}");
        db.GetCollection<Pessoa>().Delete(foundOne.Id);
        // Deleted
    }
}

LiteDatabase db = CreateDB();
//Add(ref db, "Luis Rojas", 34);
///Add(ref db, "Jessy Morier", 32);
Add(ref db, "Rufo", 10);
Get(ref db, "Rufo");
UpdateIdade(ref db, "Rufo", 32);
Get(ref db, "Rufo");
Delete(ref db, "Rufo");









