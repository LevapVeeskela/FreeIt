using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeIt.Domain.Common.Helpers
{
    public static class MathHelper
    {
        public static long CalculateMultiply(params int[] args)
        {
            var tempArgsList = args.ToList();

            if (args.Length < 2)
                return args.FirstOrDefault();

            if(args.Any(v => v == 0)) return 0;

            long result = 0;

            while (tempArgsList.Any())
            {
                if (Math.Abs(result) > 0)
                {
                    result = Multiple(result, tempArgsList.First());

                    tempArgsList.Remove(tempArgsList.First());

                    continue;
                }

                result = Multiple(tempArgsList.FirstOrDefault(), tempArgsList.LastOrDefault());

                tempArgsList.Remove(tempArgsList.FirstOrDefault());

                tempArgsList.Remove(tempArgsList.LastOrDefault());
            }

            return result;
        }

        static long Multiple(long x, long y)
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
    }
}