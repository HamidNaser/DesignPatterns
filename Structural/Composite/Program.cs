using System;
using System.Collections.Generic;
/*
    ### Explanation

    1. **Component Interface (`IComponent`)**: This interface defines the method `Operation()` that both `Leaf` and `Composite` classes must implement.
    2. **Leaf Class (`Leaf`)**: This class represents leaf objects that do not have any children. It implements the `Operation()` method.
    3. **Composite Class (`Composite`)**: This class represents composite objects that can have children (both `Leaf` and `Composite` objects). It maintains a list of child components and implements the `Operation()` method by calling the `Operation()` method of its children.
    4. **Client Code (`Program`)**: Demonstrates how to create a part-whole hierarchy using the Composite pattern. It creates leaf and composite objects, adds leaf objects to composite objects, and performs operations on the tree structure.
*/
namespace CompositePattern
{
    // Component Interface
    public interface IComponent
    {
        void Operation();
    }

    // Leaf Class
    public class Leaf : IComponent
    {
        private string _name;

        public Leaf(string name)
        {
            _name = name;
        }

        public void Operation()
        {
            Console.WriteLine($"Leaf {_name} operation performed.");
        }
    }

    // Composite Class
    public class Composite : IComponent
    {
        private string _name;
        private List<IComponent> _children = new List<IComponent>();

        public Composite(string name)
        {
            _name = name;
        }

        public void Add(IComponent component)
        {
            _children.Add(component);
        }

        public void Remove(IComponent component)
        {
            _children.Remove(component);
        }

        public void Operation()
        {
            Console.WriteLine($"Composite {_name} operation performed.");

            foreach (var child in _children)
            {
                child.Operation();
            }
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            // Creating leaf nodes
            Leaf leaf1 = new Leaf("1");
            Leaf leaf2 = new Leaf("2");
            Leaf leaf3 = new Leaf("3");

            // Creating composite nodes
            Composite composite1 = new Composite("Composite 1");
            Composite composite2 = new Composite("Composite 2");

            // Building the tree structure
            composite1.Add(leaf1);
            composite1.Add(leaf2);

            composite2.Add(composite1);
            composite2.Add(leaf3);

            // Performing operations on the tree
            composite2.Operation();
        }
    }
}
