using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Concrete
{
    public delegate double F(double x);

    public class TrapezoidsMethod
    {
        public double Calculate(double xp, double xk, int n, F func)
        {
            double dx, integral;

            dx = (xk - xp) / (double)n;

            integral = 0;
            for (int i = 1; i < n; i++)
            {
                integral += func(xp + i * dx);
            }
            integral += (func(xp) + func(xk)) / 2;
            integral *= dx;

            return integral;
        }
    }
}
