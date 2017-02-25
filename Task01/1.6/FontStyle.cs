using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6
{
    [Flags]
    public enum FontStyle : byte
    {
        None = 0,
        Bold = 1,
        Italic = 2 ,
        Underline = 4,
    }
}
