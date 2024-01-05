namespace P12_AwaitAsync
{
    internal class Program
    {
        
        static async Task DummyMethod(string filename)
        {
            Console.WriteLine(" - DummyMethod: ");            
            var lines = await File.ReadAllLinesAsync(filename);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(" - DummyMethod:... done!");
        }

        static async Task Main()
        {
            Console.WriteLine(" - Main Thread: ");
            await DummyMethod("readme.txt");
            Console.WriteLine(" - Main Thread:...done!");            
        }
    }
}
