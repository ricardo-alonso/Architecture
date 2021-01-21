using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
#nullable enable
    public sealed class SingletonPattern
    {
        private static SingletonPattern? _instance;

        public static SingletonPattern Instance
        {
            get
            {
                Console.WriteLine("Instance called");

                if (_instance==null)
                {
                    _instance = new SingletonPattern();
                }

                return _instance;

                //return _instance ??= new SingletonPattern();
            }
        }

        private SingletonPattern()
        {
            // cannot be created except within this class
            Console.WriteLine("Constructor invoked");
        }
    }
}
