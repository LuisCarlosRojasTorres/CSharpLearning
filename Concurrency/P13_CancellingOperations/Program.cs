using System.Threading.Tasks;

namespace P13_CancellingOperations
{
    internal class Program
    {
        static void DummyMethod(CancellationToken token)
        {
            int counter = 0;
            while (!token.IsCancellationRequested) 
            {
                Thread.Sleep(1000);
                Console.WriteLine($" - Second: {counter}"); 
                counter++;
            }
        
        }
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new();
            
            var task = Task.Run(() => DummyMethod(cts.Token));

            Console.WriteLine("Press 'c' to cancel.");
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.KeyChar == 'c')
                {
                    if (task.Status == TaskStatus.Running)
                    {
                        cts.Cancel();
                        Console.WriteLine("Canceling the task...");
                        break;
                    }
                }
                // quit if the task has been completed
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    break;
                }
            }
        }
    }
}
