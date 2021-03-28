using ConversionTool.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Services
{
    public interface IConverter
    {
        public Task<List<string>> getConversionTypes();
        public Task<IConverterResult> convert(IConverterRequest converterRequest);
    }
}
