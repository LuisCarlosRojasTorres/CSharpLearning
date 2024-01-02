namespace P04b_ManyEvents
{
    internal class Program
    {
        delegate void Dummy1EventHandler();
        delegate int Dummy2EventHandler(int a, int b);

        class DummyPublisher
        {
            // An Event has a delegate encapsulated
            public event Dummy1EventHandler? dummy1EventHandler;
            public event Dummy2EventHandler? dummy2EventHandler;

            public void DummyMethod1()
            {
                Console.WriteLine(" - DummyPublisher: DummyMethod1");

                if (dummy1EventHandler != null)
                {
                    dummy1EventHandler();
                }
            }

            public void DummyMethod2(int a, int b)
            {
                Console.WriteLine(" - DummyPublisher: DummyMethod2");

                if (dummy2EventHandler != null)
                {
                    dummy2EventHandler(a,b);
                }
            }
        }

        class DummySubscriber
        {
            public static void SubscriberMethod1()
            {
                Console.WriteLine(" - DummySubscriber: SubscriberMethod1");
            }

            public static int SubscriberMethod2(int a, int b)
            {
                Console.WriteLine(" - DummySubscriber: SubscriberMethod2 with data");
                Console.WriteLine($" - DummySubscriber: a = {a}");
                Console.WriteLine($" - DummySubscriber: b = {b}");
                Console.WriteLine($" - DummySubscriber: result = {a+b}");
                return a + b;
            }
        }

        static void Main(string[] args)
        {
            var dummy = new DummyPublisher();

            dummy.dummy1EventHandler += DummySubscriber.SubscriberMethod1;
            dummy.dummy2EventHandler += DummySubscriber.SubscriberMethod2;
            
            dummy.DummyMethod1();
            int var1 = 5, var2 = 7;
            dummy.DummyMethod2(var1, var2);
        }
    }
}
