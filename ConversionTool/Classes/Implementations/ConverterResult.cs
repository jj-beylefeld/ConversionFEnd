﻿using ConversionTool.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionTool.Classes.Implementations
{
    public class ConverterResult : IConverterResult
    {
        public string fromType { get ; set ; }
        public double fromValue { get ; set ; }
        public string resultType { get ; set ; }
        public double resultValue { get ; set ; }
    }
}
