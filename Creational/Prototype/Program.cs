using PrototypePattern;
using System;

/*
    Explanation
    1. * *Prototype(`Prototype`) * *: This abstract class declares the `Clone` method that will be used to copy objects.
    2. **Concrete Prototypes (`ConcretePrototype1`, `ConcretePrototype2`)**: These classes inherit from `Prototype` and implement the `Clone` method using `MemberwiseClone()`, which creates a shallow copy of the object.
    3. **Client Code (`Program`)**: Demonstrates creating instances of the concrete prototypes, cloning them, modifying the clones, and displaying the original and cloned objects.
*/
namespace PrototypePattern
{
    // Prototype
    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    // Concrete Prototype 1
    public class ConcretePrototype1 : Prototype
    {
        public string Data { get; set; }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public void Show()
        {
            Console.WriteLine($"ConcretePrototype1: Data = {Data}");
        }
    }

    // Concrete Prototype 2
    public class ConcretePrototype2 : Prototype
    {
        public int Number { get; set; }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public void Show()
        {
            Console.WriteLine($"ConcretePrototype2: Number = {Number}");
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of ConcretePrototype1
            ConcretePrototype1 prototype1 = new ConcretePrototype1 { Data = "Prototype 1 Data" };
            // Clone the instance
            ConcretePrototype1 clone1 = (ConcretePrototype1)prototype1.Clone();
            // Modify the clone
            clone1.Data = "Modified Prototype 1 Data";

            // Display both the original and the clone
            prototype1.Show();
            clone1.Show();
            
            // Create an instance of ConcretePrototype2
            ConcretePrototype2 prototype2 = new ConcretePrototype2 { Number = 42 };
            // Clone the instance
            ConcretePrototype2 clone2 = (ConcretePrototype2)prototype2.Clone();
            // Modify the clone
            clone2.Number = 99;

            // Display both the original and the clone
            prototype2.Show();
            clone2.Show();
            
        }
    }
}

