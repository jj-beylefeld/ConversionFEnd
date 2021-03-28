using ConversionTool.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Classes.Implementations
{
    public class ConverterRequest : IConverterRequest
    {
        public string fromType { get ; set ; }
        public double fromValue { get ; set ; }
        public string toType { get ; set ; }
    }
}
