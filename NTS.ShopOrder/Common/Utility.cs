using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// Статический класс вспомогательных функций
    /// </summary>
    public static class Utility
    {
        static public Dictionary<string, string> StringToDict(string str)
        {
            string[] arr = str.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

            return arr
                .Select(x => x.Split('='))
                .ToDictionary(i => i[0], i => i[1]);
        }

        static public Dictionary<string, object > StringToDictObj(string str)
        {
            string[] arr = str.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

            return arr
                .Select(x => x.Split('='))
                .ToDictionary(i => i[0], i => (object)i[1]);
        }
    }
}
