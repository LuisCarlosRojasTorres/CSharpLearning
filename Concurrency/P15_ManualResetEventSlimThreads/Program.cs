namespace P15_ManualResetEventSlimThreads
{
    internal class Program
    {
        static void Main()
        {
            ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim(false);

            void DummyMethod1()
            {
                int counter = 1;
                while (true)
                {
                    Thread.Sleep(1000);
                    if (counter % 5 != 0)
                    {
                        Console.WriteLine($" - Thread1: Second {counter}");
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($" - Thread1: WaitOne {counter}");
                        manualResetEventSlim.Wait();
                        counter = 1;
                    }
                }
            }

            void DummyMethod2()
            {
                int counter = 1;
                while (true)
                {
                    Thread.Sleep(1000);
                    if (counter % 11 == 0)
                    {
                        if (counter % 22 == 0)
                        {
                            Console.WriteLine($" - Thread2: Reset ManualResetEventSlim for Thread1 every 20 seconds");
                            manualResetEventSlim.Reset();
                            counter = 1;
                        }
                        else 
                        {
                            Console.WriteLine($" - Thread2: Set ManualResetEventSlim for Thread1 every 10 seconds");
                            manualResetEventSlim.Set();
                            counter++;
                        }
                    }
                    else
                    {
                        counter++;
                    }                    
                }
            }

            // Thread Version  
            var t1 = new Thread(DummyMethod1);
            var t2 = new Thread(DummyMethod2);

            t1.Start();
            t2.Start();            
        }
    }
}
