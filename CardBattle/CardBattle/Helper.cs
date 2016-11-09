using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public static class Helper
    {
        public static string With(this string format, params object[] parameters)
        {
            return string.Format(format, parameters);
        }
    }
}
