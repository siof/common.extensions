using System;
using System.Linq;

namespace siof.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceSafe(this string str, char from, char to)
        {
            return str.IfNotNull(st => st.Replace(from, to));
        }

        public static string ReplaceSafe(this string str, string from, string to)
        {
            return str.IfNotNull(st => st.Replace(from, to));
        }

        public static bool IsEmptyOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNotEmptyOrWhiteSpace(this string str)
        {
            return !str.IsEmptyOrWhiteSpace();
        }

        public static string TrimSafe(this string str, params char[] trimChars)
        {
            return str.IfNotNull(strVal => strVal.Trim(trimChars));
        }

        public static string TrimStartSafe(this string str, params char[] trimChars)
        {
            return str.IfNotNull(strVal => strVal.TrimStart(trimChars));
        }

        public static string TrimEndSafe(this string str, params char[] trimChars)
        {
            return str.IfNotNull(strVal => strVal.TrimEnd(trimChars));
        }

        public static bool IsAlfaNumeric(this string str)
        {
            return str.IfNotNull(strVal => strVal.All(char.IsLetterOrDigit));
        }

        public static bool IsNumber(this string str)
        {
            if (!str.IfNotNull(strVal => strVal.All(c => char.IsDigit(c) || c == '.')))
                return false;

            if (str.StartsWith(".") || str.EndsWith("."))
                return false;
            
            return str.Count(_ => _ == '.') <= 1;
        }
        
        public static string RemoveFromEnd(this string value, string toRemove)
        {
            if (value.IsEmptyOrWhiteSpace() || string.IsNullOrEmpty(toRemove))
                return value;

            var index = value.LastIndexOf(toRemove, StringComparison.Ordinal);

            return value.Remove(index);
        }
    }
}
