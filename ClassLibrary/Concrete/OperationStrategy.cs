using ClassLibrary.Abstract;

namespace ClassLibrary.Concrete
{
    public class OperationStrategy
    {
        IOperation operation = null;

        public OperationStrategy(IOperation strategy)
        {
            operation = strategy;
        }

        public double Calculate(double a, double b)
        {
            return operation.Calculate(a, b);
        }
    }
}
