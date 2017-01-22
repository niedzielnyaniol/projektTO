using ClassLibrary.Abstract;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary.Concrete
{
    public class SimpleCalculatorController : TemplateMethod
    {
        private string _command;

        protected override void GetCommand()
        {
            Console.WriteLine("Wpisz komendę:");
            _command = Console.ReadLine();
        }

        protected override void FollowCommand()
        {
            OperationStrategy operationStrategy = null;
            double? a, b;

            a = b = null;

            switch (CommandParser.Parse(_command, ref a, ref b))
            {
                case Command.Addition:
                    operationStrategy = new OperationStrategy(new Addition());
                    break;
                case Command.Substraction:
                    operationStrategy = new OperationStrategy(new Subtraction());
                    break;
                case Command.Multiplication:
                    operationStrategy = new OperationStrategy(new Multiplication());
                    break;
                case Command.Division:
                    operationStrategy = new OperationStrategy(new Division());
                    break;
                case Command.Quit:
                    _byeHook = true;
                    break;
                case Command.Unknown:
                    Console.WriteLine("Nieznana komenda, spróbuj jeszcze raz");
                    GetCommand();
                    FollowCommand();
                    break;
                case Command.Wrong:
                    Console.WriteLine("Błędna komenda, spróbuj jeszcze raz");
                    GetCommand();
                    FollowCommand();
                    break;
                case Command.Internal:
                    operationStrategy = new OperationStrategy(new TrapezoidsMethodAdapter(new TrapezoidsMethod()));
                    break;
            }

            if (!_byeHook)
            {
                ResultViewer.ViewResult(operationStrategy.Calculate(a.Value, b.Value));
            }

        }
    }
}
