using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Services
{
    public class TemperatureConverterAPI : BaseConverterAPI, IConverterAPI
    {
        public TemperatureConverterAPI() : base() { }
        protected override void configureAPI()
        {
            _baseUrl = "https://localhost:55704/";
            _getTypesUri = "/api/Temperature/converterTypes";
            _convertUri = "/api/Temperature/convert";
        }
    }
}
