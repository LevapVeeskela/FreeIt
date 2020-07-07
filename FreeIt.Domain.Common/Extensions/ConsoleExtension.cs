using System;
using System.Text;
using static FreeIt.Domain.Common.Constants.Constants;

namespace FreeIt.Domain.Common.Extensions
{
    public static class ConsoleExtension
    {
        static ConsoleExtension()
            => Console.OutputEncoding = Encoding.UTF8;

        public static string GetValueFromConsole(this string template)
        {
            Console.WriteLine(template);
            return Console.ReadLine();
        }

        public static void ToConsole(this string row)
            => Console.WriteLine(row); 

        public static void ToConsole(this string row, string template)
            => Console.WriteLine(template, row);

        public static void ToConsole(this string row, string template, params object[] args)
            => Console.WriteLine(template, row, args);

        public static void ToConsole(this int number, string template = Templates.NumberToConsole)
            => Console.WriteLine(template, number);

        public static void ToConsole(this int number, string template, params object[] args)
            => Console.WriteLine(template, number, args);

        public static void ToConsole(this double number, string template = Templates.NumberToConsole)
            => Console.WriteLine(template, number);

        public static void ToConsole(this double number, string template, params object[] args)
            => Console.WriteLine(template, number, args);

        public static void ToConsole(this long number, string template = Templates.NumberToConsole)
            => Console.WriteLine(template, number);

        public static void ToConsole(this long number, string template, params object[] args)
            => Console.WriteLine(template, number, args);
    }
}