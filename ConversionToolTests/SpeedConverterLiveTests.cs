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
    public class SpeedConverterAPITests
    {
        [Fact]
        public void liveTestSpeedConversion()
        {
            var converter = new SpeedConverterAPI();
            var converterRequest = new ConverterRequest { fromType = "MilesPerHour", fromValue = 100, toType = "KilometersPerHour" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(160.9344, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public void liveTestSpeedConversionFromFactory()
        {
            var apiFactory = new ConverterAPIFactory();
            var converter = apiFactory.getConverterAPI(SupportedTypes.ConverterTypes.Speed);
            var converterRequest = new ConverterRequest { fromType = "KilometersPerHour", fromValue = 120, toType = "MilesPerHour" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(74.56454, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public async Task liveTestSpeedConverter()
        {
            var apiFactory = new ConverterAPIFactory();
            var tempConverter = new SpeedConverter(apiFactory);
            var converterRequest = new ConverterRequest { fromType = "KilometersPerHour", fromValue = 120, toType = "MilesPerHour" };

            var result = await tempConverter.convert(converterRequest).ConfigureAwait(true);

            Assert.Equal(74.56454, result.resultValue);
            Assert.NotEqual(70, result.resultValue);
        }
    }
}
