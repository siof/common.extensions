using System.Collections.Generic;

namespace siof.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defValue)
        {
            return dict.TryGetValue(key, out var val) ? val : defValue;
        }
    }
}