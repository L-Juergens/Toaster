using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toaster
{
    public static class Converter
    {
        public static int Convert(int sekunden)
        {
            int result;
            
            if (sekunden <= 15)
            { return result = 0; }
            if (sekunden <= 30)
            { return result = 1; }
            if (sekunden <= 45)
            { return result = 2; }
            if (sekunden < 45)
            { return result = 3; }
            else return result = 0;

        }
    }
}
