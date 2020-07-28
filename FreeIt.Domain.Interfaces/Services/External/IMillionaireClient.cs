using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FreeIt.Domain.Common.Models.Db;
using FreeIt.Domain.Common.Models.Requests.Millionaire;
using FreeIt.Domain.Common.Models.Responses.Millionaire;

namespace FreeIt.Domain.Interfaces.Services.External
{
    public interface IMillionaireClient
    {
        Task<MillionaireResponse> GetAsync(GetQuestionRequest request, CancellationToken token);
    }
}