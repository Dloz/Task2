using System.Collections.Generic;
using System.Linq;

namespace TextHandler.Extensions {
    public static class ExtensionsString {
        public static IEnumerable<string> SplitBySeparator(this string type, char separator) {
            var str = new List<string>().ToArray();
            for (var i = 0; i < type.Length - 1; i++) {
                if (type[i] != separator) continue;
                str = str.Concat(new string[] { type.Substring(0, i) }).ToArray();
                str = str.Concat(new string[] { type.Substring(i, 1) }).ToArray();
                str = str.Concat(new string[] { type.Substring(i + 1, type.Length - i - 1) }).ToArray();
            }

            return str;
        }
        
    }
}