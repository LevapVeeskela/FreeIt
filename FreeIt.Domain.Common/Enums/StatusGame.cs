using System;

namespace FreeIt.Domain.Common.Enums
{
    [Flags]
    public enum StatusGame
    {
        None = 0,
        Lose = 1,
        Win = 2,
        Incomplete = 4
    }
}