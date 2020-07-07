using System;
using System.Text;
using static FreeIt.Domain.Common.Constants.Constants;

namespace FreeIt.Domain.Common.Helpers
{
    public static class ConsoleHelper
    {
        static ConsoleHelper()
            => Console.OutputEncoding = Encoding.UTF8;

        public static string ReadValueFromConsole(this string template)
        {
            Console.WriteLine(template);
            return Console.ReadLine();
        }

        public static void StringToConsole(this string row, string template = Templates.StringToConsole)
            => Console.WriteLine(template, row);

        public static void StringToConsole(this string row, string template, params object[] args)
            => Console.WriteLine(template, row, args);

        public static void IntToConsole(this int number, string template = Templates.NumberToConsole)
            => Console.WriteLine(template, number);

        public static void IntToConsole(this int number, string template, params object[] args)
            => Console.WriteLine(template, number, args);

        public static void DoubleToConsole(this double number, string template = Templates.NumberToConsole)
            => Console.WriteLine(template, number);

        public static void DoubleToConsole(this double number, string template, params object[] args)
            => Console.WriteLine(template, number, args);
    }
}