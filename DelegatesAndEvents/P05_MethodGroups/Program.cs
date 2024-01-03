namespace P05_MethodGroups
{
    class Calculator
    {
    public static int Add(int a, int b) => a + b;
    public static double Add(double a, double b) => a + b;
    }

    class Program
    {
        delegate int DummyDelegate(int a, int b);

        public static void Main(string[] args)
        {
        //This signature match with first Add method
        
        //Method group assigned to delegate
        DummyDelegate dummy = Calculator.Add;

        //The Add method that best batch the delegate signature is referenced!        
        var result = dummy(10, 20);

        Console.WriteLine(result);
        }
    }
}
