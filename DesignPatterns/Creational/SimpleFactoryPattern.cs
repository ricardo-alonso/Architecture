using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public class SimpleFactoryPattern
    {
        //A factory is such an object that can create other objects.
        //A factory can be invoked in many different ways but most often, it uses a method that
        //can return objects with varying prototypes.
    }

    public interface IAnimal
    {
        void Speak();
        void Action();
    }
    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...");
        }
    }
    public class Tiger : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Tigers prefer hunting...");
        }
    }
    public abstract class ISimpleFactory
    {
        public abstract IAnimal CreateAnimal();
    }

    public class SimpleFactory : ISimpleFactory
    {
        public override IAnimal CreateAnimal()
        {
            IAnimal intendedAnimal = null;
            Console.WriteLine("Enter your choice(0 for Dog, 1 for Tiger)");
            string b1 = Console.ReadLine();
            int input;

            if (int.TryParse(b1, out input))
            {
                Console.WriteLine("You have entered {0}", input);
                switch (input)
                {
                    case 0:
                        intendedAnimal = new Dog();
                        break;
                    case 1:
                        intendedAnimal = new Tiger();
                        break;
                    default:
                        Console.WriteLine("You must enter either 0 or 1");
                        //We'll throw a runtime exception for any other choices.
                            throw new ApplicationException(String.Format
                            (" Unknown Animal cannot be instantiated"));
                }
            }
            return intendedAnimal;
        }
    }
}
