namespace P11_HandlingExceptions
{
    internal class Program
    {
        static decimal Divide(decimal a, decimal b)
        {
            Thread.Sleep(1000);

            return a / b;
        }

        static void Main(string[] args)
        {
            try
            {
                var task = Task.Run(() => Divide(10, 0));
                var result = task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Flatten().Handle(e =>
                {
                    if (e is DivideByZeroException)
                    {
                        Console.WriteLine(e.Message);
                        return true;
                    }
                    else
                    {
                        throw e;
                    }
                });
            }
        }
    }
}
