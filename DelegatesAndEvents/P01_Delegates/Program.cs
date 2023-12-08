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

//Use1: Delegates can be initialize like this:
DummyDelegate dummyDelegate = new DummyDelegate(SayHello);
dummyDelegate.Invoke("Rufo");

//Use1: Delegates can be initialize like this:
DummyDelegate dummyDelegate2 = SayBye;
dummyDelegate2("Rufo");

//Use2: Methods can take delegates as arguments.
var names = new List<string> { "Luis", "Jessyca", "Lobo", "Rufa"};
Greetings(names, SayHello);

/*
 Output:

 - Hi Rufo
 - Bye Rufo
 - Hi Luis
 - Hi Jessyca
 - Hi Lobo
 - Hi Rufa
 */


