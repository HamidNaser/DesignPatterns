using System;
using System.Collections.Generic;
/*
    ### Explanation

    1. **Flyweight**: This class contains intrinsic state, which is shared among multiple objects. It also has an `Operation` method that takes extrinsic state as a parameter.
    2. **FlyweightFactory**: This class manages a pool of Flyweight objects. When a Flyweight is requested, it either returns an existing one or creates a new one if it doesn't already exist.
    3. **Client Code**: Demonstrates creating and using Flyweight objects through the FlyweightFactory. It shows how multiple objects can share the same Flyweight instance, reducing memory usage.
*/
namespace FlyweightPattern
{
    // Flyweight class
    public class Flyweight
    {
        private string _intrinsicState;

        public Flyweight(string intrinsicState)
        {
            _intrinsicState = intrinsicState;
        }

        public void Operation(string extrinsicState)
        {
            Console.WriteLine($"Intrinsic State: {_intrinsicState}, Extrinsic State: {extrinsicState}");
        }
    }

    // Flyweight Factory class
    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
            {
                _flyweights[key] = new Flyweight(key);
            }
            return _flyweights[key];
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            FlyweightFactory factory = new FlyweightFactory();

            // Create and use Flyweight objects
            Flyweight flyweight1 = factory.GetFlyweight("A");
            flyweight1.Operation("First Call");

            Flyweight flyweight2 = factory.GetFlyweight("B");
            flyweight2.Operation("Second Call");

            Flyweight flyweight3 = factory.GetFlyweight("A");
            flyweight3.Operation("Third Call");

            // Demonstrating that flyweight1 and flyweight3 are the same instance
            Console.WriteLine(Object.ReferenceEquals(flyweight1, flyweight3)); // True
        }
    }
}
