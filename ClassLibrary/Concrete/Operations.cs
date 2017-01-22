using ClassLibrary.Abstract;

namespace ClassLibrary.Concrete
{
    public class Addition : IOperation
    {
        public double Calculate(double a, double b)
        {
            return a + b;
        }
    }

    public class Subtraction : IOperation
    {
        public double Calculate(double a, double b)
        {
            return a - b;
        }
    }

    public class Multiplication : IOperation
    {
        public double Calculate(double a, double b)
        {
            return a * b;
        }
    }

    public class Division : IOperation
    {
        public double Calculate(double a, double b)
        {
            return a / b;
        }
    }
}
