using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ConversionTool.Classes.SupportedTypes;

namespace ConversionTool.Services.API
{
    public class ConverterAPIFactory : IConverterAPIFactory
    {
        public IConverterAPI getConverterAPI(ConverterTypes converterType)
        {
            switch (converterType)
            {
                case ConverterTypes.Length:
                    return new LengthConverterAPI();
                case ConverterTypes.Mass:
                    return new MassConverterAPI();
                case ConverterTypes.Speed:
                    return new SpeedConverterAPI();
                case ConverterTypes.Temperature:
                    return new TemperatureConverterAPI();
                case ConverterTypes.Volume:
                    return new VolumeConverterAPI();
                default:
                    throw new ArgumentOutOfRangeException(string.Format("ConverterAPIFactory does not support type {0}",converterType));
            }
            
        }
    }
}
