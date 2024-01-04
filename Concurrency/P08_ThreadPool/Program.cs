namespace P08_ThreadPool
{
    public class Program
    {
        static void DummyMethod(int n)
        {
            Console.WriteLine(" - DummyMethodWithParameters...");
            Thread.Sleep(2000);
            Console.WriteLine($" - DummyMethodWithParameters: n={n}");
            Console.WriteLine(" - DummyMethodWithParameters...done");
        }

        static void Main(string[] args)
        {
            ParameterizedThreadStart parameterizedThreadStart = (object? o) => {
                Console.WriteLine(" - DummyMethodWithParameters...");
                Thread.Sleep(2000);
                Console.WriteLine($" - DummyMethodWithParameters: o={o}");
                Console.WriteLine(" - DummyMethodWithParameters...done");
            };

            int value = 10;
            ThreadPool.QueueUserWorkItem(input =>
                {
                    parameterizedThreadStart(value);
                    //DummyMethod(value);
                }
            );

            Console.ReadLine();
        }
    }
}
