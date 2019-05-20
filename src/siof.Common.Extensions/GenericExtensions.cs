using System.Linq;

namespace siof.Common.Extensions
{
    public static class GenericExtensions
    {
        public static T ValueOrDefault<T>(this T val, T defaultValue)
        {
            return val.IfNotNull(value => value, defaultValue);
        }

        public static bool IsOneOf<T>(this T value, params T[] paramList)
        {
            if (value == null || paramList == null) 
                return false;

            return paramList.Contains(value);
        }

        public static bool IsNotAnyOf<T>(this T value, params T[] paramList)
        {
            if (value == null || paramList == null) 
                return true;

            return !paramList.Contains(value);
        }
    }
}
