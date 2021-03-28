using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Services.API
{
    public class MassConverterAPI : BaseConverterAPI, IConverterAPI
    {
        protected override void configureAPI()
        {
            _baseUrl = "https://localhost:55704/";
            _getTypesUri = "/api/Mass/converterTypes";
            _convertUri = "/api/Mass/convert";
        }
    }
}
