using FreeIt.Domain.Common.Models.Requests.Millionaire;

namespace FreeIt.Domain.Interfaces.Services.External
{
    public interface IQueryBuilder
    {
        string BuildQueryString(GetQuestionRequest request);

    }
}