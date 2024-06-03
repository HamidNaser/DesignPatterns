using System;
/*
    Explanation

    1. **Implementor Interface (`IImplementor`)**: This interface defines the method `OperationImp()` that concrete implementations need to provide.
    2. **Concrete Implementors (`ConcreteImplementorA`, `ConcreteImplementorB`)**: These classes implement the `IImplementor` interface with their own specific behavior for `OperationImp()`.
    3. **Abstraction (`Abstraction`)**: This abstract class defines the interface for the abstraction and maintains a reference to an implementor object. It declares an abstract method `Operation()` that subclasses must implement.
    4. **Refined Abstraction (`RefinedAbstraction`)**: This class extends `Abstraction` and implements the `Operation()` method by delegating the call to the implementor's `OperationImp()` method.
    5. **Client Code (`Program`)**: Demonstrates how to use the Bridge pattern by creating instances of `ConcreteImplementorA` and `ConcreteImplementorB`, passing them to `RefinedAbstraction`, and calling the `Operation()` method.
*/

namespace BridgePattern
{
    // Implementor Interface
    public interface IImplementor
    {
        void OperationImp();
    }

    // Concrete Implementor A
    public class ConcreteImplementorA : IImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("ConcreteImplementorA OperationImp");
        }
    }

    // Concrete Implementor B
    public class ConcreteImplementorB : IImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("ConcreteImplementorB OperationImp");
        }
    }

    // Abstraction
    public abstract class Abstraction
    {
        protected IImplementor _implementor;

        protected Abstraction(IImplementor implementor)
        {
            _implementor = implementor;
        }

        public abstract void Operation();
    }

    // Refined Abstraction
    public class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(IImplementor implementor) : base(implementor)
        {
        }

        public override void Operation()
        {
            _implementor.OperationImp();
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            IImplementor implementorA = new ConcreteImplementorA();
            Abstraction abstractionA = new RefinedAbstraction(implementorA);
            abstractionA.Operation();

            IImplementor implementorB = new ConcreteImplementorB();
            Abstraction abstractionB = new RefinedAbstraction(implementorB);
            abstractionB.Operation();
        }
    }
}
