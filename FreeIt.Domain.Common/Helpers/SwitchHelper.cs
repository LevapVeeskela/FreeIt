using FreeIt.Domain.Common.Enums;

namespace FreeIt.Domain.Common.Helpers
{
    public static class SwitchHelper
    {
        public static int GetPrizeSum(int step) => step switch
        {
            2 => (int)WinningAmount.Two,
            3 => (int)WinningAmount.Three,
            4 => (int)WinningAmount.Four,
            5 => (int)WinningAmount.Five,
            6 => (int)WinningAmount.Six,
            7 => (int)WinningAmount.Seven,
            8 => (int)WinningAmount.Eight,
            9 => (int)WinningAmount.Nine,
            10 => (int)WinningAmount.Ten,
            11 => (int)WinningAmount.Eleven,
            12 => (int)WinningAmount.Twelve,
            13 => (int)WinningAmount.Thirteen,
            14 => (int)WinningAmount.Fourteen,
            15 => (int)WinningAmount.Fifteen,
            _ => (int)WinningAmount.One
        };
    }
}