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
    public class TemperatureConverterAPITests
    {
        [Fact]
        public void liveTestTemperatureConversion()
        {
            var converter = new TemperatureConverterAPI();
            var converterRequest = new ConverterRequest { fromType = "Celsius", fromValue = 0, toType = "Fahrenheit" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(32.00, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public void liveTestTemperatureConversionFromFactory()
        {
            var apiFactory = new ConverterAPIFactory();
            var converter = apiFactory.getConverterAPI(SupportedTypes.ConverterTypes.Temperature);
            var converterRequest = new ConverterRequest { fromType = "Celsius", fromValue = 0, toType = "Fahrenheit" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(32.00, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public async Task liveTestTemperatureConverter()
        {
            var apiFactory = new ConverterAPIFactory();
            var tempConverter = new TemperatureConverter(apiFactory);
            var converterRequest = new ConverterRequest { fromType = "Celsius", fromValue = 0, toType = "Fahrenheit" };

            var result = await tempConverter.convert(converterRequest).ConfigureAwait(true);

            Assert.Equal(32.00, result.resultValue);
            Assert.NotEqual(35.00, result.resultValue);
        }
    }
}
