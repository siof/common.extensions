using System.Text;

namespace siof.Common.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string ToUTF8String(this byte[] array)
        {
            return ToUtf8String(array);
        }
        
        public static string ToUtf8String(this byte[] array)
        {
            return array.IfNotNull(arr => Encoding.UTF8.GetString(array));
        }
        
        public static string ToHex(this byte[] bytes, bool upperCase = false)
        {
            var result = new StringBuilder(bytes.Length * 2);

            foreach (var t in bytes)
                result.Append(t.ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }
    }
}
