using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Services.Helpers
{
    public static class Extentions
    {
        public static string[][] ToTwoDimentionalArray(this string source, char rowSeparator = ';', char columnSeparator = ',')
        {
            return source
                   .Split(rowSeparator)
                   .Select(x => x.Split(columnSeparator))
                   .ToArray();
        }
    }
}
