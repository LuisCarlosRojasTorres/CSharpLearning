namespace P11_HandlingExceptions
{
    public class Program
    {
        static decimal Divide(decimal inputUp, decimal inputDown)
        {
            Thread.Sleep(1000);

            return inputUp / inputDown;
        }

        static void Main(string[] args)
        {
            try
            {
                var task = Task.Run(() => Divide(5, 0));
                var result = task.Result;
            }
            catch (AggregateException ae)
            {   
                var innerExceptions = ae.Flatten().InnerExceptions;

                foreach (var e in innerExceptions) 
                {
                    if (e is DivideByZeroException)
                    {
                        Console.WriteLine($" - InnerExceptions: { e.Message}");  
                    }
                    else
                    {
                        throw e;
                    }
                }
                /*
                ae.Flatten().Handle(e =>
                {
                    if (e is DivideByZeroException)
                    {
                        Console.WriteLine($" - Handle: { e.Message}");  
                        return true;
                    }
                    else
                    {
                        throw e;
                    }
                });
                */
            }
        }
    }
}
