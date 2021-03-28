using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ConversionTool.Classes.SupportedTypes;

namespace ConversionTool.Services.API
{
    public interface IConverterAPIFactory
    {
        public IConverterAPI getConverterAPI(ConverterTypes converterType);
    }
}
