using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Services.API
{
    public class LengthConverterAPI : BaseConverterAPI, IConverterAPI
    {
        protected override void configureAPI()
        {
            _baseUrl = "https://localhost:55704/";
            _getTypesUri = "/api/Length/converterTypes";
            _convertUri = "/api/Length/convert";
        }
    }
}
