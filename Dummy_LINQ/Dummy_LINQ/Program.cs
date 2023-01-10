// See https://aka.ms/new-console-template for more information
var customers = new[]
{
    new{ CustomerID = 1, FirstName = "Lala", LastName = "Papata", Company = "Facabaaka"},
    new{ CustomerID = 2, FirstName = "Lele", LastName = "Pepete", Company = "Fecebeeke"},
    new{ CustomerID = 3, FirstName = "Lili", LastName = "Pipiti", Company = "Ficibiiki"},
    new{ CustomerID = 4, FirstName = "Lolo", LastName = "Popoto", Company = "Focobooko"},
    new{ CustomerID = 5, FirstName = "Lulu", LastName = "Puputu", Company = "Fucubuuku"},
    new{ CustomerID = 6, FirstName = "Lalo", LastName = "Papota", Company = "Facabaaka"},
    new{ CustomerID = 7, FirstName = "Lelo", LastName = "Pepote", Company = "Fecebeeke"},
    new{ CustomerID = 8, FirstName = "Lila", LastName = "Pipati", Company = "Ficibiiki"},
    new{ CustomerID = 9, FirstName = "Lola", LastName = "Popato", Company = "Focobooko"},
    new{ CustomerID =10, FirstName = "Lula", LastName = "Pupatu", Company = "Fucubuuku"}
};

var addresses = new[]
{
    new{ Company = "Facabaaka", City = "Lama"},
    new{ Company = "Fecebeeke", City = "Leme"},
    new{ Company = "Ficibiiki", City = "Limi"},
    new{ Company = "Focobooko", City = "Lomo"},
    new{ Company = "Fucubuuku", City = "Lumu"}
};
// SELECT
/*
IEnumerable<string> customerFirstNames = customers.Select(customer => customer.FirstName);
foreach (string name in customerFirstNames)
{ 
    Console.WriteLine(name);
}
*/
/*
var customerFullNames = customers.Select(cust => new 
    {
        FirstName = cust.FirstName,
        LastName = cust.LastName
    });
foreach (var p in customerFullNames)
{
    Console.WriteLine($" > {p.FirstName} , {p.LastName}");
}
*/
// FILTERING
/*
var customerFullNames = customers.Where(p => String.Equals(p.Company, "Facabaaka"))
                                 .Select(cust => new
                                    {
                                        FirstName = cust.FirstName,
                                        LastName = cust.LastName
                                    });
foreach (var p in customerFullNames)
{
    Console.WriteLine($" > {p.FirstName} , {p.LastName}");
}
*/
// ORDERING
/*
var customerFullNames = customers.OrderBy(x => x.LastName).Select(cust => new
{
    FirstName = cust.FirstName,
    LastName = cust.LastName
});
foreach (var p in customerFullNames)
{
    Console.WriteLine($" > {p.FirstName} , {p.LastName}");
}
*/
// GROUPING