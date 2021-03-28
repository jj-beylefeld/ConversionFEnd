using ConversionTool.Classes.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Services
{
    public class BaseConverterAPI : IConverterAPI
    {
        protected string _baseUrl = "";
        protected string _getTypesUri = "";
        protected string _convertUri = "";
        private RestClient _restClient;

        public BaseConverterAPI()
        {
            configureAPI();
            _restClient = new RestClient(_baseUrl);
        }

        public async Task<IRestResponse> getConvertTypes()
        {
            var restRequest = new RestRequest(_getTypesUri,Method.GET);
            return await _restClient.ExecuteAsync(restRequest).ConfigureAwait(false);
        }

        public async Task<IRestResponse> requestConversion(IConverterRequest converterRequest)
        {
            var restRequest = new RestRequest(_convertUri, Method.POST);
            restRequest.AddJsonBody(converterRequest);
            return await _restClient.ExecuteAsync(restRequest).ConfigureAwait(false);
        }

        protected virtual void configureAPI()
        {
            throw new NotImplementedException("configureAPI must be overridden");
        }
    }
}
