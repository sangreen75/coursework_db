using System.Collections.Generic;
using Application.DataModel.InputData;
using System.Text.RegularExpressions;

namespace Application.Parsers
{
    public class ClientPareser : IParser<Client>
    {
        public string Pattern { get; set; }

        public IEnumerable<Client> Parse(IEnumerable<string> lines)
        {
            var regex = new Regex(Pattern);
            foreach (var line in lines)
            {
                var match = regex.Match(line);
                if (match.Groups.Count <= 1) continue;
                yield return new Client
                    (
                        int.Parse(match.Groups["id"].Value),
                        int.Parse(match.Groups["income"].Value),
                        match.Groups["region"].Value
                    );
            }
        }
    }
}
