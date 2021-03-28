using ConversionTool.Classes.Implementations;
using ConversionTool.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Text.Json;
using ConversionTool.Classes.Interfaces;
using ConversionTool.Services.API;
using ConversionTool.Classes;
using ConversionTool.Services.Converter;
using System.Threading.Tasks;

namespace ConversionToolTests
{
    public class LengthConverterAPITests
    {
        [Fact]
        public void liveTestLengthConversion()
        {
            var converter = new LengthConverterAPI();
            var converterRequest = new ConverterRequest { fromType = "Meters", fromValue = 1, toType = "Feet" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(3.28084, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public void liveTestLengthConversionFromFactory()
        {
            var apiFactory = new ConverterAPIFactory();
            var converter = apiFactory.getConverterAPI(SupportedTypes.ConverterTypes.Length);
            var converterRequest = new ConverterRequest { fromType = "Meters", fromValue = 1, toType = "Feet" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(3.28084, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public async Task liveTestLengthConverter()
        {
            var apiFactory = new ConverterAPIFactory();
            var tempConverter = new LengthConverter(apiFactory);
            var converterRequest = new ConverterRequest { fromType = "Meters", fromValue = 1, toType = "Feet" };

            var result = await tempConverter.convert(converterRequest).ConfigureAwait(true);

            Assert.Equal(3.28084, result.resultValue);
            Assert.NotEqual(3, result.resultValue);
        }
    }
}
