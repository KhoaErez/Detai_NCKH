using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_spkh.Levenshtein
{
    public interface IUnicodeNormalizer
    {
        string Normalize(string text);
    }
}
