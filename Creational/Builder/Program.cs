using BuilderPattern;
using System;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
/*
    ### Explanation
    1. * *Product(`Product`) * *: Represents the complex object that is to be constructed.
    2. **Builder Interface (`IBuilder`)**: Declares the methods for creating the different parts of the product.
    3. **Concrete Builders (`ConcreteBuilder1`, `ConcreteBuilder2`)**: Implement the methods defined in the builder interface to construct and assemble the parts of the product.
    4. **Director (`Director`)**: Constructs the product using the builder interface. It is responsible for the overall construction process.
    5. * *Client Code(`Program`) * *: Demonstrates how to use the director and builder to construct different representations of the product.
*/
namespace BuilderPattern
{
    // Product
    public class Product
    {
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string PartC { get; set; }

        public void Show()
        {
            Console.WriteLine($"PartA: {PartA}");
            Console.WriteLine($"PartB: {PartB}");
            Console.WriteLine($"PartC: {PartC}");
        }
    }

    // Builder Interface
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
        Product GetResult();
    }

    // Concrete Builder 1
    public class ConcreteBuilder1 : IBuilder
    {
        private Product _product = new Product();

        public void BuildPartA()
        {
            _product.PartA = "PartA1";
        }

        public void BuildPartB()
        {
            _product.PartB = "PartB1";
        }

        public void BuildPartC()
        {
            _product.PartC = "PartC1";
        }

        public Product GetResult()
        {
            return _product;
        }
    }

    // Concrete Builder 2
    public class ConcreteBuilder2 : IBuilder
    {
        private Product _product = new Product();

        public void BuildPartA()
        {
            _product.PartA = "PartA2";
        }

        public void BuildPartB()
        {
            _product.PartB = "PartB2";
        }

        public void BuildPartC()
        {
            _product.PartC = "PartC2";
        }

        public Product GetResult()
        {
            return _product;
        }
    }

    // Director
    public class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            // Construct and display Product using ConcreteBuilder1
            IBuilder builder1 = new ConcreteBuilder1();
            director.Construct(builder1);
            Product product1 = builder1.GetResult();
            Console.WriteLine("Product built using ConcreteBuilder1:");
            product1.Show();

            // Construct and display Product using ConcreteBuilder2
            IBuilder builder2 = new ConcreteBuilder2();
            director.Construct(builder2);
            Product product2 = builder2.GetResult();
            Console.WriteLine("Product built using ConcreteBuilder2:");
            product2.Show();
        }
    }
}
