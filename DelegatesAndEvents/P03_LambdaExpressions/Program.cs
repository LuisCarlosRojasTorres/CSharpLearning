namespace P03_LambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var square = static (int x) => x * x;

            Console.WriteLine(" - Expression Lambda:" + square(5));

            var cube = static (int x) => x * x * x;

            Console.WriteLine(" - Statement Lambda:" + cube(5));
        }
    }
}
