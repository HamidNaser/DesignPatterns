using System;
/*
    ### Explanation

    1. **Handler**: This abstract class defines the `SetSuccessor` method for setting the next handler in the chain and the `HandleRequest` method for handling requests.
    2. **ConcreteHandler1, ConcreteHandler2, ConcreteHandler3**: These classes inherit from the `Handler` abstract class and provide the actual handling logic for specific requests.
    3. **Program**: The client code creates the chain of handlers and passes various requests through the chain. Each handler processes the request if it can; otherwise, it forwards the request to the next handler in the chain. If no handler can process the request, it simply gets ignored.
*/
namespace ChainOfResponsibilityPattern
{
    // Abstract Handler class
    public abstract class Handler
    {
        protected Handler _successor;

        public void SetSuccessor(Handler successor)
        {
            _successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    // Concrete Handler 1
    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 1)
            {
                Console.WriteLine("ConcreteHandler1 handled request " + request);
            }
            else if (_successor != null)
            {
                _successor.HandleRequest(request);
            }
        }
    }

    // Concrete Handler 2
    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 2)
            {
                Console.WriteLine("ConcreteHandler2 handled request " + request);
            }
            else if (_successor != null)
            {
                _successor.HandleRequest(request);
            }
        }
    }

    // Concrete Handler 3
    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 3)
            {
                Console.WriteLine("ConcreteHandler3 handled request " + request);
            }
            else if (_successor != null)
            {
                _successor.HandleRequest(request);
            }
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            // Create handlers
            Handler handler1 = new ConcreteHandler1();
            Handler handler2 = new ConcreteHandler2();
            Handler handler3 = new ConcreteHandler3();

            // Set the chain of responsibility
            handler1.SetSuccessor(handler2);
            handler2.SetSuccessor(handler3);

            // Generate and process requests
            int[] requests = { 1, 2, 3, 4 };

            foreach (var request in requests)
            {
                handler1.HandleRequest(request);
            }
        }
    }
}
