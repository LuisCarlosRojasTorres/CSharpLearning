// See https://aka.ms/new-console-template for more information
var bgThread = new Thread(() =>
{
    while (true)
    {
        bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        Console.WriteLine($"Is network available? Answer:{isNetworkUp}");
        Thread.Sleep(2000);
    }
});

bgThread.IsBackground = true; // Background property
bgThread.Start();

for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Main thread working...");
    Task.Delay(millisecondsDelay: 10000);
}

Console.WriteLine("Done");
Console.ReadKey();