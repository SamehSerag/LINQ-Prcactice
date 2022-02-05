using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_D10
{
    internal class StrComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return x.ToLower().CompareTo(y.ToLower());
        }
    }
}
