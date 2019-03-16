using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TransRoute.Service.HttpUtil
{
    public interface IHttpRequestBuilder
    {
        HttpRequestBuilder AddAcceptHeader(string acceptHeader);
        HttpRequestBuilder AddBearerToken(string bearerToken);
        HttpRequestBuilder AddContent(HttpContent content);
        HttpRequestBuilder AddMethod(HttpMethod method);
        HttpRequestBuilder AddRequestUri(string requestUri);
        HttpRequestBuilder AddTimeout(TimeSpan timeout);
        Task<HttpResponseMessage> SendAsync();
    }
}