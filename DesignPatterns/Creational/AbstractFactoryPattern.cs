using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public class AbstractFactoryPattern
    {
        //Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
    }

    public interface IDog
    {
        void Speak();
        void Action();
    }
    public interface ITiger
    {
        void Speak();
        void Action();
    }
    #region Wild Animal collections
    class WildDog : IDog
    {
        public void Speak()
        {
            Console.WriteLine("Wild Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Wild Dogs prefer to roam freely in jungles.\n");
        }
    }
    class WildTiger : ITiger
    {
        public void Speak()
        {
            Console.WriteLine("Wild Tiger says: Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Wild Tigers prefer hunting in jungles.\n");
        }

    }

    #endregion
    #region Pet Animal collections
    class PetDog : IDog
    {
        public void Speak()
        {
            Console.WriteLine("Pet Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Pet Dogs prefer to stay at home.\n");
        }
    }
    class PetTiger : ITiger
    {
        public void Speak()
        {
            Console.WriteLine("Pet Tiger says: Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Pet Tigers play in an animal circus.\n");
        }
    }
    #endregion
    //Abstract Factory
    public interface IAnimalFactory_AF
    {
        IDog GetDog();
        ITiger GetTiger();
    }

    //Concrete Factory-Wild Animal Factory
    public class WildAnimalFactory : IAnimalFactory_AF
    {
        public IDog GetDog()
        {
            return new WildDog();
        }
        public ITiger GetTiger()
        {
            return new WildTiger();
        }
    }

    //Concrete Factory-Pet Animal Factory
    public class PetAnimalFactory : IAnimalFactory_AF
    {
        public IDog GetDog()
        {
            return new PetDog();
        }
        public ITiger GetTiger()
        {
            return new PetTiger();
        }
    }

}
