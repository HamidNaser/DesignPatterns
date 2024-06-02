Design patterns in software engineering are reusable solutions to common problems encountered in software design. They are templates designed to help you write code that is more maintainable, scalable, and robust. Here are some of the most well-known design patterns, categorized into three main types: creational, structural, and behavioral patterns.

### Creational Patterns
These patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

1. **Singleton**: Ensures a class has only one instance and provides a global point of access to it.
   ```csharp
   public class Singleton
   {
       private static Singleton _instance;
       private static readonly object _lock = new object();

       private Singleton() { }

       public static Singleton Instance
       {
           get
           {
               lock (_lock)
               {
                   if (_instance == null)
                   {
                       _instance = new Singleton();
                   }
                   return _instance;
               }
           }
       }
   }
   ```

2. **Factory Method**: Defines an interface for creating an object, but lets subclasses alter the type of objects that will be created.
   ```csharp
   public abstract class Creator
   {
       public abstract IProduct FactoryMethod();
   }

   public class ConcreteCreator : Creator
   {
       public override IProduct FactoryMethod()
       {
           return new ConcreteProduct();
       }
   }
   ```

3. **Abstract Factory**: Provides an interface for creating families of related or dependent objects without specifying their concrete classes.
   ```csharp
   public interface IAbstractFactory
   {
       IProductA CreateProductA();
       IProductB CreateProductB();
   }

   public class ConcreteFactory1 : IAbstractFactory
   {
       public IProductA CreateProductA() => new ProductA1();
       public IProductB CreateProductB() => new ProductB1();
   }
   ```

4. **Builder**: Separates the construction of a complex object from its representation, allowing the same construction process to create various representations.
   ```csharp
   public class Product
   {
       public string PartA { get; set; }
       public string PartB { get; set; }
   }

   public class Builder
   {
       private Product _product = new Product();

       public Builder BuildPartA(string partA)
       {
           _product.PartA = partA;
           return this;
       }

       public Builder BuildPartB(string partB)
       {
           _product.PartB = partB;
           return this;
       }

       public Product GetResult()
       {
           return _product;
       }
   }
   ```

5. **Prototype**: Creates new objects by copying an existing object, known as the prototype.
   ```csharp
   public abstract class Prototype
   {
       public abstract Prototype Clone();
   }

   public class ConcretePrototype : Prototype
   {
       public string Data { get; set; }

       public override Prototype Clone()
       {
           return (Prototype)this.MemberwiseClone();
       }
   }
   ```

### Structural Patterns
These patterns deal with object composition or structure, ensuring that if one part of a system changes, the entire structure does not need to do the same.

1. **Adapter**: Allows incompatible interfaces to work together.
   ```csharp
   public interface ITarget
   {
       void Request();
   }

   public class Adaptee
   {
       public void SpecificRequest() { }
   }

   public class Adapter : ITarget
   {
       private Adaptee _adaptee = new Adaptee();

       public void Request()
       {
           _adaptee.SpecificRequest();
       }
   }
   ```

2. **Bridge**: Decouples an abstraction from its implementation so that the two can vary independently.
   ```csharp
   public abstract class Abstraction
   {
       protected IImplementor _implementor;

       protected Abstraction(IImplementor implementor)
       {
           _implementor = implementor;
       }

       public abstract void Operation();
   }

   public interface IImplementor
   {
       void OperationImp();
   }

   public class ConcreteImplementorA : IImplementor
   {
       public void OperationImp() { }
   }
   ```

3. **Composite**: Composes objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
   ```csharp
   public interface IComponent
   {
       void Operation();
   }

   public class Leaf : IComponent
   {
       public void Operation() { }
   }

   public class Composite : IComponent
   {
       private List<IComponent> _children = new List<IComponent>();

       public void Add(IComponent component)
       {
           _children.Add(component);
       }

       public void Operation()
       {
           foreach (var child in _children)
           {
               child.Operation();
           }
       }
   }
   ```

4. **Decorator**: Adds additional responsibilities to an object dynamically.
   ```csharp
   public interface IComponent
   {
       void Operation();
   }

   public class ConcreteComponent : IComponent
   {
       public void Operation() { }
   }

   public class Decorator : IComponent
   {
       private IComponent _component;

       public Decorator(IComponent component)
       {
           _component = component;
       }

       public virtual void Operation()
       {
           _component.Operation();
       }
   }
   ```

5. **Facade**: Provides a simplified interface to a complex subsystem.
   ```csharp
   public class SubsystemA
   {
       public void OperationA() { }
   }

   public class SubsystemB
   {
       public void OperationB() { }
   }

   public class Facade
   {
       private SubsystemA _subsystemA = new SubsystemA();
       private SubsystemB _subsystemB = new SubsystemB();

       public void Operation()
       {
           _subsystemA.OperationA();
           _subsystemB.OperationB();
       }
   }
   ```

6. **Flyweight**: Reduces the cost of creating and managing a large number of similar objects by sharing as much data as possible.
   ```csharp
   public class Flyweight
   {
       private string _intrinsicState;

       public Flyweight(string intrinsicState)
       {
           _intrinsicState = intrinsicState;
       }

       public void Operation(string extrinsicState) { }
   }

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
   ```

7. **Proxy**: Provides a surrogate or placeholder for another object to control access to it.
   ```csharp
   public interface ISubject
   {
       void Request();
   }

   public class RealSubject : ISubject
   {
       public void Request() { }
   }

   public class Proxy : ISubject
   {
       private RealSubject _realSubject;

       public void Request()
       {
           if (_realSubject == null)
           {
               _realSubject = new RealSubject();
           }
           _realSubject.Request();
       }
   }
   ```

### Behavioral Patterns
These patterns are concerned with algorithms and the assignment of responsibilities between objects.

1. **Chain of Responsibility**: Passes a request along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.
   ```csharp
   public abstract class Handler
   {
       protected Handler _successor;

       public void SetSuccessor(Handler successor)
       {
           _successor = successor;
       }

       public abstract void HandleRequest(int request);
   }

   public class ConcreteHandler1 : Handler
   {
       public override void HandleRequest(int request)
       {
           if (request == 1)
           {
               // Handle request
           }
           else if (_successor != null)
           {
               _successor.HandleRequest(request);
           }
       }
   }
   ```

2. **Command**: Encapsulates a request as an object, thereby allowing for parameterization of clients with queues, requests, and operations.
   ```csharp
   public interface ICommand
   {
       void Execute();
   }

   public class ConcreteCommand : ICommand
   {
       private Receiver _receiver;

       public ConcreteCommand(Receiver receiver)
       {
           _receiver = receiver;
       }

       public void Execute()
       {
           _receiver.Action();
       }
   }

   public class Receiver
   {
       public void Action() { }
   }
   ```

3. **Interpreter**: Defines a representation for a language's grammar along with an interpreter that uses the representation to interpret sentences in the language.
   ```csharp
   public interface IExpression
   {
       int Interpret(Dictionary<string, int> context);
   }

   public class NumberExpression : IExpression
   {
       private int _number;

       public NumberExpression(int number)
       {
           _number = number;
       }

       public int Interpret(Dictionary<string, int> context)
       {
           return _number;
       }
   }
   ```

4. **Iterator**: Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
   ```csharp
   public interface IIterator
   {
       bool HasNext();
       object Next();
   }

   public class ConcreteIterator : IIterator
   {
       private ConcreteAggregate _aggregate;
       private int _currentIndex = 0;

       public ConcreteIterator(ConcreteAggregate aggregate)
       {
           _aggregate = aggregate;
       }

