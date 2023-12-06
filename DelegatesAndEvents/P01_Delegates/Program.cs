// See https://aka.ms/new-console-template for more information

// This method has same signature as DummyDelegate
static void SayHello(string x)
{
    Console.WriteLine($" - Hi {x}");
}

// This method has same signature as DummyDelegate
static void SayBye(string x)
{
    Console.WriteLine($" - Bye {x}");
}

//This method has a DummyDelegate as argument so it can receive SayHello
// and SayBye methods as arguments.
static void Greetings(List<string> names, DummyDelegate dummyDelegate)
{
    var results = new List<int>();

    foreach (var name in names)
    {
        dummyDelegate(name);        
    }    
}

//Driver program
var names = new List<string> { "Luis", "Jessyca", "Lobo", "Rufa"};

Greetings(names, SayHello);
