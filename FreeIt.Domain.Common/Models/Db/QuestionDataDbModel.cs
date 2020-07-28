using System.Collections.Generic;

namespace FreeIt.Domain.Common.Models.Db
{
    public class QuestionDataDbModel
    {
        /// <summary>
        /// Текст вопроса.
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Список из 4 вариантов ответа. Верный ответ указан первым в списке.
        /// Варианты ответа не перемешиваются.
        /// </summary>
        public IEnumerable<string> Answers { get; set; }

        /// <summary>
        /// Техническое поле, всегда равняется "0".
        /// </summary>
        public int Id { get; set; }
    }
}