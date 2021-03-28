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
    public class VolumeConverterAPITests
    {
        [Fact]
        public void liveTestVolumeConversion()
        {
            var converter = new VolumeConverterAPI();
            var converterRequest = new ConverterRequest { fromType = "CubicCentimeters", fromValue = 1000, toType = "CubicInches" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(61.02398, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public void liveTestVolumeConversionFromFactory()
        {
            var apiFactory = new ConverterAPIFactory();
            var converter = apiFactory.getConverterAPI(SupportedTypes.ConverterTypes.Volume);
            var converterRequest = new ConverterRequest { fromType = "CubicCentimeters", fromValue = 1000, toType = "CubicInches" };
            var result = converter.requestConversion(converterRequest);
            Assert.Equal(61.02398, JsonSerializer.Deserialize<ConverterResult>(result.Result.Content).resultValue);
        }

        [Fact]
        public async Task liveTestVolumeConverter()
        {
            var apiFactory = new ConverterAPIFactory();
            var tempConverter = new VolumeConverter(apiFactory);
            var converterRequest = new ConverterRequest { fromType = "CubicCentimeters", fromValue = 1000, toType = "CubicInches" };

            var result = await tempConverter.convert(converterRequest).ConfigureAwait(true);

            Assert.Equal(61.02398, result.resultValue);
            Assert.NotEqual(60, result.resultValue);
        }
    }
}
