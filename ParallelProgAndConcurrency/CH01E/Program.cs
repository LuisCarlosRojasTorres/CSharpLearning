// See https://aka.ms/new-console-template for more information
using CH01E;

var networkingWork = new NetworkingWork();
var pingThread = new Thread(networkingWork.CheckNetworkStatus);
var ctSource = new CancellationTokenSource();
pingThread.Start(ctSource.Token);

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Loop: {i} Main thread working...");
    Thread.Sleep(100);
}
Console.WriteLine($"Loop finished");
ctSource.Cancel();
pingThread.Join();
ctSource.Dispose();
