using FreeIt.Domain.Common.Enums;

namespace FreeIt.Domain.Common.Helpers
{
    public static class SwitchHelper
    {
        public static int GetPrizeSum(int step) => step switch
        {
            1 => (int)WinningAmount.Two,
            2 => (int)WinningAmount.Three,
            3 => (int)WinningAmount.Four,
            4 => (int)WinningAmount.Five,
            5 => (int)WinningAmount.Six,
            6 => (int)WinningAmount.Seven,
            7 => (int)WinningAmount.Eight,
            8 => (int)WinningAmount.Nine,
            9 => (int)WinningAmount.Ten,
            10 => (int)WinningAmount.Eleven,
            11 => (int)WinningAmount.Twelve,
            12 => (int)WinningAmount.Thirteen,
            13 => (int)WinningAmount.Fourteen,
            14 => (int)WinningAmount.Fifteen,
            _ => (int)WinningAmount.One
        };
    }
}