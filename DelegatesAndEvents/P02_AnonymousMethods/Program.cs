namespace P02_AnonymousMethods
{
    delegate int DummyDelegate(int x);

    class Program
    {
        public static void Main(string[] args)
        {
            DummyDelegate dummyDelegate = delegate (int x) { return x * x; };

            Console.WriteLine(dummyDelegate(5)); // 100
        }
    }

}
