namespace P04b_ManyEvents
{
    internal class Program
    {
        delegate void Dummy1EventHandler();
        delegate void Dummy2EventHandler();

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

            public void DummyMethod2()
            {
                Console.WriteLine(" - DummyPublisher: DummyMethod2");

                if (dummy2EventHandler != null)
                {
                    dummy2EventHandler();
                }
            }
        }

        class DummySubscriber
        {
            public static void SubscriberMethod1()
            {
                Console.WriteLine(" - DummySubscriber: SubscriberMethod1");
            }

            public static void SubscriberMethod2()
            {
                Console.WriteLine(" - DummySubscriber: SubscriberMethod2");
            }
        }

        static void Main(string[] args)
        {
            var dummy = new DummyPublisher();

            dummy.dummy1EventHandler += DummySubscriber.SubscriberMethod1;
            dummy.dummy2EventHandler += DummySubscriber.SubscriberMethod2;
            
            dummy.DummyMethod1();
            dummy.DummyMethod2();
        }
    }
}
