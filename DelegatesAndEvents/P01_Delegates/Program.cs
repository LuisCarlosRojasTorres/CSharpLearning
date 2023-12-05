// See https://aka.ms/new-console-template for more information


static void SayHello(string x)
{
    Console.WriteLine($" - Hi {x}");
}

static void SayBye(string x)
{
    Console.WriteLine($" - Bye {x}");
}

static void Greetings(List<string> names, DummyDelegate dummyDelegate)
{
    var results = new List<int>();

    foreach (var name in names)
    {
        dummyDelegate(name);        
    }    
}

var names = new List<string> { "Luis", "Jessyca", "Lobo", "Rufa"};

Greetings(names, SayHello);
