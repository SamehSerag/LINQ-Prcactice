using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_D10
{
    internal class CustomComparer : IEqualityComparer<string>
    {
       

        public bool Equals(string? x, string? y)
        {
            foreach (var chr in y.ToArray())
                if(!x.Contains(chr))
                    return false;
            
            return true;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.Sum(c => c);
        }
    }
}
