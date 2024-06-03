using System;
/*
    ### Explanation

    1. **ISubject**: This interface declares the `Request` method that both `RealSubject` and `Proxy` implement.
    2. **RealSubject**: This class contains the actual business logic and implements the `Request` method.
    3. **Proxy**: This class also implements the `ISubject` interface. It holds a reference to a `RealSubject` instance and controls access to it. The `Request` method in the Proxy performs lazy initialization of the `RealSubject` and then delegates the call to it.
    4. **Client Code**: The client interacts with the `ISubject` interface, and the Proxy controls access to the `RealSubject`.
*/
namespace ProxyPattern
{
    // Subject interface
    public interface ISubject
    {
        void Request();
    }

    // RealSubject class
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    // Proxy class
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public void Request()
        {
            // Lazy initialization of RealSubject
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            ISubject proxy = new Proxy();
            proxy.Request();
        }
    }
}
