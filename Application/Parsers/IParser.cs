using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parsers
{
    public interface IParser<T>
        where T : class
    {
        string Pattern { get; set; }
        IEnumerable<T> Parse(IEnumerable<string> lines);
    }
}
