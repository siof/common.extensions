using System;
using System.Collections.Generic;
using System.Text;

namespace siof.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string ToString<T>(this IEnumerable<T> collection)
        {
            var builder = new StringBuilder();

            collection.ForEach(element => builder.Append(element.ToString()));

            return builder.ToString();
        }

        public static string ToString<T>(this IEnumerable<T> collection, char separator)
        {
            var builder = new StringBuilder();

            collection.ForEach(element => builder.Append(element.ToString()).Append(separator));

            return builder.ToString();
        }

        public static string ToString<T>(this IEnumerable<T> collection, string separator)
        {
            var builder = new StringBuilder();

            collection.ForEach(element => builder.Append(element.ToString()).Append(separator));

            return builder.ToString();
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
                action.Invoke(element);
        }

        public static List<List<T>> SplitToList<T>(this IEnumerable<T> collection, uint chunkSize)
        {
            if (chunkSize < 1)
                throw new ArgumentException("Chunk size must have value greater than 0", nameof(chunkSize));

            return collection.IfNotNull(col =>
            {
                var result = new List<List<T>>();
                var currentList = new List<T>();

                col.ForEach(element =>
                {
                    currentList.Add(element);

                    if (currentList.Count == chunkSize)
                    {
                        result.Add(currentList);
                        currentList = new List<T>();
                    }
                });

                if (currentList.Count > 0)
                    result.Add(currentList);

                return result;
            });
        }
    }
}
