using FreeIt.Domain.Common.Enums;

namespace FreeIt.Domain.Common.Models.Requests.Millionaire
{
    public class GetQuestionRequest
    {
        /// <summary>
        /// Сложность вопроса.
        /// </summary>
        public LevelDifficulty QType { get; set; }

        /// <summary>
        /// Количество вопросов (в пределах от 1 до 5).
        /// </summary>
        public int Count { get; set; } = 5;

        /// <summary>
        /// Ключ для снятия ограничений.
        /// Если этот параметр не указан, размер выборки будет ограничен 10 вопросами для каждого типа.
        /// </summary>
        public string ApiKey { get; set; } = null;
    }
}