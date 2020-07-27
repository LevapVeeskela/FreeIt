using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FreeIt.Domain.Common.Models.Requests.Millionaire;
using FreeIt.Domain.Common.Models.Responses.Millionaire;
using FreeIt.Domain.Interfaces.Services.External;
using Marvin.StreamExtensions;

namespace FreeIt.Domain.Services.LowLevel.FourthWeek.External
{
    public class MillionaireClient : IMillionaireClient
    {
        private const string ApiKey = "&apikey=";

        private static readonly HttpClient Client = new HttpClient();

        private readonly IQueryBuilder _queryBuilder;

        public MillionaireClient(IQueryBuilder queryBuilder)
            => _queryBuilder = queryBuilder;
        
        public async Task<MillionaireResponse> GetAsync(GetQuestionRequest request, CancellationToken token)
        {
            var queryString = _queryBuilder.BuildQueryString(request);

            if (string.IsNullOrEmpty(request.ApiKey))
                queryString = queryString.Replace(ApiKey, string.Empty);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, queryString);

            using (var httpResponse = await Client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, token))
            {
                httpResponse.EnsureSuccessStatusCode();
                var stream = await httpResponse.Content.ReadAsStreamAsync();
                return stream.ReadAndDeserializeFromJson<MillionaireResponse>();
            }
        }
    }
}