using System;
/*
    ### Explanation

    1. **Component Interface (`IComponent`)**: This interface defines the `Operation()` method that both concrete components and decorators must implement.
    2. **Concrete Component (`ConcreteComponent`)**: This class represents objects to which additional responsibilities can be attached. It implements the `Operation()` method.
    3. **Decorator (`Decorator`)**: This class maintains a reference to a component object and defines an interface that conforms to the component's interface. It implements the `Operation()` method by calling the `Operation()` method of the component it decorates.
    4. **Concrete Decorators (`ConcreteDecoratorA` and `ConcreteDecoratorB`)**: These classes extend the functionality of the component by adding behavior before or after the `Operation()` method is called.
    5. **Client Code (`Program`)**: Demonstrates how to use the Decorator pattern to add responsibilities to objects dynamically.
*/
namespace DecoratorPattern
{
    // Component Interface
    public interface IComponent
    {
        void Operation();
    }

    // Concrete Component
    public class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteComponent operation.");
        }
    }

    // Decorator
    public class Decorator : IComponent
    {
        protected IComponent _component;

        public Decorator(IComponent component)
        {
            _component = component;
        }

        public virtual void Operation()
        {
            _component.Operation();
        }
    }

    // Concrete Decorator A
    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component) { }

        public override void Operation()
        {
            base.Operation();
            AddedBehaviorA();
        }

        void AddedBehaviorA()
        {
            Console.WriteLine("ConcreteDecoratorA added behavior.");
        }
    }

    // Concrete Decorator B
    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component) { }

        public override void Operation()
        {
            base.Operation();
            AddedBehaviorB();
        }

        void AddedBehaviorB()
        {
            Console.WriteLine("ConcreteDecoratorB added behavior.");
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            IComponent component = new ConcreteComponent();
            Console.WriteLine("Basic Component:");
            component.Operation();

            IComponent decoratorA = new ConcreteDecoratorA(component);
            Console.WriteLine("\nComponent with Decorator A:");
            decoratorA.Operation();

            IComponent decoratorB = new ConcreteDecoratorB(decoratorA);
            Console.WriteLine("\nComponent with Decorator A and B:");
            decoratorB.Operation();
        }
    }
}
