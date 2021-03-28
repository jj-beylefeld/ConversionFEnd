using ConversionTool.Classes;
using ConversionTool.Classes.Implementations;
using ConversionTool.Classes.Interfaces;
using ConversionTool.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConversionTool.Services.Converter
{
    public class LengthConverter : IConverter
    {
        protected readonly IConverterAPIFactory _converterAPIFactory;
        IConverterAPI _converterAPI;
        public LengthConverter(IConverterAPIFactory converterAPIFactory)
        {
            _converterAPIFactory = converterAPIFactory ?? throw new ArgumentNullException(nameof(converterAPIFactory));
            _converterAPI = _converterAPIFactory.getConverterAPI(SupportedTypes.ConverterTypes.Length);
        }
        public async Task<IConverterResult> convert(IConverterRequest converterRequest)
        {
            return JsonSerializer.Deserialize<ConverterResult>(_converterAPI.requestConversion(converterRequest).Result.Content);
        }

        public async Task<List<string>> getConversionTypes()
        {
            return JsonSerializer.Deserialize<List<string>>(_converterAPI.getConvertTypes().Result.Content);
        }
    }
}
