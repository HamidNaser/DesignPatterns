using System;

namespace Singleton
{
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
                    Console.WriteLine("lock (_lock)");
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }

        public void Write()
        {
            for (var index = 0; index < 1000; index++)
            {
                Console.WriteLine(index.ToString());
            }
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.Write();
            Singleton.Instance.Write();

        }
    }

}