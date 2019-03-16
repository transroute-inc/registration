using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TransRoute.Service.HttpUtil
{
    public static class HttpRequestFactory
    {
        public static HttpRequestBuilder RequestBuilder { get; set; }

        public static async Task<HttpResponseMessage> Get(string requestUri)
        {
            var builder = RequestBuilder
                .AddMethod(HttpMethod.Get)
                .AddRequestUri(requestUri);
            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Post(
            string requestUri, object value)
        {
            var builder = RequestBuilder
                .AddMethod(HttpMethod.Post)
                .AddRequestUri(requestUri)
                .AddContent(new JsonContent(value));
            return await builder.SendAsync();
        }
        
        public static async Task<HttpResponseMessage> PostFormUrlEncoded(
            string requestUri, IEnumerable<KeyValuePair<string, string>> value)
        {

            var builder = RequestBuilder
                .AddMethod(HttpMethod.Post)
                .AddRequestUri(requestUri)
                .AddContent(new FormUrlEncodedContent(value));

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Put(
            string requestUri, object value)
        {
            var builder = RequestBuilder
                .AddMethod(HttpMethod.Put)
                .AddRequestUri(requestUri)
                .AddContent(new JsonContent(value));

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Patch(
            string requestUri, object value)
        {
            var builder = RequestBuilder
                .AddMethod(new HttpMethod("PATCH"))
                .AddRequestUri(requestUri)
                .AddContent(new PatchContent(value));

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Delete(string requestUri)
        {
            var builder = RequestBuilder
                .AddMethod(HttpMethod.Delete)
                .AddRequestUri(requestUri);

            return await builder.SendAsync();
        }
    }
}