#region

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;
using Service.Pattern;
using TransRoute.Common.Http;
using TransRoute.Common.Model;
using TransRoute.Entities.Db;
using TransRoute.Service.HttpUtil;

#endregion

namespace TransRoute.Service
{ 
    public interface IHttpService
    {
        Task<GenericResponse<SubAccountResp>> CreateSubAccount(SubAccountVm data);
    }
 
    public class HttpService : IHttpService
    {
        public async Task<GenericResponse<SubAccountResp>> CreateSubAccount(SubAccountVm data)
        {
            //todo Cleanups
            //create subaccount
            var requestUri = "https://api.paystack.co/subaccount";// $"{BaseUrl}";
            SetUrlToken();
            var response = await HttpRequestFactory.Post(requestUri, data);
            var outputModel = response.ContentAsType<SubAccountResp>();
            
            if (outputModel.Status)
            {
                return new GenericResponse<SubAccountResp>(){ Message = "Create", ResponseCode = ResponseCode.Ok, Result = outputModel};
            }
            else
            {
                return new GenericResponse<SubAccountResp>() { Message = outputModel.Message, ResponseCode = ResponseCode.BadRequest, Result = null };
            }
             
        }

        private static void SetUrlToken()
        {
            //https://api.paystack.co/subaccount
            HttpRequestFactory.RequestBuilder = new HttpRequestBuilder();
            HttpRequestFactory.RequestBuilder.AddBearerToken(SecretKeyPayStack);
        }

        public static string BaseUrl { get; } = ConfigurationManager.AppSettings["GatewayUrl"] ?? "sk_test_3abe0519484e4f15dde905995b0f6276fb343ae6";
        public static string SecretKeyFlutterWave { get; } = ConfigurationManager.AppSettings["SecretKeyFlutterWave"] ?? "FLWSECK-c373e512a98b28faf92f284c0b3870a8-X";
        public static string SecretKeyPayStack { get; } = ConfigurationManager.AppSettings["SecretKeyFlutterWave"] ?? "sk_test_3abe0519484e4f15dde905995b0f6276fb343ae6";
    }
}