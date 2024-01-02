namespace P04_Events
{
    class DummyPublisher
    {
        public event EventHandler dummyEvent;

        public void DummyMethod()
        {
            Console.WriteLine(" - DummyMethod");

            // If there are methods referenced in the delegate:
            // Otherwise nothing happens
            if (dummyEvent != null)
            {
                dummyEvent(this, EventArgs.Empty);
            }
        }
    }

    class DummySubscriber
    {
        //Same EventHandler signature
        public static void SubscriberMethod(object sender, EventArgs e)
        {
            Console.WriteLine($" - SubscriberMethod");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dummyPublisher = new DummyPublisher();

            // Reference to EventHandler delegate
            dummyPublisher.dummyEvent += DummySubscriber.SubscriberMethod;

            //Raise the event
            dummyPublisher.DummyMethod();
            //This will print:
            // - DummyMethod
            // -SubscriberMethod

        }
    }


}
