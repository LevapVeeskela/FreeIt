using System.Linq;

namespace FreeIt.Domain.Common.Extensions
{
    public static class StringExtension
    {
        private static readonly string[] Operators = { "+", "-", "*", "/" };

        public static bool IsOperator(this string row)
            => Operators.Contains(row);
    }
}
