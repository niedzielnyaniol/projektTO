using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.Concrete;
using Project;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void IsFunctionFactoryReturnProperFunction()
        {
            var result1 = FunctionFactory.CreateFunctionObject(1);
            var result2 = FunctionFactory.CreateFunctionObject(2);
            var result3 = FunctionFactory.CreateFunctionObject(3);
            var result4 = FunctionFactory.CreateFunctionObject(4);
            var result5 = FunctionFactory.CreateFunctionObject(5);

            Assert.IsInstanceOfType(result1, typeof(f1));
            Assert.IsInstanceOfType(result2, typeof(f2));
            Assert.IsInstanceOfType(result3, typeof(f3));
            Assert.IsInstanceOfType(result4, typeof(Sin));
            Assert.IsInstanceOfType(result5, typeof(Cos));
        }

        [TestMethod]
        public void IsIntegralAreWellCalculated()
        {
            double expectedResult = -49.5;
            double result;
            var trapezoidMethod = new TrapezoidsMethod();

            F function = FunctionFactory.CreateFunctionObject(3).GetFunction();
            result = trapezoidMethod.Calculate(1, 10, 10000, function);

            Assert.AreEqual(expectedResult, Math.Round(result, 10));
        }

        [TestMethod]
        public void IsCommandParserReturnProperCommand()
        {
            double? a1, a2;
            a1 = a2 = null;

            var addition = CommandParser.Parse("+ 2 3", ref a1, ref a2);
            Assert.AreEqual(2, a1.Value);
            Assert.AreEqual(3, a2.Value);
            Assert.AreEqual(Command.Addition, addition);

            a1 = a2 = null;

            var unknown = CommandParser.Parse("/ 2 s 3", ref a1, ref a2);
            Assert.AreEqual(null, a1);
            Assert.AreEqual(null, a2);
            Assert.AreEqual(Command.Unknown, unknown);

            a1 = a2 = null;

            var quit = CommandParser.Parse("q", ref a1, ref a2);
            Assert.AreEqual(-1, a1.Value);
            Assert.AreEqual(-1, a2.Value);
            Assert.AreEqual(Command.Quit, quit);
        }

        [TestMethod]
        public void TestOfOperationStrategy()
        {
            Assert.AreEqual(5, new OperationStrategy(new Addition()).Calculate(2, 3));
            Assert.AreEqual(0.5, new OperationStrategy(new Division()).Calculate(2, 4));
            Assert.AreEqual(-2, new OperationStrategy(new Subtraction()).Calculate(2, 4));
            Assert.AreEqual(8, new OperationStrategy(new Multiplication()).Calculate(2, 4));
        }
    }
}
