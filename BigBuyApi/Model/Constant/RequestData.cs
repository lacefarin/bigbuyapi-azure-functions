using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model.Constant
{
    internal struct RequestData
    {

        internal RequestData(string path, Dictionary<string, string?> parameters)
        {
            Path = path;
            Parameters = parameters;
        }

        internal string Path { get; init; }
        internal Dictionary<string, string?> Parameters { get; init; }

    }
}
