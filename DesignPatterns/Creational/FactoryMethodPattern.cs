using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public class FactoryMethodPattern
    {
        //Define an interface for creating an object, but let subclasses decide which class to 
        //instantiate.The Factory Method pattern lets a class defer instantiation to subclasses.
    }

    public interface IAnimal_FM
    {
        void Speak();
        void Action();
    }

    public class Dog_FM : IAnimal_FM
    {
        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...\n");
        }
    }
    public class Tiger_FM : IAnimal_FM
    {
        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Tigers prefer hunting...\n");
        }
    }

    //public abstract class IAnimalFactory
    //{
    //    //Remember the GoF definition which says "....Factory method lets a class
    //    //defer instantiation to subclasses." Following method will create a Tiger
    //    //or Dog But at this point it does not know whether it will get a Dog or a
    //    //Tiger. It will be decided by the subclasses i.e.DogFactory or TigerFactory.
    //    //So, the following method is acting like a factory (of creation).
    //    public abstract IAnimal CreateAnimal();
    //}

    public abstract class IAnimalFactory
    {
        public IAnimal MakeAnimal()
        {
            Console.WriteLine("\n IAnimalFactory.MakeAnimal()-You cannot ignore parent rules.");
            /*
            At this point, it doesn't know whether it will get a
            Dog or a Tiger. It will be decided by the subclasses
            i.e.DogFactory or TigerFactory. But it knows that it
            will Speak and it will have a preferred way of Action.
            */
            IAnimal animal = CreateAnimal();
            animal.Speak();
            animal.Action();
            return animal;
        }
        //So, the following method is acting like a factory
        //(of creation).
        public abstract IAnimal CreateAnimal();
    }

    public class DogFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            //Creating a Dog
            return new Dog();
        }
    }

    public class TigerFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            //Creating a Tiger
            return new Tiger();
        }
    }
}
