using ClassLibrary.Abstract;
using ClassLibrary.Concrete;
using System;

namespace Project
{
    public class TrapezoidsMethodAdapter : IOperation
    {
        private TrapezoidsMethod adaptee = null;

        public TrapezoidsMethodAdapter(TrapezoidsMethod trapezoidsMethod)
        {
            adaptee = trapezoidsMethod;
        }

        public double Calculate(double a, double b)
        {
            double xp, xk;
            int n;
            string input = "";

            Console.WriteLine("Wybierz funkcjie do całkowania");
            Console.WriteLine("1. x^2 + 2");
            Console.WriteLine("2. xsin(x) + x");
            Console.WriteLine("3. x - 2x");
            Console.WriteLine("4. sin(x)");
            Console.WriteLine("5. cos(x)");
            Console.WriteLine();
            Console.WriteLine("Nr Funkcji:");
            int nr = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj poczatek przedzialu calkowania");
            input = Console.ReadLine();

            if (input.ToLower().Equals("m"))
            {
                xp = Singleton.GetInstance.RememberedResult.Value;
            }
            else
            {
                xp = double.Parse(input);
            }
            

            Console.WriteLine("Podaj koniec przedzialu calkowania");
            input = Console.ReadLine();

            if (input.ToLower().Equals("m"))
            {
                xk = Singleton.GetInstance.RememberedResult.Value;
            }
            else
            {
                xk = double.Parse(input);
            }

            Console.WriteLine("Podaj ilość przedziałów calkowania");
            n = int.Parse(Console.ReadLine());

            var fun = FunctionFactory.CreateFunctionObject(nr);

            return adaptee.Calculate(xp, xk, n, fun.GetFunction());
        }
    }
}
