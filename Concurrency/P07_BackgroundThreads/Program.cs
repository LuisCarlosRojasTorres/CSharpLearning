namespace P07_BackgroundThreads
{
    public class Program
    {
        static void DummyMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(" - DummyMethod in Background thread running...");
            }
        }

        static void Main(string[] args)
        {
            var dummyThread = new Thread(DummyMethod);
            dummyThread.IsBackground = true;
            dummyThread.Start();

            // Do some work in the main thread
            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("Main thread running...");
            }
        }
    }
}
