using System;

namespace FactoryMethodPattern
{
    // Product Interface
    public interface IProduct
    {
        void Operation();
    }

    // Concrete Products
    public class ConcreteProductA : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("Operation from ConcreteProductA");
        }
    }

    public class ConcreteProductB : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("Operation from ConcreteProductB");
        }
    }

    // Creator Abstract Class
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public void SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            product.Operation();
        }
    }

    // Concrete Creators
    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            // Use the ConcreteCreatorA to create a ConcreteProductA
            Creator creatorA = new ConcreteCreatorA();
            creatorA.SomeOperation();

            // Use the ConcreteCreatorB to create a ConcreteProductB
            Creator creatorB = new ConcreteCreatorB();
            creatorB.SomeOperation();
        }
    }
}
