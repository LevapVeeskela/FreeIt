namespace FreeIt.Domain.Common.Constants
{
    public static class Constants
    {
        #region Templates
        public static class Templates
        {
            public const string EnterCountValues = "Введите кол-во значений которые будут перемножены: ";
            public const string EnterValue = "Введите значение: ";
            public const string EnterValueTemplate = "Введите {0} значение:";
            public const string StringToConsole = "Результат выполнения: {0}";
            public const string NumberToConsole = "Результат вычисления: {0}";
        }
        #endregion

        #region Errors
        public static class TextErrors
        {
            public const string WrongFormat = "Вы ввели значение не того формата, повторите попытку!";
        }
        #endregion
    }
}