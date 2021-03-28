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
    public class MassConverterAPITests
    {
        [Fact]
        public void liveTestMassConversion()
        {
            var converter = new MassConverterAPI();
            var converterRequest = new ConverterRequest { fromType = "Kilograms", fromValue = 1, toType = "Pounds" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(2.20462, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public void liveTestMassConversionFromFactory()
        {
            var apiFactory = new ConverterAPIFactory();
            var converter = apiFactory.getConverterAPI(SupportedTypes.ConverterTypes.Mass);
            var converterRequest = new ConverterRequest { fromType = "Kilograms", fromValue = 1, toType = "Pounds" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(2.20462, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public async Task liveTestMassConverter()
        {
            var apiFactory = new ConverterAPIFactory();
            var tempConverter = new MassConverter(apiFactory);
            var converterRequest = new ConverterRequest { fromType = "Kilograms", fromValue = 1, toType = "Pounds" };

            var result = await tempConverter.convert(converterRequest).ConfigureAwait(true);

            Assert.Equal(2.20462, result.resultValue);
            Assert.NotEqual(2, result.resultValue);
        }
    }
}
