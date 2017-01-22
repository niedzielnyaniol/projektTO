using ClassLibrary.Concrete;

namespace Project
{
    public static class CommandParser
    {
        public static Command Parse(string commandString, ref double? a, ref double? b)
        {
            var arr = commandString.Split(' ');

            if (arr.Length == 3)
            {
                return isSimpleCommand(arr, ref a, ref b);
            }
            else if (arr.Length == 1)
            {
                a = b = -1;
                return oneArgCommand(arr);
            }
            else
            {
                return Command.Unknown;
            }
        }

        private static Command oneArgCommand(string[] arr)
        {
            switch (arr[0].ToLower())
            {
                case "q":
                    return Command.Quit;
                case "c":
                    return Command.Internal;
                default:
                    return Command.Unknown;
            }
        }

        private static Command isSimpleCommand(string[] arr, ref double? a, ref double? b)
        {
            double a1, b1;
            
            if (double.TryParse(arr[1], out a1))
            {
                a = a1;
            }
            else
            {
                if (arr[1].ToLower().Equals("m") && Singleton.GetInstance.RememberedResult != null)
                {
                    a = Singleton.GetInstance.RememberedResult;
                }
                else
                {
                    return Command.Wrong;
                }
            }

            if (double.TryParse(arr[2], out b1))
            {
                b = b1;
            }
            else
            {
                if (arr[2].ToLower().Equals("m") && Singleton.GetInstance.RememberedResult != null)
                {
                    b = Singleton.GetInstance.RememberedResult;
                }
                else
                {
                    return Command.Wrong;
                }
            }

            switch (arr[0])
            {
                case "+":
                    return Command.Addition;

                case "-":
                    return Command.Substraction;

                case "/":
                    return Command.Division;

                case "*":
                    return Command.Multiplication;

                default:
                    return Command.Unknown;
            }
        }
    }
}
