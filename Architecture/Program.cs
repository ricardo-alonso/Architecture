using System;
using DesignPatterns.Creational;

namespace Architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Algoritmos

            var r1 = Algoritmhs.LongestCommonPrefix.Solution(new string[] { "cir", "car" }); //{"ab", "a"}|| { "flower", "flow", "flight" } || "cir","car"
            var r2 = Algoritmhs.RomanToInt.Solution("MCMXCIV");
            var r3 = Algoritmhs.LetterCombinationsofaPhoneNumber.Solution("23");//doesnt works
            #endregion


            #region SimpleFactory

            Console.WriteLine("*** Simple Factory Pattern Demo***\n");
            IAnimal preferredType = null;
            ISimpleFactory simpleFactory = new SimpleFactory();
            #region The code region that will vary based on users preference
            preferredType = simpleFactory.CreateAnimal();
            #endregion
            #region The codes that do not change frequently
            preferredType.Speak();
            preferredType.Action();
            #endregion
            Console.ReadKey();

            #endregion

            #region FactoryMethod
            
            Console.WriteLine("***Factory Pattern Demo***\n");
            // Creating a Tiger Factory
            IAnimalFactory tigerFactory = new TigerFactory();
            // Creating a tiger using the Factory Method
            IAnimal tiger = tigerFactory.MakeAnimal();
            //IAnimal aTiger = tigerFactory.CreateAnimal();
            //aTiger.Speak();
            //aTiger.Action()

            // Creating a DogFactory
            IAnimalFactory dogFactory = new DogFactory();
            // Creating a dog using the Factory Method
            IAnimal dog = dogFactory.MakeAnimal();
            //IAnimal aDog = dogFactory.CreateAnimal();
            //aDog.Speak();
            //aDog.Action();
            Console.ReadKey();

            #endregion

            #region AbstractFactory

            Console.WriteLine("***Abstract Factory Pattern Demo***\n");
            //Making a wild dog through WildAnimalFactory
            IAnimalFactory_AF wildAnimalFactory = new WildAnimalFactory();
            IDog wildDog = wildAnimalFactory.GetDog();
            wildDog.Speak();
            wildDog.Action();
            //Making a wild tiger through WildAnimalFactory
            ITiger wildTiger = wildAnimalFactory.GetTiger();
            wildTiger.Speak();
            wildTiger.Action();
            Console.WriteLine("******************");
            //Making a pet dog through PetAnimalFactory
            IAnimalFactory_AF petAnimalFactory = new PetAnimalFactory();
            IDog petDog = petAnimalFactory.GetDog();
            petDog.Speak();
            petDog.Action();
            //Making a pet tiger through PetAnimalFactory
            ITiger petTiger = petAnimalFactory.GetTiger();
            petTiger.Speak();
            petTiger.Action();
            Console.ReadLine();

            #endregion
        }
    }
}
