using System;

namespace Project
{
    internal static class ResultViewer
    {
        public static void ViewResult(double result)
        {
            Console.WriteLine(result);
            if (Console.ReadLine().ToLower().Equals("m"))
            {
                Singleton.GetInstance.RememberedResult = (double)result;
            }
        }
    }
}
