using ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Concrete
{
    public static class FunctionFactory
    {
        public static IFunction CreateFunctionObject(int funcNumber)
        {
            IFunction function = null;

            switch (funcNumber)
            {
                case 1:
                    function = new f1();
                    break;
                case 2:
                    function = new f2();
                    break;
                case 3:
                    function = new f3();
                    break;
                case 4:
                    function = new Sin();
                    break;
                case 5:
                    function = new Cos();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("function", "Nieznany rodzaj funkcji");
            }

            return function;
        }
    }
}
