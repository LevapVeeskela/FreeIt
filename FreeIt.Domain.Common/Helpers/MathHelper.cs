using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace FreeIt.Domain.Common.Helpers
{
    public static class MathHelper
    {

        public static double Calculate(double firstValue, double secondValue, string @operator)
        {
            const string minus = "-";
            const string multiplication = "*";
            const string division = "/";

            switch (@operator)
            {
                case minus:
                    return firstValue - secondValue;
                case multiplication:
                    return firstValue * secondValue;
                case division:
                    return firstValue / secondValue;
                default: return firstValue + secondValue;
            }
        }

        public static long Calculate(Func<long, long, long> func, params int[] args)
        {
            var tempArgsList = args.ToList();

            if (args.Length < 2)
                return args.FirstOrDefault();

            if (args.Any(v => v == 0)) return 0;

            long result = 0;

            while (tempArgsList.Any())
            {
                if (Math.Abs(result) > 0)
                {
                    result = func(result, Math.Abs(tempArgsList.First()));

                    tempArgsList.Remove(tempArgsList.First());

                    continue;
                }

                result = func(Math.Abs(tempArgsList.FirstOrDefault()), Math.Abs(tempArgsList.LastOrDefault()));

                tempArgsList.Remove(tempArgsList.FirstOrDefault());

                tempArgsList.Remove(tempArgsList.LastOrDefault());
            }

            return result;
        }

        public static long Multiple(long x, long y)
        {
            long result = 0;

            while (x > 0)
            {
                if ((x & 1) > 0) result += y;

                y <<= 1;

                x >>= 1;
            }

            return result;
        }

        public static long AddInColumn(long x, long y)
        {
            var resultList = new List<int>();
            var firstValues = x.ToString().ToList().Select(_ => _ - '0').ToArray();
            var secondValues = y.ToString().ToList().Select(_ => _ - '0').ToArray();
            var firstCount = firstValues.Length;
            var secondCount = secondValues.Length;
            var maxCount = firstCount >= secondCount ? firstCount : secondCount;
            var difference = Math.Abs(firstCount - secondCount);
            var intermediateValue = 0;

            if (firstCount > secondCount)
                secondValues = new int[difference].Select(_ => 0).Concat(secondValues).ToArray();
            
            if (firstCount < secondCount)
                firstValues = new int[difference].Select(_ => 0).Concat(firstValues).ToArray();

            for (var i = maxCount - 1; i >= 0; i--)
            {
                var plusValues = firstValues[i] + secondValues[i];

                if (intermediateValue != 0)
                    plusValues += intermediateValue;

                var resultValue = plusValues % 10;

                intermediateValue = plusValues / 10;

                if (i == 0 && intermediateValue != 0) resultList.Add(plusValues);

                resultList.Add(resultValue);
            }

            resultList.Reverse();

            long.TryParse(String.Join("", resultList), out var result);

            return result;
        }
    }
}