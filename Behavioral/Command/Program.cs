using System;
/*
    ### Explanation

    1. **ICommand**: The `ICommand` interface declares the `Execute` method.
    2. **ConcreteCommand**: The `ConcreteCommand` class implements the `ICommand` interface and defines the binding between a receiver and an action.
    3. **Receiver**: The `Receiver` class knows how to perform the operations needed to carry out a request.
    4. **Invoker**: The `Invoker` class asks the command to carry out the request. It maintains a reference to the command object.
    5. **Program**: The client code creates the receiver, command, and invoker. It sets the command for the invoker and executes it.
*/
namespace CommandPattern
{
    // ICommand interface
    public interface ICommand
    {
        void Execute();
    }

    // ConcreteCommand class
    public class ConcreteCommand : ICommand
    {
        private readonly Receiver _receiver;

        public ConcreteCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Action();
        }
    }

    // Receiver class
    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver: Executing action.");
        }
    }

    // Invoker class
    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            // Create receiver
            var receiver = new Receiver();

            // Create command and set its receiver
            var command = new ConcreteCommand(receiver);

            // Create invoker and associate it with the command
            var invoker = new Invoker();
            invoker.SetCommand(command);

            // Execute command via invoker
            invoker.ExecuteCommand();
        }
    }
}
