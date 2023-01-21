// See https://aka.ms/new-console-template for more information
var bgThread = new Thread((object? data) =>
{
    if (data is null) return;
    int counter = 0;
    var result = int.TryParse(data.ToString(), out int maxCount);

    if (!result) return;

    while (counter < maxCount)
    {
        bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
        Thread.Sleep(100);
        counter++;
    }
});

bgThread.Start(4); // This limits the iteration to 3 times!

for (int i = 0; i < 4; i++)
{
    Console.WriteLine("Main thread working...");
    Thread.Sleep(250);
}
Console.WriteLine("Done");
Console.ReadKey();
