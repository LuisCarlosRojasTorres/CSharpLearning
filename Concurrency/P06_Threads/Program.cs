using System.Diagnostics;

namespace P06_Threads
{
    class Program
    {
        static void DummyMethod()
        {
            Console.WriteLine(" - DummyMethod...");
            Thread.Sleep(2000);
            Console.WriteLine(" - DummyMethod...done");
        }
        static void DummyMethodWithParameters(object o)
        {
            Console.WriteLine(" - DummyMethodWithParameters...");
            Thread.Sleep(2000);
            Console.WriteLine($" - DummyMethodWithParameters: o={o}");
            Console.WriteLine(" - DummyMethodWithParameters...done");
        }

        static void Main(string[] args)
        {
            ThreadStart startNoParam = DummyMethod;
            ParameterizedThreadStart startParam= DummyMethodWithParameters!;
            var watch = Stopwatch.StartNew();

            var t1 = new Thread(startNoParam);
            var t2 = new Thread(startParam);


            // start both threads
            t1.Start();
            t2.Start(5);

            // wait for both threads completed
            t1.Join();
            t2.Join();

            watch.Stop();
            Console.WriteLine($"It took {watch.Elapsed.Seconds} second(s) to complete.");
        }
    }
}
