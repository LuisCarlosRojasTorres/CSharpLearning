namespace P14b_AutoResetEventWithTasks
{
    public class Program
    {
        static void Main()
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

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
                        autoResetEvent.WaitOne();
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
                    if (counter % 10 == 0)
                    {
                        Console.WriteLine($" - Thread2: Set AutoResetEvent for Thread1 every 10 seconds");
                        autoResetEvent.Set();
                        counter = 1;
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
