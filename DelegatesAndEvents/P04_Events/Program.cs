using System;

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

    class DummyEventArgs : EventArgs
    {
        public string? stringVar { get; set; }
        public int intVar { get; set; }
    }

    class DummyPublisherWithData
    {
        //The delegate declaration follows the signature from the previous section
        public event EventHandler<DummyEventArgs>? dummyEvent;

        //THe Dummy method now has parameters
        public void DummyMethod(string dummyString, int dummyInt)
        {
            Console.WriteLine(" - DummyMethod with data");

            // If there are methods referenced in the delegate:
            // Otherwise nothing happens
            if (dummyEvent != null)
            {
                dummyEvent(this, new DummyEventArgs { stringVar = dummyString, intVar = dummyInt });
            }
        }
    }

    class DummySubscriberWithData
    {
        //Same EventHandler signature
        public static void SubscriberMethod(object sender, DummyEventArgs e)
        {
            Console.WriteLine($" - SubscriberMethod");
            Console.WriteLine($"    - stringVar field: {e.stringVar}");
            Console.WriteLine($"    - intVar field: {e.intVar}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var dummyPublisher = new DummyPublisherWithData();

            // Reference to EventHandler delegate
            dummyPublisher.dummyEvent += DummySubscriberWithData.SubscriberMethod!;

            //Raise the event withouth
            //dummyPublisher.DummyMethod();
            //This will print:
            // - DummyMethod
            // -SubscriberMethod

            //Raise the event with data
            int dummyInt = 10;
            string dummyString = "DummyString value";
            dummyPublisher.DummyMethod(dummyString, dummyInt);
            //This will print:
            //-DummyMethod with data
            //-SubscriberMethod
            //- stringVar field: DummyString value
            //-intVar field: 10

        }
    }


}
