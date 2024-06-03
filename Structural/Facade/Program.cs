using System;
/*
    ### Explanation

    1. **SubsystemA, SubsystemB, SubsystemC**: These classes represent different parts of a complex subsystem. Each class contains its own methods that perform specific operations.
    2. **Facade**: This class provides a simplified interface to interact with the subsystems. It contains references to the subsystem classes and provides a method (`Operation()`) to perform a series of operations involving multiple subsystems.
    3. **Client Code (`Program`)**: Demonstrates how to use the Facade pattern to interact with the subsystems through a simplified interface provided by the Facade class.
*/
namespace FacadePattern
{
    // SubsystemA
    public class SubsystemA
    {
        public void OperationA()
        {
            Console.WriteLine("SubsystemA: OperationA");
        }
    }

    // SubsystemB
    public class SubsystemB
    {
        public void OperationB()
        {
            Console.WriteLine("SubsystemB: OperationB");
        }
    }

    // SubsystemC
    public class SubsystemC
    {
        public void OperationC()
        {
            Console.WriteLine("SubsystemC: OperationC");
        }
    }

    // Facade
    public class Facade
    {
        private SubsystemA _subsystemA;
        private SubsystemB _subsystemB;
        private SubsystemC _subsystemC;

        public Facade()
        {
            _subsystemA = new SubsystemA();
            _subsystemB = new SubsystemB();
            _subsystemC = new SubsystemC();
        }

        public void Operation()
        {
            Console.WriteLine("Facade: Coordinating subsystems:");
            _subsystemA.OperationA();
            _subsystemB.OperationB();
            _subsystemC.OperationC();
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.Operation();
        }
    }
}
