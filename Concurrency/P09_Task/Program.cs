namespace P09_Task
{
    public class Program
    {
        static int GetRandomNumber()
        {
            Thread.Sleep(1000);
            int randomNumber = (new Random()).Next(1, 100);
            Console.WriteLine($" - GetRandomNumber: The random number is {randomNumber}");
            return randomNumber;
        }

        static int DummyMethod(int n)
        {
            Console.WriteLine(" - DummyMethodWithParameters:...");
            Thread.Sleep(2000);
            Console.WriteLine($" - DummyMethodWithParameters: n={n}");
            Console.WriteLine(" - DummyMethodWithParameters:...done");
            return n;
        }

        static void Main(string[] args)
        {
            int dummyInputValue = 15;
            //var task1 = new Task(() => DummyMethod(dummyInputValue));
            //task1.Start();

            var task2 = Task.Run(() => DummyMethod(dummyInputValue));
            

            Console.WriteLine("Start the main program...");
            Console.WriteLine($" - Task.Run: Result = {task2.Result}");
            //Console.ReadLine();
        }
    }
}
