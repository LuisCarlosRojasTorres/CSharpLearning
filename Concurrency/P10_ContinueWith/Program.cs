using System.Threading.Tasks;

namespace P10_ContinueWith
{
    public class Program
    {
        static int GetRandomNumber()
        {
            Console.WriteLine($" - GetRandomNumber");
            Thread.Sleep(1000);
            int randomNumber = (new Random()).Next(1, 100);
            Console.WriteLine($" - GetRandomNumber: The random number is {randomNumber}");
            Console.WriteLine($" - GetRandomNumber... done!");
            return randomNumber;
        }

        static int DummyMethod(int n)
        {
            int n2 = n * n;
            Console.WriteLine(" - DummyMethodWithParameters:...");
            Thread.Sleep(5000);
            Console.WriteLine($" - DummyMethodWithParameters: n*n={n2}");
            Console.WriteLine(" - DummyMethodWithParameters:...done");
            return n2;
        }

        static void Main(string[] args)
        {
            var result = 0;
            
            /*
            var task = Task.Run(() => DummyMethod(10));
            
            task.ContinueWith((task) =>
            {
                Console.WriteLine(" - TaskContinuation");
                Thread.Sleep(3000);
                result = task.Result;
                Console.WriteLine(" - TaskContinuation...done");
            });
            */

   
            var task = Task.Run(() => DummyMethod(10))
                .ContinueWith((task) =>
                {
                    Console.WriteLine(" - TaskContinuation");
                    Thread.Sleep(3000);
                    result = task.Result;
                    Console.WriteLine(" - TaskContinuation...done");
                });
            
            while (result == 0)
            {
                Console.WriteLine("Main Thread: Waiting for the result...");
                Thread.Sleep(1000);                
            }

            Console.WriteLine($"Main Thread: result = {result}");
        }
    }
}
