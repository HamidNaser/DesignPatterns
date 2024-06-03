using System;
using System.Collections.Generic;

/*
In this example:

- `ConcreteSubject` maintains a list of observers and notifies them when its state changes.
- `ConcreteObserver` implements the `Update` method to react to changes in the subject's state.
- The `Main` method demonstrates the creation of a subject, attachment of observers, changes to the subject's state, and detachment of an observer.


*/
// Subject interface that defines methods for attaching, detaching, and notifying observers.
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete subject class that maintains a list of observers and notifies them of changes.
public class ConcreteSubject : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private int _state;

    public int State
    {
        get { return _state; }
        set
        {
            _state = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}

// Observer interface that defines the method to be called when notified by the subject.
public interface IObserver
{
    void Update();
}

// Concrete observer class that implements the Update method to react to changes in the subject.
public class ConcreteObserver : IObserver
{
    private ConcreteSubject _subject;

    public ConcreteObserver(ConcreteSubject subject)
    {
        _subject = subject;
    }

    public void Update()
    {
        Console.WriteLine("Observer: Subject's state has changed to " + _subject.State);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create subject
        ConcreteSubject subject = new ConcreteSubject();

        // Create observers
        ConcreteObserver observer1 = new ConcreteObserver(subject);
        ConcreteObserver observer2 = new ConcreteObserver(subject);

        // Attach observers to the subject
        subject.Attach(observer1);
        subject.Attach(observer2);

        // Change subject's state
        subject.State = 5;
        subject.State = 10;

        // Detach an observer
        subject.Detach(observer2);

        // Change subject's state again
        subject.State = 15;

        Console.ReadLine();
    }
}
