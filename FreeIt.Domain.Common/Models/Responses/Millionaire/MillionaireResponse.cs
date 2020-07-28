using System.Collections.Generic;
using FreeIt.Domain.Common.Models.Db;

namespace FreeIt.Domain.Common.Models.Responses.Millionaire
{
    public class MillionaireResponse
    {
        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        public bool Ok { get; set; }

        /// <summary>
        /// Вернёт array of QuestionData при успешном выполнении запроса или текст ошибки string в случае неудачи.
        /// </summary>
        public IEnumerable<QuestionDataDbModel> Data { get; set; }

        /// <summary>
        /// Баланс API-ключа.
        /// Если параметр "apikey" не был указан, вернёт "-1".
        /// </summary>
        public float Amount { get; set; }

    }
}