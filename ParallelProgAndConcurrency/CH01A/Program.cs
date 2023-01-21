﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var bgThread = new Thread(() =>
{
    while (true)
    {
        bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        Console.WriteLine($"Is network available? Answer:{isNetworkUp}");
        Thread.Sleep(200);
    }
});

bgThread.IsBackground = true; // Background property
bgThread.Start();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Main thread working...");
    Task.Delay(10);
}

Console.WriteLine("Done");
Console.ReadKey();