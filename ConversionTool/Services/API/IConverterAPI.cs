using ConversionTool.Classes.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Services
{
    public interface IConverterAPI
    {
        public Task<IRestResponse> getConvertTypes();

        public Task<IRestResponse> requestConversion(IConverterRequest converterRequest);

    }
}
