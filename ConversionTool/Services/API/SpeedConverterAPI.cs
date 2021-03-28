using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Services.API
{
    public class SpeedConverterAPI : BaseConverterAPI, IConverterAPI
    {
        protected override void configureAPI()
        {
            _baseUrl = "https://localhost:55704/";
            _getTypesUri = "/api/Speed/converterTypes";
            _convertUri = "/api/Speed/convert";
        }
    }
}
