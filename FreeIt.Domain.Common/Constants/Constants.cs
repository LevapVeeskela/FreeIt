﻿using System.Data;

namespace FreeIt.Domain.Common.Constants
{
    public static class Constants
    {
        #region Templates
        public static class Templates
        {
            public const string EnterCountValues = "Введите кол-во значений которые будут перемножены: ";
            public const string EnterCountForPlusValues = "Введите кол-во значений которые будут сложены: ";
            public const string EnterValue = "Введите значение: ";
            public const string EnterOperation = "Введите операцию: +, -, /, * ";
            public const string EnterValueTemplate = "Введите {0} значение:";
            public const string StringToConsole = "Результат выполнения: {0}";
            public const string NumberToConsole = "Результат вычисления: {0}";
        }
        #endregion

        #region Errors
        public static class TextErrors
        {
            public const string WrongFormat = "Вы ввели значение не того формата, повторите попытку!";
            public const string NotOperation = "Вы ввели не операцию, повторите попытку!";
        }
        #endregion

        #region Quiz
        public static class Quiz
        {
            public const string LifeIsPornConnection = "https://engine.lifeis.porn";
            public const string Lip2XyzConnection = "https://lip2.xyz";
            public const string ScriptMillionaire = "millionaire.php";
        }
        #endregion

        #region QueryTemplates
        public static class QueryTemplates
        {
            public static string MillionaireRequestQueryTemplate
                = "{0}/api/{1}?qType={2}&count={3}&apikey={4}";
        }
        #endregion
    }
}