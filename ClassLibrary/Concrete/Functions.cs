using ClassLibrary.Abstract;
using System;

namespace ClassLibrary.Concrete
{
    public class f1 : IFunction
    {
        private double _function(double x)
        {
            return x * x + 2;
        }

        public F GetFunction()
        {
            return new F(_function);
        }
    }
    public class f2 : IFunction
    {
        private double _function(double x)
        {
            return x * Math.Sin(x) + x;
        }

        public F GetFunction()
        {
            return new F(_function);
        }
    }
    public class f3 : IFunction
    {
        private double _function(double x)
        {
            return x - 2 *x;
        }

        public F GetFunction()
        {
            return new F(_function);
        }
    }
    public class Sin : IFunction
    {

        public F GetFunction()
        {
            return new F(Math.Sin);
        }
    }
    public class Cos : IFunction
    {
        private double _function(double x)
        {
            return x * x * x + 2;
        }

        public F GetFunction()
        {
            return new F(Math.Cos);
        }
    }
}
