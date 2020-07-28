using FreeIt.Domain.Common.Models.Requests.Millionaire;
using FreeIt.Domain.Interfaces.Services.External;
using static FreeIt.Domain.Common.Constants.Constants;

namespace FreeIt.Domain.Services.LowLevel.FourthWeek.External
{
    public class QueryBuilder : IQueryBuilder
    {
        public string BuildQueryString(GetQuestionRequest request)
            => string.Format(QueryTemplates.MillionaireRequestQueryTemplate, Quiz.LifeIsPornConnection, Quiz.ScriptMillionaire, (int)request.QType, request.Count, request.ApiKey);

    }
}