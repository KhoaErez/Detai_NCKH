using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_spkh.Model
{
    public class parameter
    {
        public string key { get; set; }

        public string value { get; set; }
        public static int kiemTra_Value(List<parameter> lst)
        {
            try
            {
                foreach (parameter p in lst)
                {
                    bool containsSpecialCharacter = ContainsSpecialCharacter(p.value);
                    if (!containsSpecialCharacter)
                    {
                        p.key = p.key.Trim();
                        p.value = p.value.Trim();
                    }
                    else
                    {
                        return -1;
                    }
                }
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static bool ContainsSpecialCharacter(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9_\s]");
        }
    }
}
