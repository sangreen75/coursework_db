using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parsers
{
    public static class Patterns
    {
        public const string ClientLine = @"(?<id>\d+)\s+(?<region>.*)\s+(?<income>\d+)";
    }
}
