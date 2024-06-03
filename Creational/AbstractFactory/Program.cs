/*
    ### Explanation
    1. * *Product Interfaces(`IProductA`, `IProductB`) * *: Define the interfaces that all concrete products must implement.
    2. **Concrete Products (`ProductA1`, `ProductA2`, `ProductB1`, `ProductB2`)**: Implement the product interfaces.
    3. **Abstract Factory Interface (`IAbstractFactory`)**: Declares the methods for creating abstract products.
    4. * *Concrete Factories(`ConcreteFactory1`, `ConcreteFactory2`) * *: Implement the abstract factory interface to create specific families of products.
    5. **Client Code (`Client`)**: Uses the abstract factory to create and use products.
    6. **Program Entry Point (`Program`)**: Demonstrates the use of the abstract factory pattern by creating instances of `Client` with different concrete factories.
*/

namespace AbstractFactoryPattern
{
    // Product A Interface
    public interface IProductA
    {
        void OperationA();
    }

    // Product B Interface
    public interface IProductB
    {
        void OperationB();
    }

    // Concrete Products for Factory1
    public class ProductA1 : IProductA
    {
        public void OperationA()
        {
            Console.WriteLine("OperationA from ProductA1");
        }
    }

    public class ProductB1 : IProductB
    {
        public void OperationB()
        {
            Console.WriteLine("OperationB from ProductB1");
        }
    }

    // Concrete Products for Factory2
    public class ProductA2 : IProductA
    {
        public void OperationA()
        {
            Console.WriteLine("OperationA from ProductA2");
        }
    }

    public class ProductB2 : IProductB
    {
        public void OperationB()
        {
            Console.WriteLine("OperationB from ProductB2");
        }
    }

    // Abstract Factory Interface
    public interface IAbstractFactory
    {
        IProductA CreateProductA();
        IProductB CreateProductB();
    }

    // Concrete Factory 1
    public class ConcreteFactory1 : IAbstractFactory
    {
        public IProductA CreateProductA() => new ProductA1();
        public IProductB CreateProductB() => new ProductB1();
    }

    // Concrete Factory 2
    public class ConcreteFactory2 : IAbstractFactory
    {
        public IProductA CreateProductA() => new ProductA2();
        public IProductB CreateProductB() => new ProductB2();
    }

    // Client Code
    class Client
    {
        private readonly IProductA _productA;
        private readonly IProductB _productB;

        public Client(IAbstractFactory factory)
        {
            _productA = factory.CreateProductA();
            _productB = factory.CreateProductB();
        }

        public void Run()
        {
            _productA.OperationA();
            _productB.OperationB();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using ConcreteFactory1:");
            Client client1 = new Client(new ConcreteFactory1());
            client1.Run();

            Console.WriteLine("\nUsing ConcreteFactory2:");
            Client client2 = new Client(new ConcreteFactory2());
            client2.Run();
        }
    }
}
