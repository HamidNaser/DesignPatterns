using System;
using System.Collections.Generic;
/*
    ### Explanation

    1. **IIterator**: The `IIterator` interface defines methods for iterating over elements (`HasNext` to check if there are more elements, and `Next` to get the next element).
    2. **ConcreteIterator**: The `ConcreteIterator` class implements the `IIterator` interface for a specific collection type (in this case, an array). It keeps track of the current position while iterating.
    3. **IAggregate**: The `IAggregate` interface declares a method for creating an iterator.
    4. **ConcreteAggregate**: The `ConcreteAggregate` class implements the `IAggregate` interface for a specific collection type (in this case, an array). It provides a method to create an iterator over its elements.
    5. **Program**: The client code creates an instance of `ConcreteAggregate`, gets an iterator from it, and iterates over the elements using the iterator.
*/
namespace IteratorPattern
{
    // Iterator interface
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    // ConcreteIterator class
    public class ConcreteIterator<T> : IIterator<T>
    {
        private readonly T[] _collection;
        private int _position = 0;

        public ConcreteIterator(T[] collection)
        {
            _collection = collection;
        }

        public bool HasNext()
        {
            return _position < _collection.Length;
        }

        public T Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more elements to iterate over.");

            T currentItem = _collection[_position];
            _position++;
            return currentItem;
        }
    }

    // Aggregate interface
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }

    // ConcreteAggregate class
    public class ConcreteAggregate<T> : IAggregate<T>
    {
        private readonly T[] _collection;

        public ConcreteAggregate(T[] collection)
        {
            _collection = collection;
        }

        public IIterator<T> CreateIterator()
        {
            return new ConcreteIterator<T>(_collection);
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            var aggregate = new ConcreteAggregate<string>(collection);
            var iterator = aggregate.CreateIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
