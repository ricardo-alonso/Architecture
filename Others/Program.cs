using System;

namespace Others
{
    class Program
    {
        public delegate int MiDelegado(int a, int b);
        static void Main(string[] args)
        {
            MiDelegado del = new MiDelegado(Sum);
            var r = del(5,9);
            EjecutarFuncion2(Sum);
        }

        private static int Sum(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }

        private static int Algo (int a)
        {
            return a;
        }

        //private static void EjecutarFuncion(Func<string, int> Method)
        private static void EjecutarFuncion1(Func<int, int> Method)//La funcion que se pasa como parametro pide un int y devuelve un int
        {
            int r  = Method(36);
        }

        private static void EjecutarFuncion2(Func<int, int, int> Method)//La funcion que se pasa como parametro pide dos int y devuelve un int. //Two or more input parameters are separated by commas:
        {
            int r = Method(36,5);
        }
    }
}
