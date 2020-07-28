using System.Data;

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
            public const string FirstWelcomeTemplate = " Приветствую Вас, {0}, на игре `Кто хочет стать Миллионером!?`";
            public const string SecondWelcomeTemplate = " И так, {0}, правила очень просты: 15 вопросов, 4 варианта ответа, 3 уровня сложности, начальная сумма 100 рублей,\n две несгораемых суммы, либо в любой момент, вы моежете забрать деньги нажав 5.\n Ну что, поехали!";
            public const string NumberQuestionTemplate = "Вопрос номер {0}\n";
            public const string FireproofPrizeTemplate = "Ваша несгораемая сумма: {0}\n";
            public const string WinnerPrizeTemplate = "Ваш выигрыш: {0}\n";
            public const string TrueAnswerTemplate = "Вы ошиблись((( правильный ответ: {0}\n";
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
            public const string Welcome = "Представьтесь, пожалуйста))";
            public const string TrueAnswer = "И это правильный ответ!";
            public const string Winner = "И у нас есть победитель, новоиспечённый миллионер!";
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