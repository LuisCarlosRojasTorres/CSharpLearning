namespace P15b_ManualResetEventSlimTasks
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
                        Console.WriteLine($" - Task1: Second {counter}");
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($" - Task1: WaitOne {counter}");
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
                            Console.WriteLine($" - Task2: Reset ManualResetEventSlim for Thread1 every 20 seconds");
                            manualResetEventSlim.Reset();
                            counter = 1;
                        }
                        else
                        {
                            Console.WriteLine($" - Task2: Set ManualResetEventSlim for Thread1 every 10 seconds");
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

            // Task Version
            var task1 = Task.Run(DummyMethod1);
            var task2 = Task.Run(DummyMethod2);
            Console.Read();
        }
    }
}
