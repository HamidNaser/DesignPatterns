using System;
/*
    Explanation

    1. **Target Interface (`ITarget`)**: This interface defines the method `Request()` that the client expects.
    2. **Adaptee Class (`Adaptee`)**: This class has a method `SpecificRequest()` that needs to be adapted to the `ITarget` interface.
    3. **Adapter Class (`Adapter`)**: This class implements the `ITarget` interface and internally calls the `SpecificRequest()` method of the `Adaptee`. The adapter holds a reference to an `Adaptee` object and translates the `Request()` call to a `SpecificRequest()` call.
    4. **Client Code (`Program`)**: The client creates an instance of the `Adaptee`, wraps it in an `Adapter`, and then interacts with it through the `ITarget` interface, calling `Request()` which is then translated to `SpecificRequest()`.
*/

namespace AdapterPattern
{
    // Target Interface
    public interface ITarget
    {
        void Request();
    }

    // Adaptee Class
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

    // Adapter Class
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            target.Request();
        }
    }
}
